using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    public IEnumerator Timer(float i)
    {
        yield return new WaitForSeconds(i);
        velocidade = 6.0f;
    }

    //LEO COPIA SAPORRA
    public DetectIfGrounded triggerDown;
    public DetectIfPassed triggerUp;
    public Collider2D ignoredCollider;
    public Collider2D playerCollider;

    //Variaveis
    public float velocidade;
    public float forcaPulo;
    public float tempo;
    public float idle;

    public Animator animacao;
    public GameObject brocolis;
    public GameObject oiala;
    public float firerate;
    public float lento;

    public int dano;
    public GameObject bala;
    public Vector2 speed;
    

    [SyncVar]
    public int vida;

    [Command]
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
    public void CmdCura(int cura)
    {
        if (!isServer)
            return;

        vida += cura;

        if (vida >= 10)
        {
            vida = 10;
        }
    }
    public void CmdSlow()
    {
        if (!isServer)
            return;

        if (lento < 3)
        {
            lento = 3;
        }
    }
    public void CmdAtaca()
    {
        dano = 2;

        bala = Resources.Load("Bala Batata") as GameObject;
        if (oiala.transform.localPosition.x > 0)
            speed = new Vector2(8.0f, 4.0f);
        else
            speed = new Vector2(-8.0f, 4.0f);

        var bullet = Instantiate(bala);

        bullet.transform.position = this.transform.position - oiala.transform.localPosition;
        bullet.GetComponent<Rigidbody2D>().velocity = speed;

        NetworkServer.Spawn(bullet);
    }

    [ClientRpc]
    void RpcMorte()
    {
        if (isLocalPlayer)
        {
            animacao.SetBool("Morte", true);
            this.transform.position = GameObject.FindGameObjectWithTag("BaseBatata").transform.position;
            
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
        firerate = 0;
        lento = 0;

        Debug.Log("DFS");
        //LEO COPIA ISSO
        triggerDown.onDetectGround += delegate (Collider2D p_collider)
        {
            ignoredCollider = p_collider;
            Debug.Log("T");
        };

        triggerUp.onDetectPassed += delegate (Collider2D p_collider)
        {
            if (p_collider == ignoredCollider)
            {
                Physics2D.IgnoreCollision(p_collider, playerCollider, false);
                Debug.Log("TTT");
            }
        };
        //SAPORA É NECESSÁRIA

        if (isLocalPlayer)
            return;


        GetComponentInChildren<Camera>().enabled = false;
        GetComponentInChildren<AudioListener>().enabled = false;
        GetComponentInChildren<GameObject>().SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;


        brocolis = GameObject.FindGameObjectWithTag("Brocolis");
        oiala = GameObject.FindGameObjectWithTag("oiala");
        animacao = brocolis.GetComponent<Animator>();
        brocolis.transform.LookAt(oiala.transform);
        firerate += 1 * Time.deltaTime;
        if (lento >= 0)
        {
            lento -= 1 * Time.deltaTime;
            velocidade = 3.0f;
        }
        else
            velocidade = 6.0f;
        Movimentacao();
        
    }

    private void Movimentacao()
    {

        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(velocidade * Time.deltaTime, 0, 0);
            oiala.transform.localPosition = new Vector3(3.0f, -1.0f, -2.5f);
            idle = 0;
            animacao.SetBool("Andando", true);
            animacao.SetBool("Morte", false);

        }

        //PEGA ISSAQUI TBM
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(ignoredCollider!=null)
            {
                Physics2D.IgnoreCollision(playerCollider, ignoredCollider);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(-velocidade * Time.deltaTime, 0, 0);
            oiala.transform.localPosition = new Vector3(-3.0f, -1.0f, -2.0f);
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
            velocidade = 12.0f;
            StartCoroutine(Timer(tempo));

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