using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using SideMiniMap;
using UnityEngine.UI;

public class Brocolis : NetworkBehaviour {

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
    public MinimapObject minimapObject;

    //Variaveis
    public float velocidade;
    public float forcaPulo;
    public float tempo;
    public float idle;
    public float startTime;

    public Animator animacao;
    public GameObject brocolis;
    public GameObject[] BarraHP;
    public GameObject oiala;
    public float firerate;
    public float lento;

    public int dano;
    public GameObject bala;
    public Vector2 speed;

    public GameObject Gerencia;
    public bool special;
    public float recarga;
    public float faleceu;
    public bool ferdinandez;
    public bool UI;
    public GameObject canva;
    public GameObject ferdinandezentra;

    public int liqui;
    public int arco;
    public int capa;
    public int seme;

    private AudioSource som;
    public AudioClip[] clip;
    private bool loja;
    public Text countGold;
    public Text countMunicao;
    public Canvas lojaItem;
    public Text valor;
    public Text valor2;
    public Text valor3;
    public Text valor4;
    public Text valor8;
    public Text timerText;
    public GameObject pontos;
    public int score;
    public RawImage skillItem;
    public RawImage skillItem2;


    [SyncVar]
    public int vida;
    [SyncVar]
    public int municao;
    [SyncVar]
    public int gold;

