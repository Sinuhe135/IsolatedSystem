using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRocky : MonoBehaviour
{

    public PlayerRespawn playerRespawn;
    public DifficultyManager dificultad;
    public MusicManager MusicManager;
    public MoverRocky Rocky;
    public GameObject pedazosOriginal;

    public GameObject sonidoPreMuerte;

    GameObject ClonPedazos;

    public pauseScreen pausa;

    public float tiempoPausa;

    bool pausado  = false;
    float tiempoInicial;
    float tiempo = 0f;

    void Update()
    {
        if(pausado)
        {
            if(tiempo<=tiempoPausa)
            {
                tiempo = Time.unscaledTime - tiempoInicial;
            }
            else
            {
                pausa.Despausar();
                tiempo = 0;
                pausado = false;
                morir();
            }
        }
    }
    void morir()
    {
        crearPedazos();

        dificultad.desactivar();
        Rocky.morir();
        playerRespawn.activarTimer();

        ScoreManager.instanceScore.registerHighScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Asteroid") || collision.CompareTag("AsteroidG"))
        {
            if(MoverRocky.justRespawned== false)
            {
                GameObject ClonSonidoPreMuerte = Instantiate(sonidoPreMuerte)as GameObject;
                Destroy(ClonSonidoPreMuerte, 1f);

                pausa.Pausar();
                tiempoInicial = Time.unscaledTime;
                pausado = true;
                MusicManager.bajarAlMorir();

            }
        }
    }

    void crearPedazos()
    {
        ClonPedazos = Instantiate(pedazosOriginal)as GameObject; 
        ClonPedazos.GetComponent<MoverEmptyPedazos>().setPosicionInicialX(gameObject.transform.position.x);
        ClonPedazos.GetComponent<MoverEmptyPedazos>().setPosicionInicialY(gameObject.transform.position.y);
        ClonPedazos.GetComponent<MoverEmptyPedazos>().setRotacion(Rocky.getRotacion());
        if(Rocky.getVelocidad()==0)
        {
            ClonPedazos.GetComponent<MoverEmptyPedazos>().setVelocidad(0.1f);
        }
        else
        {
            ClonPedazos.GetComponent<MoverEmptyPedazos>().setVelocidad((Rocky.getVelocidad()/1.5f));
        }
        
    }
}
