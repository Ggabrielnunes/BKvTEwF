using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Wallyson : NetworkBehaviour
{

    public int vida;
    public GameObject inimigo;

    [Command]
    public void CmdRecebeDano(int dano)
    {
        vida -= dano;
    }

    void Start()
    {
        vida = 10;
    }

    void Update()
    {
        inimigo = GameObject.FindGameObjectWithTag("Controlador");

        if (vida <= 0)
        {
            inimigo.SendMessage("CmdGanho");
            this.gameObject.SetActive(false);
        }
    }
}
