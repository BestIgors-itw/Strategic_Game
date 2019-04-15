using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_move : MonoBehaviour
{
    public float radius;

    private float angle = 0f;
    private float speed = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle = angle + Input.GetAxis("Horizontal") * speed;
        
        angle = angle % (Mathf.PI * 2);

        var x = Mathf.Cos(angle) * radius;
        var z = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, transform.position.y, z);
        transform.rotation = Quaternion.Euler(35, -(angle * 180 / Mathf.PI) - 90, 0);
    }
}
