using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FerdinandezWallyson : NetworkBehaviour {

   public GameObject Mata;
   private float ataca = -12f;
   private bool player = false;

    void Update()
    {
            Mata = GameObject.FindGameObjectWithTag("TorreTomate");
        if (Mata == null)
            Mata = GameObject.FindGameObjectWithTag("TronoTomate");
        if (Mata == null)
        {
            Mata = GameObject.FindGameObjectWithTag("Tomate");
            player = true;
        }

        if (Mata == null)
        {
            this.GetComponent<ParticleSystem>().Stop();
            return;
        }
        ataca += 1*Time.deltaTime;
        if (player)
        {
            if (ataca >= 1f)
            {
                Mata.SendMessage("CmdFerdinandez");
                Mata.SendMessage("CmdRecebeDano", 1);
                ataca = 0;
            }
        }
        else if (ataca >= 0.5f)
        {
            Mata.SendMessage("CmdFerdinandez");
            Mata.SendMessage("CmdRecebeDano", 1);
            ataca = 0;
        }

        transform.LookAt(Mata.transform);
    }
}