    [Command]
    public void CmdRecebeDano(int dano)
    {
        if (!isServer)
            return;

        vida -= dano;

        CmdUIVida();

        if (vida <= 0)
        {
            som.clip = clip[0];
            som.Play();
            RpcMorte();
            UI = true;
            vida = 10 + seme - 1;
        }

    }
    public void CmdUIVida()
    {
        for (int i = 0; i < 10; i++)
        {
            if (BarraHP[i].transform.localPosition.z < 50)
                BarraHP[i].transform.localPosition += new Vector3(0.0f, 0.0f, 1000.0f);
        }

        for (int i = 0; i < vida - seme + 1; i++)
        {
            //BarraHP[i].SetActive(true);
            if (BarraHP[i].transform.localPosition.z > -50)
                BarraHP[i].transform.localPosition += new Vector3(0.0f, 0.0f, -1000.0f);
        }
    }
    public void CmdCura(int cura)
    {
        if (!isServer)
            return;

        vida += cura;

        if (vida >= (10 + seme - 1))
        {
            vida = 10 + seme - 1;
        }

        CmdUIVida();
    }
    public void CmdMunicao(int tiro)
    {
        if (!isServer)
            return;

        municao += tiro;
        loja = true;
        if (municao >= 24)
        {
            municao = 24;
        }
    }
    public void CmdSaiu()
    {
        if (!isServer)
            return;

        loja = false;
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

    public void CmdFerdinandez()
    {
        ferdinandez = true;
    }
    public void CmdAtaca()
    {
        som.clip = clip[1];
        som.Play();

        municao--;
        dano = 2 + (liqui - 1);

        bala = Resources.Load("Bala Batata") as GameObject;
        if (oiala.transform.localPosition.x > 0)
            speed = new Vector2((8.0f + (arco - 1)), 4.0f);
        else
            speed = new Vector2((-8.0f - (arco + 1)), 4.0f);

        var bullet = Instantiate(bala);

        bullet.transform.position = this.transform.position - oiala.transform.localPosition;
        bullet.GetComponent<Rigidbody2D>().velocity = speed;
        if (special)
        {
            bullet.gameObject.tag = "EspecialBrocolis";
            bullet.GetComponent<ParticleSystem>().Play();
        }
        NetworkServer.Spawn(bullet);
    }
    public void CmdGold(int money)
    {
        if (!isServer)
            return;

        gold += money;
    }

    public void CmdMenosGold(int money)
    {
        if (!isServer)
            return;
        gold -= money;
    }

    void textcanvas()
    {
        countGold.text = "Peças: " + gold.ToString();
        
        countMunicao.text = "Municao " + municao.ToString();
       
        valor.text = "Peças: " + (liqui * 10).ToString();
       
        valor2.text = "Peças: " + (seme * 10).ToString();
        
        valor3.text = "Peças: " + (capa * 10).ToString();
       
        valor4.text = "Peças: " + (arco * 10).ToString();

        if (score == 0)
        {
            valor8.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            valor8.text = "Equilibrio: " + score.ToString();
        }
        else if (score > 0)
        {
            valor8.color = new Color(0.827f, 0.647f, 0.0f, 1.0f);
            valor8.text = "Vantagem Reino: " + score.ToString();
        }
        else
        {
            valor8.color = new Color(0.898f, 0.223f, 0.137f, 1.0f);
            valor8.text = "Vantagem Império: " + (score * -1).ToString();
        }
    }
    [ClientRpc]
    void RpcMorte()
    {
        if (isLocalPlayer)
        {
            animacao.SetBool("Morte", true);
            if (GameObject.FindGameObjectWithTag("TronoBatata") == null)
                GameObject.FindGameObjectWithTag("Controlador").SendMessage("CmdFerdinandez");
            else
                this.transform.position = GameObject.FindGameObjectWithTag("BaseBatata").transform.position;


            faleceu = 5;

        }
    }

    

    // Use this for initialization
    void Start()
    {
        liqui = 1;
        arco = 1;
        capa = 1;
        seme = 1;
        velocidade = 6.0f;
        forcaPulo = 10.0f;
        vida = 10 + seme - 1;
        municao = 24;
        tempo = 5.0f;
        idle = 0.0f;
        firerate = 0;
        lento = 0;
        gold = 0;
        special = false;
        ferdinandez = false;
        recarga = 0;
        faleceu = 0;
        UI = false;
        canva.SetActive(true);
        som = this.gameObject.GetComponent<AudioSource>();
        loja = false;
        startTime = Time.time;
        score = 0;


        lojaItem.GetComponent<Canvas>().enabled = false;

        skillItem.GetComponent<RawImage>().enabled = false;
        skillItem2.GetComponent<RawImage>().enabled = false;

        countGold.text = "Gold: " + gold.ToString();
        countMunicao.text = "Munição " + municao.ToString();
        valor.text = "Peças: " + (liqui * 10).ToString();
        valor.text = "Peças: " + (seme * 10).ToString();
        valor.text = "Peças: " + (capa * 10).ToString();
        valor.text = "Peças: " + (arco * 10).ToString();
        if(score == 0)
            valor8.text = "Equilibrio: " + score.ToString();
        else if (score > 0)
            valor8.text = "Vantagem Reino: " + score.ToString();
        else
            valor8.text = "Vantagem Império: " + (score * -1).ToString();

        CmdUIVida();

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
        minimapObject = GetComponent<MinimapObject>();
        if (isLocalPlayer)
        {
            minimapObject.SetType(TYPE.PLAYER);
            minimapObject.EnableMarker();
            return;
        }
        else
        {
            if (gameObject.tag == "Batata")
            {
                minimapObject.SetType(TYPE.ALLY);
            }
            else minimapObject.SetType(TYPE.ENEMY);

            minimapObject.EnableMarker();
        }

        canva.SetActive(false);
        GetComponentInChildren<Camera>().enabled = false;
        GetComponentInChildren<AudioListener>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (faleceu > 0)
        {
            if (!ferdinandez)
                faleceu -= 1 * Time.deltaTime;

            return;
        }

        if (UI)
        {
            UI = false;
            CmdUIVida();
        }

        pontos = GameObject.FindGameObjectWithTag("Controlador");
        //Debug.Log("iscore: " + pontos.GetComponent<MusicaGerencia>().score);
        score = (int)pontos.GetComponent<MusicaGerencia>().score;
        
        if (loja)
        {
            lojaItem.GetComponent<Canvas>().enabled = true;
            // lojaItem
        }
        else
        {
            lojaItem.GetComponent<Canvas>().enabled = false;
        }

        float t = Time.time - startTime;
        if (t > 900)
            t = 900;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        if (t % 60 > 9)
            timerText.text = minutes + ":" + seconds;
        else
            timerText.text = minutes + ":0" + seconds;

        ferdinandezentra = GameObject.FindGameObjectWithTag("FerdinandezFundo");

        brocolis = GameObject.FindGameObjectWithTag("Brocolis");
        oiala = GameObject.FindGameObjectWithTag("ModeloBrocolis");
        animacao = brocolis.GetComponent<Animator>();
        brocolis.transform.LookAt(oiala.transform);
        firerate += 1 * Time.deltaTime;
        if (recarga >= 0 && special)
        {
            special = false;
            recarga = -40;
        }
        if (recarga < 0)
            recarga += 1 * Time.deltaTime;
        
        if (lento >= 0)
        {
            lento -= 1 * Time.deltaTime;
            velocidade = 3.0f;
        }
        else
            velocidade = 6.0f;

        textcanvas();

        Movimentacao();
        
    }

    private void Movimentacao()
    {


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((velocidade + (capa - 1)) * Time.deltaTime, 0, 0);
            oiala.transform.localPosition = new Vector3(3.0f, -1.0f, -2.5f);
            idle = 0;
            animacao.SetBool("Andando", true);
            animacao.SetBool("Morte", false);

        }

        //PEGA ISSAQUI TBM
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (ignoredCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, ignoredCollider);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate((-velocidade - (capa + 1)) * Time.deltaTime, 0, 0);
            oiala.transform.localPosition = new Vector3(-3.0f, -1.0f, -2.0f);
            idle = 0;
            animacao.SetBool("Andando", true);
            animacao.SetBool("Morte", false);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(this.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                som.clip = clip[2];
                som.Play();
            }
            transform.Translate(0, 8 * Time.deltaTime + 0.1f, 0);
            idle = 0;
            animacao.SetBool("Pulo", true);
            animacao.SetBool("Morte", false);

        }

