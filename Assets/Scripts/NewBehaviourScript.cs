using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Camera camer;
    // Use this for initialization
    void Start () {
        if (camer == null)
            camer = GameObject.FindGameObjectWithTag("cam").GetComponent<Camera>() as Camera; ;
    }

  
    

  
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = camer.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    string h = hit.collider.gameObject.name;
                    Debug.Log("hello"+h);
                }
            }
        }
    }
}
