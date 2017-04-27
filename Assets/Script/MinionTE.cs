using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MinionTE : NetworkBehaviour
{

    public float idle;
    public Vector2 velocidade;

    public Animator animacao;
    public GameObject modelo;
    public float firerate;
    public int dano;

    public int vida;

    [Command]
    public void CmdRecebeDano(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    public void CmdPorNarnia(GameObject inimigo)
    {
        if (firerate >= 2)
        {
            inimigo.SendMessage("CmdRecebeDano", 1);
            firerate = 0;
        }
    }

    /*void OnCollisionEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "TorreBatata" || Colisao.gameObject.tag == "MinionBK")
        {

            animacao.SetBool("Ataque", true);
            idle = 0;
            Colisao.SendMessage("CmdRecebeDano", 1);
        }
    }*/



    // Use this for initialization
    void Start()
    {
        velocidade = new Vector2(-5.0f, 0.0f);
        vida = 2;
        idle = 0.0f;
        firerate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        firerate += 1 * Time.deltaTime;

        Movimentacao();

    }

    private void Movimentacao()
    {
        GetComponent<Rigidbody2D>().velocity = velocidade;

        if (idle >= 0.1)
        {
            animacao.SetBool("Ataque", false);
        }
        else
            idle += 1 * Time.deltaTime;
    }

}
