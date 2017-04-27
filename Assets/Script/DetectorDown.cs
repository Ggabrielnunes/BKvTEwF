using UnityEngine;
using System.Collections;

public class DetectorDown : MonoBehaviour {

    public Collider2D player;

    public void OnTriggerExit2D(Collider2D p_other)
    {
        if (p_other.tag == "Plataforma")
        {
            Physics2D.IgnoreCollision(player, p_other, false);
        }
    }
    
}
