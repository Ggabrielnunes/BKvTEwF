using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Jaiminho : NetworkBehaviour
{

    public int vida;
    public GameObject inimigo;
    public bool ferdinandez;

    [Command]
    public void CmdRecebeDano(int dano)
    {
        vida -= dano;
    }
    public void CmdFerdinandez()
    {
        ferdinandez = true;
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
            if (ferdinandez)
                inimigo.SendMessage("CmdFerdinandez");
            else
                inimigo.SendMessage("CmdGanho");

            this.gameObject.SetActive(false);
        }
    }
}