using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MusicaGerencia : NetworkBehaviour
{

    public float count;
    public float score;
    public bool ganho;
    public bool tomate;
    public int ferdinandez;
    public int players;
    public GameObject canvaW;
    public GameObject canvaF;
    public GameObject canvaJ;
    public GameObject canvaA;

    [Command]
    public void CmdGanho(bool exe)
    {
        if (!isServer)
            return;

        if (ferdinandez == 0)
        {
            if (exe)
                tomate = true;
            else
                tomate = false;

            ganho = true;
        }
    }
    public void CmdFerdinandez()
    {
        if (!isServer)
            return;

        ferdinandez ++;
    }
    public void CmdAlianca()
    {
        if (!isServer)
            return;

        ferdinandez = -10;
    }
    public void CmdNewPlayer()
    {
        if (!isServer)
            return;

        players++;
    }
    public void CmdScoreJ(int valor)
    {
        if (!isServer)
            return;

        if (score < 8000)
        {
            score += valor;
            if (score > 8000)
                score = 8000;
        }
    }
    public void CmdScoreW(int valor)
    {
        if (!isServer)
            return;

        if (score > -8000)
        {
            score -= valor;

            if (score < -8000)
                score = -8000;
        }
    }

    void Start()
    {
        count = 5.0f;
        ganho = false;
        ferdinandez = 0;
        players = 2;
        score = 0;
    }

    void Update () {

        this.gameObject.transform.position = new Vector3((score / 100), 4.7f, -10.0f);

        if (ferdinandez >= players)
        {
            canvaF.SetActive(true);

            count -= 1 * Time.deltaTime;
            if (count <= 0)
            {
                canvaF.SetActive(false);
                NetworkManager.Shutdown();
            }
        }
        if (ferdinandez < 0)
        {
            canvaA.SetActive(true);

            count -= 1 * Time.deltaTime;
            if (count <= 0)
            {
                canvaA.SetActive(false);
                NetworkManager.Shutdown();
            }
        }

        if (ganho)
        {
            if(tomate)
                canvaW.SetActive(true);
            else
                canvaJ.SetActive(true);
            count -= 1 * Time.deltaTime;
            if (count <= 0)
            {
                canvaW.SetActive(false);
                canvaJ.SetActive(false);
                NetworkManager.Shutdown();
            }

        }
    }
}
