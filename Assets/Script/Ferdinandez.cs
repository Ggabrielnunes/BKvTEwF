using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferdinandez : MonoBehaviour {

    public int vida;
    public GameObject Gerencia;

    public void CmdRecebeDano(int dano)
    {
        vida -= dano;
    }

    void Start()
    {
        vida = 20;
    }

    void Update()
    {
        Gerencia = GameObject.FindGameObjectWithTag("Controlador");

        if (vida <= 0)
        {
            Gerencia.SendMessage("CmdAlianca");
            this.gameObject.SetActive(false);
        }
    }
}
