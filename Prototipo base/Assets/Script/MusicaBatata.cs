using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaBatata : MonoBehaviour {

    public GameObject musicagerencia;
    private float distancia;

    void Start ()
    {
        musicagerencia = GameObject.Find("Musica");
	}
	
	void Update () {
        distancia = musicagerencia.transform.position.x - this.transform.position.x;
        if (distancia < 0)
            distancia = distancia * -1;
        distancia += 11;
        GetComponent<AudioSource>().maxDistance = distancia;
	}
}
