using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2Tile : MonoBehaviour
{
    private GameObject player;

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
        player.transform.position = new Vector3(transform.position.x,
            transform.position.y + transform.localScale.y / 2
            + player.transform.localScale.y + 0.25f, transform.position.z);

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
