using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorTop : MonoBehaviour {

    public float moveSpeed;

	public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "MinionBK" )
        {
            
            var script = collider.GetComponent<MinionBK>();
            script.ChangeSpeed(moveSpeed);
            Debug.Log("Velocidade " + moveSpeed);
        }
        if (collider.tag == "MinionTE")
        {
            moveSpeed = -1 * moveSpeed;
            var script = collider.GetComponent<MinionTE>();
            script.ChangeSpeed(moveSpeed);
            Debug.Log("Velocidade " + moveSpeed);
        }
    }
}
