using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player2 : NetworkBehaviour
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


    [ClientRpc]
    void RpcMorte()
    {
        if (isLocalPlayer)
        {
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

        Movimentacao();
        
    }

    private void Movimentacao()
    {

        if (Input.GetKey(KeyCode.RightArrow)) 
       {
            transform.Translate(velocidade * Time.deltaTime, 0, 0);
       }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(-velocidade * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.Translate(0, velocidade * Time.deltaTime + 0.1f, 0);

        }
        
        if (Input.GetButton("B"))
        {
            transform.position = GameObject.FindGameObjectWithTag("Teleporte").transform.position;
        }
    }

    private void NegarColisao()
    {

    }
}

