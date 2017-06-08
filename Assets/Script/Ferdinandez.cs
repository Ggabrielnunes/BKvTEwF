using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferdinandez : MonoBehaviour {

    public int vida;
    public GameObject Gerencia;
    public GameObject ferdModel;
    public GameObject ferdJaim;
    public GameObject ferdWall;

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

        if (Input.GetButton("I"))
        {
            vida = 0;

        }
        if (vida <= 0)
        {
            Gerencia.SendMessage("CmdAlianca");
            ferdModel.SetActive(false);
            ferdWall.SetActive(false);
            ferdJaim.SetActive(false);
            this.enabled = false;
        }
    }
}
