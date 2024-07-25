using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip cancionLevel5;
    public AudioClip cancionMain;
    public float volumenNormal;
    public float volumenEnPausa;

    AudioSource musicaFondo;

    void Start()
    {
        musicaFondo = gameObject.GetComponent<AudioSource>();
    }

    public void bajarAlMorir()
    {
        musicaFondo.volume = 0f;
    }

    public void subirAlRespawnear()
    {
        musicaFondo.volume = volumenNormal;
    }

    public void bajarPoquito()
    {
        musicaFondo.volume = volumenEnPausa;
    }
    public void cambiarPitch(float pit)
    {
        musicaFondo.pitch = pit;
    }

    public void cambiarMain()
    {
        musicaFondo.Stop();
        musicaFondo.clip = cancionMain;
        musicaFondo.Play();
    }

    public void cambiarLevel5()
    {
        musicaFondo.Stop();
        musicaFondo.clip = cancionLevel5;
        musicaFondo.Play();
    }
}
