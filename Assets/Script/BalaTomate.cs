using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BalaTomate: NetworkBehaviour {
    float origem;
    float distancia;
    bool vivo;

    void Start()
    {
        origem = transform.position.x;
        vivo = true;
        distancia = 0;
    }

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (vivo)
        {
            if (Colisao.gameObject.tag == "Batata")
                Colisao.SendMessage("CmdRecebeDano", 2);
            if (Colisao.gameObject.tag != "Tomate" && Colisao.gameObject.tag != "colisor")
                Destroy(this.gameObject);
        }

        if (Colisao.gameObject.tag == "Morte")
            Destroy(this.gameObject);
    }

    void Update()
    {
        if (!vivo)
            return;

        if (distancia >= 20)
        {
            vivo = false;
            GetComponent<CircleCollider2D>().isTrigger = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        distancia = origem - transform.position.x;
    }
}
