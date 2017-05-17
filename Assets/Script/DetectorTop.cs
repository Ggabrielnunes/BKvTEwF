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
        else if (collider.tag == "MinionTE")
        {
            var script = collider.GetComponent<MinionTE>();
            script.ChangeSpeed(moveSpeed);
            Debug.Log("Velocidade " + moveSpeed);
        }
    }
}
