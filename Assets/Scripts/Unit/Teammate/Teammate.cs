using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teammate : Unit
{
    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        list = gameObject.GetComponentInParent<Teammates>().teammates;
        list.Add(gameObject);

        info = GetComponent<ObjectInfo>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.3f;

        gun = transform.Find("Gun").gameObject;
        shells = GameObject.Find("Shells").transform;

        StartCoroutine(ChooseTarget(new string[] { "Enemy" }));
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
                if (hit.collider.tag == "Tile")
                {
                    info.isSelected = false;

                    destination = hit.collider.transform;

                    MoveTo(destination);
                }
            }
        }

        Aim();
    }
}
