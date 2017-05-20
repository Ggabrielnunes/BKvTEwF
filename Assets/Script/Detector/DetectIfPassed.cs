using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectIfPassed : MonoBehaviour {

    public event Action<Collider2D> onDetectPassed;

    public void OnTriggerExit2D(Collider2D p_collider)
    {
        if (p_collider.gameObject.layer == 14)
        {
            if (onDetectPassed != null) onDetectPassed(p_collider);
        }
    }
}
