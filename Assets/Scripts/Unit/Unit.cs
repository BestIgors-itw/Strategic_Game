using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public float health;

    public float aimGorizontalSpeed;
    public float aimVerticalSpeed;

    protected bool isAimed;

    protected GameObject gun = null;
    public GameObject shell;

    protected GameObject target = null;   
    public float FireRange;

    protected Transform destination = null;

    protected NavMeshAgent agent;

    protected ObjectInfo info;

    protected Transform shells = null;

    protected void MoveTo(Transform destination)
    {
        agent.destination = destination.position;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            health -= collision.gameObject.GetComponent<Shell>().damage;

            if (health <= 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }

    protected void Aim()
    {
        float distance;

        Vector3 heading;
        Vector3 direction;

        if (agent.velocity == Vector3.zero)
        {
            if (target == null)
            {
                isAimed = false;
            }
            else
            {
                heading = target.transform.position - transform.position;

                distance = heading.magnitude;

                direction = heading / distance;

                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(new
                    Vector3(direction.x, 0, direction.z)), Time.deltaTime
                    * aimGorizontalSpeed);

                if (Vector3.Angle(new Vector3(heading.x, 0, heading.z), new
                    Vector3(transform.forward.x, 0, transform.forward.z)) < 10.0f)
                {
                    gun.transform.rotation = Quaternion.RotateTowards(
                        gun.transform.rotation, Quaternion.LookRotation(direction)
                    * Quaternion.Euler(90, 0, 0),
                        Time.deltaTime * aimVerticalSpeed);

                    if (Vector3.Angle(heading, gun.transform.up) < 10.0f)
                    {
                        if (distance > FireRange)
                        {
                            isAimed = false;
                        }
                        else
                        {
                            isAimed = true;
                        }
                    }
                }
                else
                {
                    isAimed = false;
                }
            }
        }
        else
        {
            isAimed = false;
        }
    }

    protected IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            if (isAimed)
            {
                GameObject sh = Instantiate(shell, gun.transform.position,
                    gun.transform.rotation, shells.transform);
                Physics.IgnoreCollision(sh.GetComponent<Collider>(),
                    GetComponent<Collider>());
                sh.transform.up = gun.transform.up;
            }
        }
    }

    protected IEnumerator ChooseTarget(string[] targetsTags)
    {
        while (true)
        {
            if (target == null || (target.transform.position -
                transform.position).magnitude > FireRange)
            {
                List<GameObject> targets = new List<GameObject>();

                foreach (string tag in targetsTags)
                {
                    targets.AddRange(GameObject.FindGameObjectsWithTag(tag));
                }

                if (targets.Count != 0)
                {                   
                    target = ChooseClosest(targets);
                }
                else
                {
                    target = null;
                }
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    protected IEnumerator ChooseDestination()
    {
        while (true)
        {
            if (destination == null)
            {
                List<GameObject> destinations = new List<GameObject>();

                destinations.AddRange(GameObject.FindGameObjectsWithTag("Strategic Object"));                

                if (destinations.Count != 0)
                {                   
                    destination = ChooseClosest(destinations).transform;
                }
                else
                {
                    destination = transform;
                }

                agent.destination = destination.position;
            }            

            yield return new WaitForSeconds(1f);
        }
    }

    GameObject ChooseClosest(List<GameObject> objs)
    {
        GameObject closest = null;
        float closest_sqrDistance = 0f;
        float check_sqrDistance;

        foreach (GameObject obj in objs)
        {
            if (closest_sqrDistance == 0f)
            {
                closest = obj;
                closest_sqrDistance = (obj.transform.position
                    - transform.position).sqrMagnitude;
            }
            else
            {
                check_sqrDistance = (obj.transform.position
                    - transform.position).sqrMagnitude;

                if (closest_sqrDistance > check_sqrDistance)
                {
                    closest = obj;
                    closest_sqrDistance = check_sqrDistance;
                }
            }
        }

        return closest;
    }

    protected IEnumerator Movement()
    {
        while (true)
        {           
            if (target == null || (target.transform.position -
                transform.position).magnitude > FireRange)
            {
                agent.isStopped = false;
            }
            else
            {
                agent.isStopped = true;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}