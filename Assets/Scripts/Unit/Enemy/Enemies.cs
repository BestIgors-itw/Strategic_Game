using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Check());
    }

    protected IEnumerator Check()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (enemies.Count == 0)
            {
                Debug.Log("Victory");
                Time.timeScale = 0.1f;
                Application.Quit();
            }
        }
    }
}
