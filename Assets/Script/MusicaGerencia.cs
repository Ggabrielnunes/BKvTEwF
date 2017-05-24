using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MusicaGerencia : NetworkBehaviour
{

    public float count;
    public bool ganho;
    public int ferdinandez;
    public GameObject canva;
    public GameObject canvaF;

    [Command]
    public void CmdGanho()
    {
        if(ferdinandez == 0)
            ganho = true;
    }
    public void CmdFerdinandez()
    {
        ferdinandez ++;
    }

    void Start()
    {
        count = 5.0f;
        ganho = false;
        ferdinandez = 0;
        canva.SetActive(ganho);
        //canvaF.SetActive(false);
    }

    void Update () {

        if (ferdinandez >= 3)
        {
            canva.SetActive(true);

            count -= 1 * Time.deltaTime;
            if (count <= 0)
            {
                canva.SetActive(false);
                NetworkManager.Shutdown();
            }

        }

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
