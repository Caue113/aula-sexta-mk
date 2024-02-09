using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vidas = 3;

    public void AdicionarVida(int vida)
    {
        vidas += vida;

        if(vidas + vida < 0) 
        {
            vidas = 0;
        }
    }

    public bool VidaEstaZero()
    {
        return vidas == 0;
    }
}
