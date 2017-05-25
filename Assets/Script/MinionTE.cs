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
    public GameObject Gerencia;
    public GameObject Jogador;
    public GameObject Jogador2;
    public float firerate;
    public int dano;

    public int vida;

    public bool area;
    [Command]
    public void CmdRecebeDano(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            if (area)
            {
                if (Jogador != null)
                {
                    Jogador.SendMessage("CmdGold", 5);
                    Gerencia.SendMessage("CmdScoreJ", 50);
                }
                if (Jogador2 != null)
                {
                    Jogador.SendMessage("CmdGold", 5);
                    Gerencia.SendMessage("CmdScoreJ", 50);
                }
            }

            Destroy(this.gameObject);
        }

    }
    public void CmdGoldIn(GameObject playerIn)
    {
        if (Jogador == null)
            Jogador = playerIn;
        if (Jogador2 == null)
            Jogador2 = playerIn;

        area = true;
        
    }
    public void CmdGoldOut(GameObject playerOut)
    {
        if (Jogador == playerOut)
            Jogador = null;
        if (Jogador2 == playerOut)
            Jogador2 = null;

        if (Jogador == null && Jogador2 == null)
            area = false;
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

    public void ChangeSpeed(float speed)
    {
        if (speed > 0)
            speed = speed * -1;
        velocidade = new Vector2(speed, 0.0f);
    }

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
        Gerencia = GameObject.FindGameObjectWithTag("Controlador");
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
