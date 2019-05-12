using System.Collections.Generic;
using UnityEngine;

public class StrategicObject : MonoBehaviour
{
    public float health;
    List<GameObject> stratObjs;

    void Start()
    {
        stratObjs = gameObject.GetComponentInParent<Environment>().strategicObjects;                                  
        stratObjs.Add(gameObject);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            health -= collision.gameObject.GetComponent<Shell>().damage;

            if (health <= 0)
            {                
                Destroy(gameObject, 0.5f);
                stratObjs.Remove(gameObject);
            }
        }
    }
}
