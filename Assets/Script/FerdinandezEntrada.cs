using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerdinandezEntrada : MonoBehaviour {

    public float time;
    public GameObject Ferdinandez;
    public GameObject Besq;
    public GameObject Bdir;
    public GameObject BaseJaim;
    public GameObject BaseWall;

    // Use this for initialization
    void Start () {
        time = 0;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        Besq.gameObject.GetComponent<MeshRenderer>().enabled = true;
        Bdir.gameObject.GetComponent<MeshRenderer>().enabled = true;
        BaseJaim.GetComponent<AudioSource>().Stop();
        BaseWall.GetComponent<AudioSource>().Stop();
        this.gameObject.GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (time > 3.5f)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Besq.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Bdir.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (time > 9.5f)
        {
            Ferdinandez.SetActive(true);
            
        }
        time += 1 * Time.deltaTime;
        
	}
}
