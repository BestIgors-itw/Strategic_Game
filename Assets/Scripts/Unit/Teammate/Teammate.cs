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
    }
}
