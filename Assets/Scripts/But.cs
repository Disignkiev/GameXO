using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class But : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseDown()
    {
      GameObject go= GameObject.FindGameObjectWithTag("server");
        rayt src = go.GetComponent<rayt>();
        src.Buttoncl();
;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
