using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strategic_Object : MonoBehaviour
{
    public float health;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            health -= collision.gameObject.GetComponent<Shell>().damage;

            if (health <= 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
