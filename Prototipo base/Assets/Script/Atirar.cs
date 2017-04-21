using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Atirar : NetworkBehaviour {

    public int dano;
    public GameObject bala;
    public Vector2 velocidade;

    [Command]
    private void CmdShoot()
    {
        dano = 2;
        
        if (this.gameObject.tag == "Batata")
        {
            bala = Resources.Load("Bala Batata") as GameObject;
            velocidade = new Vector2(10.0f, 0.0f);
        }
        else
        {
            bala = Resources.Load("Bala Tomate") as GameObject;
            velocidade = new Vector2(-10.0f, 0.0f);
        }
        var bullet = Instantiate(bala);


        bullet.transform.position = this.transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = velocidade;
        
        NetworkServer.Spawn(bullet);

    }

   void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdShoot();
           
        }

        
    }
}
