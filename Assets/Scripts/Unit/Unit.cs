using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    protected float aimY;
    protected float aimZ;

    protected GameObject gun = null;
    protected GameObject target = null;
    protected GameObject destination = null;
    protected NavMeshAgent agent;

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

    protected void MoveTo(GameObject target)
    {
        agent.destination = target.transform.position;
    }
}
