using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public float health;

    public GameObject shell;

    protected float aimY;
    protected float aimZ;

    protected GameObject gun = null;
    protected GameObject target = null;
    protected GameObject[] targets = null;
    protected GameObject destination = null;

    protected NavMeshAgent agent;

    protected ObjectInfo info;

    protected Transform shells = null;

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

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shell")
        {
            health -= collision.gameObject.GetComponent<Shell>().damage;

            if (health < 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
