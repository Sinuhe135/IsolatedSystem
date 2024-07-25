using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acercarAlejarCam : MonoBehaviour
{
    bool acercando = false;
    bool alejando = false;
    float tamanoCamara = 5f;

    public float limiteAcercando;
    public float factorMovimientoCamara;

    void Update()
    {
        if(acercando)
        {
            if(tamanoCamara > limiteAcercando)
            {
                tamanoCamara -= factorMovimientoCamara * Time.deltaTime;
                if(tamanoCamara <= limiteAcercando)
                {
                    tamanoCamara = limiteAcercando;
                    acercando = false;
                }
                Camera.main.orthographicSize = tamanoCamara;
            }
        }
        else if(alejando)
        {
            if(tamanoCamara < 5)
            {
                tamanoCamara += factorMovimientoCamara * Time.deltaTime;
                if(tamanoCamara >= 5)
                {
                    tamanoCamara = 5;
                    alejando = false;
                }
                Camera.main.orthographicSize = tamanoCamara;
            }
        }
    }

    public void activarAcercando()
    {
        acercando = true;
    }
    public void activarAlejando()
    {
        alejando = true;
    }
}
