using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowerBatataZone : NetworkBehaviour
{
    public GameObject torre;

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Tomate")
        {
            torre.SendMessage("CmdAtira", 1);
        }
        if (Colisao.gameObject.tag == "MinionTE")
        {
            torre.SendMessage("CmdAtira", 2);
        }
    }
    void OnTriggerExit2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Tomate")
        {
            torre.SendMessage("CmdAtira", 0);
        }
        if (Colisao.gameObject.tag == "MinionTE")
        {
            torre.SendMessage("CmdAtira", 0);
        }
    }
}
