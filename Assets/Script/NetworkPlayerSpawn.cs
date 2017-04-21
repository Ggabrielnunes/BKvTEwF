using System.Collections;
using UnityEngine;
using UnityEngine.Networking;



public class NetworkPlayerSpawn : NetworkManager {
    int jogado;

    public void Start()
    {
       jogado = 0;
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player;

        if (jogado % 2 == 0)
        {
            player = Instantiate(Resources.Load("Player"), GameObject.FindGameObjectWithTag("BaseBatata").transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            player = Instantiate(Resources.Load("Player2"), GameObject.FindGameObjectWithTag("BaseTomate").transform.position, Quaternion.identity) as GameObject;
        }
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        jogado++;
    }

}
