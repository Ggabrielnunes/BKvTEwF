using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelecaoPersonagens : NetworkBehaviour {

    public bool brocolis = false;
    public bool laranja = false;
    public bool banana = false;
    public bool tijolo = false;

    public void seta(int aaa)
    {
       if (aaa == 1)
        {
            banana = true;
            brocolis = false;
            laranja = false;
            tijolo = false;
        }
        else if (aaa == 2)
        {
            banana = false;
            brocolis = true;
            laranja = false;
            tijolo = false;
        }
        else if (aaa == 3)
        {
            banana = false;
            brocolis = false;
            laranja = true;
            tijolo = false;
        }
        else if (aaa == 4)
        {
            banana = false;
            brocolis = false;
            laranja = false;
            tijolo = true;
        }

    }
}
