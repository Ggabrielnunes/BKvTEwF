﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowerBatataZone : NetworkBehaviour
{
    public GameObject torre;
    private GameObject alvo = null;

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (alvo == null && Colisao.gameObject != alvo)
        {
            if (Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "MinionTE")
            {
                alvo = Colisao.gameObject;
                torre.SendMessage("CmdAtira", alvo);
            }
        }
    }
    void OnTriggerExit2D(Collider2D Colisao)
    {
        if (Colisao == alvo)
        {
            alvo = null;
            torre.SendMessage("CmdAtira", null);
        }
    }
}
