using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{   
    // Start is called before the first frame update
    void Start()
    {
        list = gameObject.GetComponentInParent<Enemies>().enemies;
        list.Add(gameObject);

        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.3f;

        gun = transform.Find("Gun").gameObject;
        shells = GameObject.Find("Shells").transform;

        StartCoroutine(ChooseDestination());
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
