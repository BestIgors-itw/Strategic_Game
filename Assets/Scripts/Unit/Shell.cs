using UnityEngine;

public class Shell : MonoBehaviour
{
    public float speed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = speed * transform.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
