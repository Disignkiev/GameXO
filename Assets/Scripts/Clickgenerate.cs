using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



public class Clickgenerate : NetworkBehaviour  {

    public GameObject ga;
    public Transform tr;
    public itemtemp jio;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        jio = FindObjectOfType<itemtemp>();
        jio.tr = tr;
     
    }
  

    public void OnCl()
    {
       
        if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed left click.");
            if (isServer) Rpccl();
           if (isClient)
            {
                
                GameObject pla = GameObject.FindGameObjectWithTag("client");
                pla.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
                Cmdcl();

            }
            }
      


        if (Input.GetMouseButtonDown(1))
        {
            gameObject.tag = "plo";
            tr = this.gameObject.transform;
            ga = GameObject.FindGameObjectWithTag("client");
            if (ga != null)
                ga.GetComponent<playg>().strt();
            else
                Debug.Log("Error nuull ga");
            gameObject.tag = "plo2";
        }
        

        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Pressed middle click.");
                
        }
    }
    [ClientRpc]
  
    public void Rpccl()
    {
        
        GameObject gam = Resources.Load("Text") as GameObject;

       GameObject newobj = Instantiate(gam); 
   
        newobj.transform.SetParent(this.gameObject.transform);
        newobj.transform.position = this.gameObject.transform.position;
        NetworkServer.Spawn(newobj);

        Debug.Log("Spawned!2");
    }
    [Command]
    public void Cmdcl()
    {

        Rpccl();



    }

}
