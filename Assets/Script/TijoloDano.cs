using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TijoloDano : NetworkBehaviour {

    public GameObject tijolo;
    private GameObject alvo1 = null;
    private GameObject alvo2 = null;
    private GameObject alvo3 = null;

    void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Tomate" || Colisao.gameObject.tag == "TorreTomate" || Colisao.gameObject.tag == "MinionTE" || Colisao.gameObject.tag == "TronoTomate")
        {
            if (Colisao.gameObject == alvo1 || Colisao.gameObject == alvo2 || Colisao.gameObject == alvo3)
                return;

            if (alvo1 == null)
            {
                alvo1 = Colisao.gameObject;
                tijolo.SendMessage("CmdAtira", alvo1);
                return;
            }
            if (alvo2 == null)
            {
                alvo2 = Colisao.gameObject;
                tijolo.SendMessage("CmdAtira", alvo2);
                return;
            }
            if (alvo3 == null)
            {
                alvo3 = Colisao.gameObject;
                tijolo.SendMessage("CmdAtira", alvo3);
                return;
            }
        }
    }
    void OnTriggerExit2D(Collider2D Colisao)
    {
        if (Colisao == alvo1)
        {
            alvo1 = null;
            tijolo.SendMessage("CmdAtiraSaiu", alvo1);
        }
        if (Colisao == alvo2)
        {
            alvo2 = null;
            tijolo.SendMessage("CmdAtiraSaiu", alvo2);
        }
        if (Colisao == alvo3)
        {
            alvo3 = null;
            tijolo.SendMessage("CmdAtiraSaiu", alvo3);
        }
    }
}
