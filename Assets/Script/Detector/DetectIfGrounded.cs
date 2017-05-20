using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectIfGrounded : MonoBehaviour {

    public event Action<Collider2D> onDetectGround;
    
    public void OnTriggerEnter2D(Collider2D p_collider)
    {       
        if(p_collider.gameObject.layer==14)
        {
            if (onDetectGround != null) onDetectGround(p_collider);
        }
    }
}
