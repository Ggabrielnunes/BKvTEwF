using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LaranjaDano : NetworkBehaviour
{
    
    public GameObject laranja;
    private GameObject alvo1 = null;
    private GameObject alvo2 = null;
    private GameObject alvo3 = null;

        void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "TorreBatata" || Colisao.gameObject.tag == "MinionBK" || Colisao.gameObject.tag == "TronoBatata")
        {
            if (Colisao.gameObject == alvo1 || Colisao.gameObject == alvo2 || Colisao.gameObject == alvo3)
                return;

            if (alvo1 == null)
            {
                alvo1 = Colisao.gameObject;
                laranja.SendMessage("CmdAtira", alvo1);
                return;
            }
            if (alvo2 == null)
            {
                alvo2 = Colisao.gameObject;
                laranja.SendMessage("CmdAtira", alvo2);
                return;
            }
            if (alvo3 == null)
            {
                alvo3 = Colisao.gameObject;
                laranja.SendMessage("CmdAtira", alvo3);
                return;
            }
        }
    }
    void OnTriggerExit2D(Collider2D Colisao)
    {
        if (Colisao == alvo1)
        {
            alvo1 = null;
            laranja.SendMessage("CmdAtiraSaiu", alvo1);
        }
        if (Colisao == alvo2)
        {
            alvo2 = null;
            laranja.SendMessage("CmdAtiraSaiu", alvo2);
        }
        if (Colisao == alvo3)
        {
            alvo3 = null;
            laranja.SendMessage("CmdAtiraSaiu", alvo3);
        }
    }
    
}
