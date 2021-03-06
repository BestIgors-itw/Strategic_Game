﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammates : MonoBehaviour
{
    public List<GameObject> teammates;

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

            if (teammates.Count == 0)
            {
                Debug.Log("Defeat");
                Time.timeScale = 0.1f;
                Application.Quit();
            }
        }
    }
}
