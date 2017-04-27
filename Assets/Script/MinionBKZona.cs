using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MinionBKZona : NetworkBehaviour
{
    public GameObject minion;

    void OnTriggerStay2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "TorreTomate" || Colisao.gameObject.tag == "MinionTE")
        {
            minion.SendMessage("CmdPorNarnia", Colisao.gameObject);
        }
    }
}
