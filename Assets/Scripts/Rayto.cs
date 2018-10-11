using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayto : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var up = transform.TransformDirection(Vector3.up);
        RaycastHit hit;
        Debug.DrawRay(transform.position, -up * 2, Color.green);

        if (Physics.Raycast(transform.position, -up, out hit, 2))
        {

            Debug.Log("HIT");

            if (hit.collider.gameObject.name == "floor")
            {
                Destroy(GetComponent("Rigidbody"));
            }
        }

    }
}
