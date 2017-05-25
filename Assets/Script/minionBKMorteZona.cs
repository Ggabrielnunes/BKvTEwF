using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class minionBKMorteZona : NetworkBehaviour {

    public GameObject minion;

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Tomate")
        {
            minion.SendMessage("CmdGoldIn", Colisao.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Tomate")
        {
            minion.SendMessage("CmdGoldOut", Colisao.gameObject);
        }
    }
}
