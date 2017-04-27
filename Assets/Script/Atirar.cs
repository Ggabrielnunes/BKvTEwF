using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Atirar : NetworkBehaviour {

    public float tempo = 10;
    public GameObject MinionBK;
    public GameObject MinionTE;

    private void vai()
    {
        tempo = 10.0f;
        
            MinionBK = Resources.Load("MinionBK") as GameObject;
            MinionTE = Resources.Load("MinionTE") as GameObject;
            
        var Gera = Instantiate(MinionBK);
        Gera.transform.position = GameObject.FindGameObjectWithTag("BaseBatata").transform.position;

        Gera = Instantiate(MinionTE);
        Gera.transform.position = GameObject.FindGameObjectWithTag("BaseTomate").transform.position;

        NetworkServer.Spawn(MinionBK);
        NetworkServer.Spawn(MinionTE);
    }

   void Update()
    {
        if (tempo <= 0)
            vai();
        else
            tempo -= 1 * Time.deltaTime;

        
    }
}
