using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    private GameObject interest;

    // Start is called before the first frame update
    void Start()
    {
        interest = GameObject.FindGameObjectWithTag("Finish");

        StartCoroutine(movement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator movement()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            transform.position = new Vector3(interest.transform.position.x,
                interest.transform.position.y + (interest.transform.localScale.y / 2)
                + transform.localScale.y + 0.25f, interest.transform.position.z);                        
        }
    }
}
