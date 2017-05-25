using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatGravidade : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D Colisao)
    {
        if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "Tomate")
        {
            Colisao.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    void OnCollisionExit2D(Collision2D Colisao)
    {
        if (Colisao.gameObject.tag == "Batata" || Colisao.gameObject.tag == "Tomate")
        {
            Colisao.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
