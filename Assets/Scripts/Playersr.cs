using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Playersr : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
        
        if ((isClient) && (!hasAuthority))
        { gameObject.tag = "client"; }
        if (isLocalPlayer)
        {
            gameObject.tag = "lok";
            GameObject assignAuthorityObj = GameObject.FindGameObjectWithTag("client");
            assignAuthorityObj.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
