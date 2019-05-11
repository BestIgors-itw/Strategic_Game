using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.3f;

        gun = transform.Find("Gun").gameObject;
        shells = GameObject.Find("Shells").transform;

        GameObject ds = GameObject.FindGameObjectWithTag("Strategic Object");
       
        if (ds != null) {
            destination = ds.transform;
            MoveTo(destination);
        }

        targets = new List<GameObject>();

        StartCoroutine(ChooseTarget(new string[] { "Teammate", "Strategic Object" }));
        StartCoroutine(Fire());
        StartCoroutine(Movement());        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }
}
