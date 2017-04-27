using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MusicaGerencia : NetworkBehaviour
{

    public float count;
    public bool ganho;
    public GameObject canva;
    
    [Command]
    public void CmdGanho()
    {
        ganho = true;
    }
    
    void Start()
    {
        count = 5.0f;
        ganho = false;
        canva.SetActive(ganho);
    }

    void Update () {

        if (ganho)
        {
            canva.SetActive(ganho);

            count -= 1 * Time.deltaTime;
            if (count <= 0)
            {
                canva.SetActive(false);
                NetworkManager.Shutdown();
            }

        }
    }
}
