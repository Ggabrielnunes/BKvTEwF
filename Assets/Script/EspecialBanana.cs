using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EspecialBanana : NetworkBehaviour {
    
    private GameObject Casca;	

	void Update ()
    {
        Casca = GameObject.FindGameObjectWithTag("Teleporte");
        if (Casca != null)
        {
            this.gameObject.transform.position = Casca.transform.position;
            this.gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("ModeloBanana").transform);
        }

    }
}
