using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Teammate : Unit
{    
    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<ObjectInfo>();
        agent = GetComponent<NavMeshAgent>();

        gun = transform.Find("Gun").gameObject;
        shells = GameObject.Find("Shells").transform;

        StartCoroutine(Fire());
        StartCoroutine(ChooseTarget());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && info.isSelected)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Tile" || hit.collider.tag == "Finish")
                {
                    info.isSelected = false;

                    destination = hit.collider.gameObject;

                    MoveTo(destination);
                }
            }
        }

        Aim();
    }

    private IEnumerator ChooseTarget()
    {
        while (true)
        {            
            targets = GameObject.FindGameObjectsWithTag("Enemy");

            if (targets != null)
            {
                GameObject closest = null;
                float closest_sqrDistance = 0f;
                float check_sqrDistance;

                foreach (GameObject obj in targets)
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

                target = closest;
            }
            else
            {
                target = null;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    protected void Aim()
    {
        float distance;

        Vector3 heading;
        Vector3 direction;

        if (target != null)
        {
            heading = target.transform.position - transform.position;

            distance = heading.magnitude;

            direction = heading / distance;

            transform.rotation = Quaternion.LookRotation(new
                Vector3(direction.x, 0, direction.z));

            gun.transform.rotation = Quaternion.LookRotation(direction)
                * Quaternion.Euler(90, 0, 0);

            if (distance > target_range)
            {
                isAimed = false;
            }
            else
            {
                isAimed = true;
            }
        }
        else
        {
            isAimed = false;
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            if (isAimed) {
                GameObject sh = Instantiate(shell, gun.transform.position, gun.transform.rotation, shells.transform);
                Physics.IgnoreCollision(sh.GetComponent<Collider>(), GetComponent<Collider>());
                sh.transform.up = gun.transform.up;
            }
        }
    }    
}
