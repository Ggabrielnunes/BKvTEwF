using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerdinandezEntrada : MonoBehaviour {

    public float time;
    public GameObject Ferdinandez;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 3.0f)
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (time > 6.0f)
        {
            Ferdinandez.SetActive(true);
            this.gameObject.SetActive(false);
        }
        time += 1 * Time.deltaTime;
        
	}
}
