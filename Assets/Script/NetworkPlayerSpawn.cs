using System.Collections;
using UnityEngine;
using UnityEngine.Networking;



public class NetworkPlayerSpawn : NetworkManager {

    int jogado;
    bool jaera;
    public GameObject selecao;
    public GameObject selecaoUI;

    public void Start()
    {
       jogado = 1;
       jaera = false;

    }
    

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player;

        selecaoUI = GameObject.FindGameObjectWithTag("PersonagensUI");
        selecaoUI.GetComponent<Canvas>().enabled = false;

        if (!jaera)
        {
            jaera = true;;
            selecao = GameObject.FindGameObjectWithTag("Personagens");

            SelecaoPersonagens SP = selecao.GetComponent<SelecaoPersonagens>();

            if (SP.brocolis)
                jogado = 1;
            if (SP.tijolo)
                jogado = 2;
            if (SP.banana)
                jogado = 3;
            if (SP.laranja)
                jogado = 4;
        }
        if (jogado == 1)
        {
            player = Instantiate(Resources.Load("Brocolis"), GameObject.FindGameObjectWithTag("BaseBatata").transform.position, Quaternion.identity) as GameObject;
        }
        else if (jogado == 2)
        {
            player = Instantiate(Resources.Load("Tijolo"), GameObject.FindGameObjectWithTag("BaseBatata").transform.position, Quaternion.identity) as GameObject;
        }
        else if (jogado == 3)
        {
            player = Instantiate(Resources.Load("Banana"), GameObject.FindGameObjectWithTag("BaseTomate").transform.position, Quaternion.identity) as GameObject;
        }
        else if (jogado == 4)
        {
            player = Instantiate(Resources.Load("Laranja"), GameObject.FindGameObjectWithTag("BaseTomate").transform.position, Quaternion.identity) as GameObject;
        }
        else
            player = Instantiate(Resources.Load("Brocolis"), GameObject.FindGameObjectWithTag("BaseBatata").transform.position, Quaternion.identity) as GameObject;

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        GameObject.FindGameObjectWithTag("Controlador").SendMessage("CmdNewPlayer");
        jogado++;

        if (jogado > 4)
            jogado = 1;
        

    }

}
