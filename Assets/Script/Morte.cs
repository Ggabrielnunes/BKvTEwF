using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Morte : NetworkBehaviour {

    private void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "Tomate")
            Colisao.SendMessage("CmdRecebeDano", 8000);
        else if(Colisao.gameObject.tag == "colisor" || Colisao.gameObject.tag == "oiala")
            { }
         else
            NetworkServer.Destroy(Colisao.gameObject);
    }
}
