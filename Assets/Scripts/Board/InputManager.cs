using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{
    private GameObject selected = null;

    private ObjectInfo selectedInfo = null;

    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);            

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Teammate")
                {
                    selected = hit.collider.gameObject;
                    selectedInfo = selected.GetComponent<ObjectInfo>();
                    
                    selectedInfo.isSelected = true;
                }
                else
                {
                    selected = null;                    
                }
            }
        }        
    }
}
