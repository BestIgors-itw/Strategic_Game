﻿using System.Collections;
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

        //        destination = GameObject.FindGameObjectWithTag("Finish").transform;

        targets = new List<GameObject>();

        string[] tags = new string[] { "Teammate", "Strategic Object" };
        StartCoroutine(ChooseTarget(tags));
        StartCoroutine(Fire());
        
//        MoveTo(destination);
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }
}
