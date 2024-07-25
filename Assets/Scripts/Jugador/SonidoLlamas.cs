using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoLlamas : MonoBehaviour
{
    bool sonando = false;
    public float volumenAlto;
    public float volumenBajo; 
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        
    }
    public void activar()
    {
        if(sonando == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
            sonando = true;
        }
        
    }

    public void desactivar()
    {
        if(sonando)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            sonando = false;
        }
        
    }

    public void subir()
    {
        gameObject.GetComponent<AudioSource>().volume = volumenAlto;
    }

    public void bajar()
    {
        gameObject.GetComponent<AudioSource>().volume = volumenBajo;
    }
}
