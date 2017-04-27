using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaTomate: NetworkBehaviour {
    float origem;
    public float distancia;
    bool vivo;


    void Start()
    {
        vivo = true;
        distancia = 0;
    }

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (vivo)
        {
            if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "TorreBatata" || Colisao.gameObject.tag == "MinionBK")
            {
                Colisao.SendMessage("CmdRecebeDano", 2);
                NetworkServer.Destroy(this.gameObject);
            }

            if (Colisao.gameObject.tag == "Plataforma")
            {
                vivo = false;
            }
        }
        else
        {
            if (this.gameObject.tag == "BalaBanana")
            {
                if (Colisao.gameObject.tag == "Batata")
                {
                    Colisao.SendMessage("CmdSlow");
                }
            }

            if (Colisao.gameObject.tag != "Plataforma")
                Destroy(this.gameObject);
        }
    }

    void Update()
    {

        if (!vivo)
            return;

        distancia = Vector3.Distance(this.transform.position, new Vector3(0.0f, 0.0f, 0.0f));
    }
}
