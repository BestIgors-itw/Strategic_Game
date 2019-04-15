using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Finish");
        agent = GetComponent<NavMeshAgent>();

        MoveTo(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
