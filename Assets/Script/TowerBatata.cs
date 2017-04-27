﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowerBatata : NetworkBehaviour {

    public int vida;
    public int dano;
    public GameObject bala;
    public GameObject inimigo;
    public Vector2 direcao;
    public float firerate;

    int entro = 0;
    float direcaoX;

    [Command]
    public void CmdRecebeDano(int dano)
    {
        vida -= dano;
    }
    public void CmdAtira(int tadentro)
    {
        if (tadentro == 1)
            entro = 1;
        else if (tadentro == 2)
            entro = 2;
        else
            entro = 1;
    }

    // Use this for initialization
    void Start () {
        vida = 5;
        dano = 1;
        bala = Resources.Load("Bala Torre Batata") as GameObject;
    }

    void Update()
    {
        if (vida <= 0)
            this.gameObject.SetActive(false);

        firerate += 1 * Time.deltaTime;

        if (entro != 0 && firerate >= 1)
        {
            firerate = 0;

            if (entro == 1)
                inimigo = GameObject.FindGameObjectWithTag("Tomate");
            else
                inimigo = GameObject.FindGameObjectWithTag("MinionTE");
            
            var bullet = Instantiate(bala);
            bullet.transform.position = this.transform.position;
            if (inimigo.transform.position.x - this.transform.position.x > 0)
                direcaoX = 10.0f;
            else
                direcaoX = -10.0f;
            direcao = new Vector2(direcaoX, inimigo.GetComponent<Rigidbody2D>().transform.position.y - this.gameObject.transform.position.y);

            bullet.GetComponent<Rigidbody2D>().velocity = direcao;
        }
    }
}