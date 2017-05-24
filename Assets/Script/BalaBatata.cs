using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaBatata : NetworkBehaviour {
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
            if (Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "TorreTomate" || Colisao.gameObject.tag == "MinionTE")
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
            if (this.gameObject.tag == "BalaBrocolis")
            {
                if (Colisao.gameObject.tag == "Batata")
                {
                    Colisao.SendMessage("CmdCura", 1);
                }
            }

            if (Colisao.gameObject.tag != "Plataforma")
                Destroy(this.gameObject);
        }
    }

    void Update()
    {

        if (!vivo)
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        distancia = Vector3.Distance(this.transform.position, new Vector3(0.0f, 0.0f, 0.0f));
    }
}
