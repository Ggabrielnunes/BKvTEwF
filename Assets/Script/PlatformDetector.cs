using System;
using UnityEngine;
using System.Collections;

public class PlatformDetector : MonoBehaviour {

    public event Action<Collider2D> onEnterPlatform;
    public event Action<Collider2D> onExitPlatform;

    public void OnTriggerEnter2D(Collider2D p_other)
    {
        if (p_other.tag == "Plataforma")
        {
         //   int(onEnterPlatform!=null) on
        }
    }

    public void OnTriggerExit2D(Collider2D p_other)
    {
        if (p_other.tag == "Plataforma")
        {
           
        }
    }
}
