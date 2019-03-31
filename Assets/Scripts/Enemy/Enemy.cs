using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject interest;

    // Start is called before the first frame update
    void Start()
    {
        interest = GameObject.FindGameObjectWithTag("Finish");

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = interest.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
