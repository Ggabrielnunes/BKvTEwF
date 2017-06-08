using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaBatata : NetworkBehaviour {
    bool vivo;
    public float enoix;
    private float time;

    void Start()
    {
        vivo = true;
        enoix = 0;
        time = 0;
    }

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (vivo)
        {
            if (this.gameObject.tag != "EspecialBrocolis")
            {
                if (Colisao.gameObject.tag == "Ferdinandez" || Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "TorreTomate" || Colisao.gameObject.tag == "MinionTE" || Colisao.gameObject.tag == "TronoTomate")
                {
                    Colisao.SendMessage("CmdRecebeDano", 2);
                    NetworkServer.Destroy(this.gameObject);
                }
            }
            else
            {
                if (Colisao.gameObject.tag == "Ferdinandez" || Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "TorreTomate" || Colisao.gameObject.tag == "MinionTE" || Colisao.gameObject.tag == "TronoTomate")
                {
                    Colisao.SendMessage("CmdRecebeDano", 1);
                    NetworkServer.Destroy(this.gameObject);
                }
                if (Colisao.gameObject.tag == "Batata" && enoix >= 0.7)
                {
                    Colisao.SendMessage("CmdCura", 3);
                    NetworkServer.Destroy(this.gameObject);
                }
            }

            if (Colisao.gameObject.tag == "Plataforma" || Colisao.gameObject.layer == 9)
            {
                vivo = false;
            }
        }
        else
        {
            if (this.gameObject.tag == "EspecialBrocolis")
            {
                if (Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "TorreTomate" || Colisao.gameObject.tag == "MinionTE" || Colisao.gameObject.tag == "TronoTomate")
                {
                    Colisao.SendMessage("CmdRecebeDano", 1);
                    NetworkServer.Destroy(this.gameObject);
                }
                if (Colisao.gameObject.tag == "Batata" && enoix >= 0.7)
                {
                    Colisao.SendMessage("CmdCura", 3);
                    NetworkServer.Destroy(this.gameObject);
                }
            }
            else if (Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "TorreTomate" || Colisao.gameObject.tag == "MinionTE" || Colisao.gameObject.tag == "TronoTomate")
                NetworkServer.Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (enoix < 0.7)
            enoix += 1 * Time.deltaTime;

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
