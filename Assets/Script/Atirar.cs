using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Atirar : NetworkBehaviour {

    public float tempo = 10;
    public GameObject MinionBK;
    public GameObject MinionBKTop;
    public GameObject MinionTE;
    public GameObject MinionTETop;
    public GameObject selecaoUI;
    private void vai()
    {
        tempo = 10.0f;
        
            MinionBK = Resources.Load("MinionBKDown") as GameObject;
            MinionTE = Resources.Load("MinionTEDown") as GameObject;
            MinionBKTop = Resources.Load("MinionBKTop") as GameObject;
            MinionTETop = Resources.Load("MinionTETop") as GameObject;

        var Gera = Instantiate(MinionBK);
        Gera.transform.position = GameObject.FindGameObjectWithTag("BaseBatata").transform.position;

        Gera = Instantiate(MinionTE);
        Gera.transform.position = GameObject.FindGameObjectWithTag("BaseTomate").transform.position;

        Gera = Instantiate(MinionBKTop);
        Gera.transform.position = GameObject.FindGameObjectWithTag("BaseBatata").transform.position;

        Gera = Instantiate(MinionTETop);
        Gera.transform.position = GameObject.FindGameObjectWithTag("BaseTomate").transform.position;



        NetworkServer.Spawn(MinionBK);
        NetworkServer.Spawn(MinionTE);

        NetworkServer.Spawn(MinionBKTop);
        NetworkServer.Spawn(MinionTETop);
    }

   void Update()
    {
        //selecaoUI = GameObject.FindGameObjectWithTag("PersonagensUI");
        //selecaoUI.GetComponent<Canvas>().enabled = false;

        if (tempo <= 0)
        {
            vai();
            vai();
            vai();
        }
        else
            tempo -= 1 * Time.deltaTime;

        if (GameObject.FindGameObjectWithTag("Ferdinandez") != null)
            this.gameObject.SetActive(false);
    }
}
