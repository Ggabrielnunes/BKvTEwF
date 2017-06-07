using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaTomate: NetworkBehaviour {
    bool vivo;
    public GameObject Banana;
    private float time;

    void Start()
    {
        vivo = true;
    }

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (vivo)
        {
            if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "TorreBatata" || Colisao.gameObject.tag == "MinionBK" || Colisao.gameObject.tag == "TronoBatata")
            {
                Colisao.SendMessage("CmdRecebeDano", 2);
                if (this.gameObject.tag == ("BalaBanana"))
                    Banana.SendMessage("CmdMunicao", 1);
                NetworkServer.Destroy(this.gameObject);
            }

            if (Colisao.gameObject.tag == "Plataforma" || Colisao.gameObject.layer == 9)
            {
                vivo = false;
            }
        }
        else
        {
            if (Colisao.gameObject.tag == "Batata")
                {
                    Colisao.SendMessage("CmdSlow");
                    Destroy(this.gameObject);
                }
            else if (Colisao.gameObject.tag == "TorreBatata" || Colisao.gameObject.tag == "MinionBK" || Colisao.gameObject.tag == "TronoBatata")
                Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (!vivo)
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (time < 25)
        {
            time += 1 * Time.deltaTime;
        }
        else
            NetworkServer.Destroy(this.gameObject);
    }
}
