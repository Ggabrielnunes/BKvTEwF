using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LaranjaEspecial : NetworkBehaviour
{

    public bool special;
    public float firerate1;
    public float firerate2;
    public float firerate3;
    public float firerate4;
    public float firerate5;
    private GameObject alvo1;
    private GameObject alvo2;
    private GameObject alvo3;
    private GameObject alvo4;
    private GameObject alvo5;

    [Command]
    public void CmdAttack(bool attack)
    {
        if (!isServer)
            return;

        if (attack)
            special = true;
        else
            special = false;
    }

    void OnTriggerStay2D(Collider2D Colisao)
    {
        if (special)
        {
            if (Colisao.gameObject.tag == "MinionBK")
            {
                if (alvo1 == null)
                {
                    alvo1 = Colisao.gameObject;
                    return;
                }
                else if (firerate1 <= 0)
                {
                    Colisao.SendMessage("CmdRecebeDano", 1);
                    firerate1 = 2;
                }

                if (alvo2 == null)
                {
                    alvo2 = Colisao.gameObject;
                    return;
                }
                else if (firerate2 <= 0)
                {
                    Colisao.SendMessage("CmdRecebeDano", 1);
                    firerate2 = 2;
                }
                if (alvo3 == null)
                {
                    alvo3 = Colisao.gameObject;
                    return;
                }
                else if (firerate3 <= 0)
                {
                    Colisao.SendMessage("CmdRecebeDano", 1);
                    firerate3 = 2;
                }
                if (alvo4 == null)
                {
                    alvo4 = Colisao.gameObject;
                    return;
                }
                else if (firerate4 <= 0)
                {
                    Colisao.SendMessage("CmdRecebeDano", 1);
                    firerate4 = 2;
                }
                if (alvo5 == null)
                {
                    alvo5 = Colisao.gameObject;
                    return;
                }
                else if (firerate5 <= 0)
                {
                    Colisao.SendMessage("CmdRecebeDano", 1);
                    firerate5 = 2;
                }
            }
        }
    }

    void Start()
    {
        special = false;
        firerate1 = 0;
        firerate2 = 0;
        firerate3 = 0;
        firerate4 = 0;
        firerate5 = 0;
    }
    void Update()
    {
        if (firerate1 > 0)
            firerate1 -= 1 * Time.deltaTime;
        if (firerate2 > 0)
            firerate2 -= 1 * Time.deltaTime;
        if (firerate3 > 0)
            firerate3 -= 1 * Time.deltaTime;
        if (firerate4 > 0)
            firerate4 -= 1 * Time.deltaTime;
        if (firerate5 > 0)
            firerate5 -= 1 * Time.deltaTime;
    }
}
