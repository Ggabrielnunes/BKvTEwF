using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morte : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "Tomate")
            Colisao.SendMessage("CmdRecebeDano", 8000);
        else
            Destroy(Colisao.gameObject);
    }
}
