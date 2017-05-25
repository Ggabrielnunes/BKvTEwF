using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowerTomate : NetworkBehaviour {

    public int vida;
    public int dano;
    public GameObject bala;
    public GameObject inimigo;
    public GameObject msmalvo;
    public Vector2 direcao;
    public float firerate;
    public float fireratemax;
    
    float direcaoX;

    [Command]
    public void CmdRecebeDano(int dano)
    {
        vida -= dano;
    }
    public void CmdFerdinandez()
    { }
    public void CmdAtira(GameObject alvo)
    {
        inimigo = alvo;
    }

    void Start () {
        vida = 5;
        dano = 1;
        bala = Resources.Load("Bala Torre Tomate") as GameObject;
        firerate = 2;
        fireratemax = 2;
        msmalvo = null;
    }
    


    // Update is called once per frame
    void Update ()
    {
        if (vida <= 0)
            this.gameObject.SetActive(false);

        if (firerate < 2)
        {
            firerate += 1 * Time.deltaTime;
        }
        if (inimigo != null && firerate >= fireratemax)
        {
            if (inimigo == msmalvo)
            {
                fireratemax = fireratemax / 1.4f;
                if (fireratemax <= 0.3f)
                    fireratemax = 0.3f;
            }
            else
            {
                msmalvo = inimigo;
                fireratemax = 2;
            }

            firerate = 0;

            if (this.transform.position.x - inimigo.transform.position.x > 20)
                return;
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
