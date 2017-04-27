using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MinionTEZona : NetworkBehaviour
{
    public GameObject minion;

    void OnTriggerStay2D(Collider2D Colisao)
    {
        if ( Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "TorreBatata" || Colisao.gameObject.tag == "MinionBK")
        { 
            minion.SendMessage("CmdPorNarnia", Colisao.gameObject);
        }
    }
}
