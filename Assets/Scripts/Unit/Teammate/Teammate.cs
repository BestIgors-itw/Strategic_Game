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

    protected void Aim()
    {
        float distance;

        Vector3 heading;
        Vector3 direction;

        if (target == null)
        {
            targets = GameObject.FindGameObjectsWithTag("Enemy");

            if (targets != null) {
                GameObject closest = null;

                foreach (GameObject obj in targets)
                {
                    if (closest == null)
                    {
                        closest = obj;
                    }
                    else
                    {
                        if ((closest.transform.position - transform.position).magnitude
                            > (obj.transform.position - transform.position).magnitude)
                        {
                            closest = obj;
                        }
                    }
                }

                target = closest;
            }
        }
        else
        {
            heading = target.transform.position - transform.position;

            distance = heading.magnitude;
            direction = heading / distance;

            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            gun.transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0);
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

            GameObject sh = Instantiate(shell, gun.transform.position, gun.transform.rotation, shells.transform);
            Physics.IgnoreCollision(sh.GetComponent<Collider>(), GetComponent<Collider>());
            sh.transform.up = gun.transform.up;
        }
    }    
}
