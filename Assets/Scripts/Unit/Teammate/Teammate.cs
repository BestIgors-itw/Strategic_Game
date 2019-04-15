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

        
        float aimY = (Mathf.Atan2(transform.position.x - target.transform.position.x,
            transform.position.z - target.transform.position.z) * 180f) / Mathf.PI;

        aimY -= 90f;

        if (aimY <= 180f)
        {
            aimY += 180f;
        }

        transform.rotation = Quaternion.Euler(0, aimY, 0);                
    }
}
