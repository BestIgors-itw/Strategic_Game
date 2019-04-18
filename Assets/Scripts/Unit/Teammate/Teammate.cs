using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teammate : Unit
{
    private Ray ray;
    private RaycastHit hit;

    ObjectInfo info;

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<ObjectInfo>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Enemy");
        gun = transform.Find("Gun").gameObject;        
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

        if (target != null) {            
            Vector3 heading = target.transform.position - transform.position;

            float distance = heading.magnitude;
            Vector3 direction = heading / distance; 

            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)) * Quaternion.Euler(0, -90, 0);
            gun.transform.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 90);
        }
    }
}
