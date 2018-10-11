using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playg : NetworkBehaviour {
    public Clickgenerate jio;
    // Use this for initialization
    void Start () {
        if (!isLocalPlayer) { return; }
        else
        Cmdpress();
    }
    public void strt()
    {
        if (!isLocalPlayer) { return; }
        else
      
        Cmdpressright();
}
    [Command]
    public void Cmdpressright()
    {
       
        jio = GameObject.FindGameObjectWithTag("plo").GetComponent<Clickgenerate>();
       
        Debug.Log("Pressed right click.");
        GameObject gam2 = Resources.Load("Text2") as GameObject;
        GameObject newobj2 = Instantiate(gam2);
        newobj2.transform.SetParent(jio.tr);
        newobj2.transform.position = jio.tr.transform.position;
        NetworkServer.SpawnWithClientAuthority(newobj2,gameObject);
    }
    [Command]
    public void Cmdpress()
    {
        GameObject gam2 = Resources.Load("Cube") as GameObject;
        GameObject newobj2 = Instantiate(gam2);
        NetworkServer.SpawnWithClientAuthority(newobj2, gameObject);
    }

    // Update is called once per frame
    void Update () {
        
        

    }
}