        if (Input.GetButton("B"))
        {
            if (recarga >= 0 && !special)
            {
                special = true;
                recarga = -10;
            }
        }
        if (Input.GetButton("P"))
        {
            ferdinandezentra.GetComponent<FerdinandezEntrada>().enabled = true;
        }
        if (Input.GetButton("O"))
        {
            Gerencia = GameObject.FindGameObjectWithTag("Controlador");
            CmdGold(5);
            Gerencia.SendMessage("CmdScoreJ", 50);

        }
        if (Input.GetButton("I"))
        {
            Gerencia = GameObject.FindGameObjectWithTag("Controlador");
            Gerencia.SendMessage("CmdScoreW", 50);

        }

        if (Input.GetKey(KeyCode.Space) && firerate >= 1 && municao > 0)
        {
            firerate = 0;

            CmdAtaca();

            idle = 0;
            animacao.SetBool("Ataque", true);
            animacao.SetBool("Morte", false);
        }

        if (Input.GetButtonDown("1") && loja)
        {
            
            if(gold >= 10*liqui)
            {
                gold -= 10 * liqui;
                liqui++;
            }
            skillItem.GetComponent<RawImage>().enabled = true;
        }
        if (Input.GetButtonDown("2") && loja)
        {

            if (gold >= 10 * seme)
            {
                gold -= 10 * seme;
                seme++;
                CmdCura(2);
            }
        }
        if (Input.GetButtonDown("3") && loja)
        {

            if (gold >= 10 * capa)
            {
                CmdMenosGold(10 * capa);
                capa++;
            }
            skillItem2.GetComponent<RawImage>().enabled = true;

        }
        if (Input.GetButtonDown("4") && loja)
        {

            if (gold >= 10 * arco)
            {
                gold -= 10 * arco;
                arco++;
            }
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