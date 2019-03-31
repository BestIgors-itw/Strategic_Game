using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move2Tile : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //player.transform.position = new Vector3(transform.position.x,
        //    transform.position.y + transform.localScale.y / 2
        //    + player.transform.localScale.y + 0.25f, transform.position.z);

        agent = player.GetComponent<NavMeshAgent>();
        agent.destination = transform.position;
    }
}
