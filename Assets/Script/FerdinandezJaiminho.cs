using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FerdinandezJaiminho : NetworkBehaviour {

   public GameObject Mata;
   private float ataca = -12f;
   private bool player = false;

    void Update()
    {
            Mata = GameObject.FindGameObjectWithTag("TorreBatata");
        if (Mata == null)
            Mata = GameObject.FindGameObjectWithTag("TronoBatata");
        if (Mata == null)
        {
            Mata = GameObject.FindGameObjectWithTag("Batata");
            player = true;
        }
        if (Mata == null)
        {
            this.GetComponent<ParticleSystem>().Stop();
            this.gameObject.GetComponent<AudioSource>().Stop();
            return;
        }
        ataca += 1*Time.deltaTime;
        if (player)
        {
            if (ataca >= 1f)
            {
                //Mata.SendMessage("CmdFerdinandez");
                Mata.SendMessage("CmdRecebeDano", 1);
                ataca = 0;
            }
        }
        else if (ataca >= 0.5f)
        {
            if (!this.gameObject.GetComponent<AudioSource>().isPlaying)
                this.gameObject.GetComponent<AudioSource>().Play();
            Mata.SendMessage("CmdFerdinandez");
            Mata.SendMessage("CmdRecebeDano", 1);
            ataca = 0;
        }

        transform.LookAt(Mata.transform);
    }
}
