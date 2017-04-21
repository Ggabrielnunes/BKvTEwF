using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowerBatata : NetworkBehaviour {

    public int vida;
    public int dano;
    public GameObject bala;
    public Vector2 direcao;

    [Command]
    public void CmdRecebeDano(int dano)
    {
        vida -= dano;
    }

    // Use this for initialization
    void Start () {
        vida = 5;
        dano = 1;
        bala = Resources.Load("Bala Batata") as GameObject;
    }

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Tomate")
        {
            var bullet = Instantiate(bala);
            bullet.transform.position = this.transform.position;

            direcao = new Vector2(10.0f, Colisao.GetComponent<Rigidbody2D>().transform.position.y - this.gameObject.transform.position.y);

            bullet.GetComponent<Rigidbody2D>().velocity = direcao;
        }
    }

    void Update () {
        if (vida <= 0)
            this.gameObject.SetActive(false);

    }
}
