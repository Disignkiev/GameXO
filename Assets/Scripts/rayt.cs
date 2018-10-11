using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;

public class rayt : NetworkBehaviour {
    [SyncVar]
    
    public GameObject data=null;
    public GameObject newpbj=null;
    public int win2 = 0;
    public int win1 = 0;
    public GameObject[] gafv = new GameObject [9];
    private void Start()
    {
        if (hasAuthority)
        {
            this.gameObject.tag = "server";
        }
        gafv = GameObject.FindGameObjectsWithTag("call").OrderBy(go => go.name).ToArray(); 
    }
    [ClientRpc]
    public void RpcSravnn(int a, int b, int c )
    {

        if ((gafv[a].transform.childCount != 0) && (gafv[b].transform.childCount != 0) && (gafv[c].transform.childCount != 0))
        {
            if ((gafv[a].transform.GetChild(0).tag == "X") && (gafv[b].transform.GetChild(0).tag == "X") && (gafv[c].transform.GetChild(0).tag == "X"))
            { Debug.Log("win"); gafv[a].GetComponent < Image >().color= Color.cyan; gafv[b].GetComponent<Image>().color = Color.cyan; gafv[c].GetComponent<Image>().color = Color.cyan;

                GameObject gj = GameObject.FindGameObjectWithTag("win1");
                win1++;
                gj.GetComponent<Text>().text = win1.ToString();
                StartCoroutine(StartCountdown());
            }

           
        }
    }
   [Command]
   public void CmdSravnn2(int a, int b, int c)
    {
        RpcSravnn2(a, b, c);
    }
    [ClientRpc]
    public void RpcSravnn2(int a, int b, int c)
    {

        if ((gafv[a].transform.childCount != 0) && (gafv[b].transform.childCount != 0) && (gafv[c].transform.childCount != 0))
        {
            if ((gafv[a].transform.GetChild(0).tag == "O") && (gafv[b].transform.GetChild(0).tag == "O") && (gafv[c].transform.GetChild(0).tag == "O"))
            {
                GameObject gj = GameObject.FindGameObjectWithTag("win2");
                win2++;
                gj.GetComponent<Text>().text = win2.ToString();

                Debug.Log("win"); gafv[a].GetComponent<Image>().color = Color.magenta; gafv[b].GetComponent<Image>().color = Color.magenta; gafv[c].GetComponent<Image>().color = Color.magenta;

                StartCoroutine(StartCountdown());
            }


        }
    }
    [Command]
    public void Cmdrestartlevel()
    {
        Rpcrestartlevel();
    }
    [ClientRpc]
    public void Rpcrestartlevel()
    {
        GameObject[] goz = GameObject.FindGameObjectsWithTag("X");
        GameObject[] go2 = GameObject.FindGameObjectsWithTag("O");
        GameObject[] go3 = GameObject.FindGameObjectsWithTag("call").OrderBy(go => go.name).ToArray(); 
        for (int i = 0; i < goz.Length;i++) 
        {
            Destroy(goz[i]);
                        
        }
        for (int i = 0; i < go2.Length; i++)
        {
            Destroy(go2[i]);

        }
        for (int i = 0; i < go3.Length; i++)
        {
           go3[i].GetComponent<Image>().color = Color.white;

        }
    }
    public void Update()
     
    {
        if (!isLocalPlayer)
        {
            return;
        }
        else
        {
       
      
        // Debug.Log(gafv[1].name);



        
            if (Input.GetMouseButtonDown(0))
            {
              data = PointerRaycast(Input.mousePosition); // пускаем луч

                if ((data != null)&&(data.tag=="call"))
                {

                   
                    
                    Debug.Log(data.transform);
                    Debug.Log("dataover comand ="+data);// объект куда попал луч



                    if (isServer)
                    {
                        Cmdsf(data);
                        RpcSravnn(0, 1, 2);
                        RpcSravnn(3, 4, 5);
                        RpcSravnn(6, 7, 8);
                        RpcSravnn(0, 3, 6);
                        RpcSravnn(1, 4, 7);
                        RpcSravnn(2, 5, 8);
                        RpcSravnn(0, 4, 8);
                        RpcSravnn(2, 4, 6);

                        
                    }
                    if (!isServer)
                    {
                        Cmdsf2(data);

                        CmdSravnn2(0, 1, 2);
                        CmdSravnn2(3, 4, 5);
                        CmdSravnn2(6, 7, 8);
                        CmdSravnn2(0, 3, 6);
                        CmdSravnn2(1, 4, 7);
                        CmdSravnn2(2, 5, 8);
                        CmdSravnn2(0, 4, 8);
                        CmdSravnn2(2, 4, 6);
                    }
                    data = null;
                }
                if ((data != null) && (data.tag == "Newtag"))
                {
                    Debug.Log("databtncomand =" + data);
                    StartCoroutine(StartCountdown());
                    data = null;
                }
            }
        }
	}

    	GameObject PointerRaycast(Vector2 position)
{
    PointerEventData pointerData = new PointerEventData(EventSystem.current);
    List<RaycastResult> resultsData = new List<RaycastResult>();
    pointerData.position = position;
    EventSystem.current.RaycastAll(pointerData, resultsData);

    if (resultsData.Count > 0)
    {
        return resultsData[0].gameObject;
    }

    return null;
}
   [Command]
    public void Cmdsf (GameObject uhj){
      
        Rpccl(uhj);
} 
    
    [ClientRpc]
    void Rpccl(GameObject uhj)
    {
       
            GameObject gam = Resources.Load("Text") as GameObject;
            GameObject newobj = Instantiate(gam);
            newobj.transform.SetParent(uhj.transform);
            newobj.GetComponent<RectTransform>().position = uhj.GetComponent<RectTransform>().position;
        newobj.tag = "X";
        NetworkServer.Spawn(newobj);
      
    }
    [Command]
    public void Cmdsf2(GameObject uhj)
    {

        Rpccl2(uhj);
    }

    [ClientRpc]
    void Rpccl2(GameObject uhj)
    {

        GameObject gam = Resources.Load("Text2") as GameObject;
        GameObject newobj = Instantiate(gam);
        newobj.transform.SetParent(uhj.transform);
        newobj.GetComponent<RectTransform>().position = uhj.GetComponent<RectTransform>().position;
        newobj.tag = "O";
        NetworkServer.Spawn(newobj);

    }

    
    public IEnumerator StartCountdown()
    {
        float currCountdownValue=2;
        


        while (currCountdownValue > 0)
        {
            // Debug.Log("Countdown: " + currCountdownValue);

            yield return new WaitForSeconds(1);
           
            currCountdownValue--;
        }
        if (isServer) Rpcrestartlevel();
        else if (!isServer)
        {
            Cmdrestartlevel();
        }


    }
    public void Buttoncl()
    {
        StartCoroutine(StartCountdown());
    }

   

}