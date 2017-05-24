using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Banana : NetworkBehaviour
{
    public IEnumerator Timer(float i)
    {
        yield return new WaitForSeconds(i);
        velocidade = 6.0f;
    }
    //Variaveis
    public float velocidade;
    public float forcaPulo;
    public float tempo;
    public float idle;

    public Animator animacao;
    public GameObject banana;
    public GameObject oiala;
    public float firerate;

    public int dano;
    public GameObject bala;
    public Vector2 speed;

    public bool ferdinandez;
    public float morto;

    [SyncVar]
    public int vida;

    [Command]
    public void CmdFerdinandez()
    {
        ferdinandez = true;
    }
    public void CmdRecebeDano(int dano)
    {
        if (!isServer)
            return;

        vida -= dano;

        if (vida <= 0)
        {
            RpcMorte();
            vida = 10;
        }
    }
    public void CmdAtaca()
    {
        dano = 2;

        bala = Resources.Load("Bala Tomate") as GameObject;
        if (oiala.transform.localPosition.x < 0)
            speed = new Vector2(7.0f, 9.0f);
        else
            speed = new Vector2(-7.0f, 9.0f);

        var bullet = Instantiate(bala);

        bullet.transform.position = this.transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = speed;

        NetworkServer.Spawn(bullet);
    }

    [ClientRpc]
    void RpcMorte()
    {
        if (isLocalPlayer)
        {
            animacao.SetBool("Morte", true);
            morto = 5;
            if (!ferdinandez)
            transform.position = GameObject.FindGameObjectWithTag("BaseTomate").transform.position;
            
        }  
    }

    // Use this for initialization
    void Start()
    {
        velocidade = 6.0f;
        forcaPulo = 10.0f;
        vida = 10;
        tempo = 5.0f;
        idle = 0.0f;
        firerate = 0.0f;
        morto = 0.0f;
        ferdinandez = false;

        if (isLocalPlayer)
            return;

        GetComponentInChildren<Camera>().enabled = false;
        GetComponentInChildren<AudioListener>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        if (morto > 0)
        {
            if (!ferdinandez)
                morto -= 1 * Time.deltaTime;
            return;
        }

        banana = GameObject.FindGameObjectWithTag("Banana");
        oiala = GameObject.FindGameObjectWithTag("oiala");
        animacao = banana.GetComponent<Animator>();
        banana.transform.LookAt(oiala.transform);
        firerate += 1 * Time.deltaTime;


        Movimentacao();
        
    }

    private void Movimentacao()
    {

        if (Input.GetKey(KeyCode.RightArrow)) 
       {
            transform.Translate(velocidade * Time.deltaTime, 0, 0);
            oiala.transform.localPosition = new Vector3(-3.0f, 0.0f, 2.5f);
            idle = 0;
            animacao.SetBool("Andando", true);
            animacao.SetBool("Morte", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(-velocidade * Time.deltaTime, 0, 0);
            oiala.transform.localPosition = new Vector3(3.0f, 0.0f, 2.0f);
            idle = 0;
            animacao.SetBool("Andando", true);
            animacao.SetBool("Morte", false);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.Translate(0, velocidade * Time.deltaTime + 0.1f, 0);
            idle = 0;
            animacao.SetBool("Pulo", true);
            animacao.SetBool("Morte", false);

        }
        
        if (Input.GetButton("B"))
        {
            transform.position = GameObject.FindGameObjectWithTag("Teleporte").transform.position;
        }

        if (Input.GetKey(KeyCode.Space) && firerate >= 1)
        {
            firerate = 0;

            CmdAtaca();

            idle = 0;
            animacao.SetBool("Ataque", true);
            animacao.SetBool("Morte", false);
        }
        if (idle >= 0.1)
        {
            animacao.SetBool("Andando", false);
            animacao.SetBool("Ataque", false);
            animacao.SetBool("Pulo", false);
        }
        else
            idle += 1 * Time.deltaTime;
    }

    private void NegarColisao()
    {

    }
}

