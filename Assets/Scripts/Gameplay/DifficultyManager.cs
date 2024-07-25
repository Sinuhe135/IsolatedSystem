using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public int puntosPara2;
    public int puntosPara3;
    public int puntosPara4;
    public int puntosPara5;
    public int puntosParaSkin;

    int nivelActual;
    bool mostrado =false;

    public int nivel;

    float tiempoMostracion = 0f;

    public CrearAsteroid propiedadesAsteroid;

    public MusicManager musica;
    public MainUI instrucciones;
    public MainUI barraFuel;

    void Update()
    {
        if(mostrado)
        {
            tiempoMostracion += Time.deltaTime;
            if (tiempoMostracion > 3)
            {
                tiempoMostracion = 0;
                mostrado = false;
                ScoreManager.instanceScore.addLevel(nivelActual, mostrado);
            }
        }
    }

    public void cambiarDificultad()
    {
        if(ScoreManager.score == 0 || nivel == 1)
        {
            propiedadesAsteroid.level1();
            nivelActual = 1;
            mostrado = true;
            

            musica.cambiarMain();
            //musica.cambiarPitch(1f);
        }
        else if(ScoreManager.score == puntosPara2 || nivel == 2)
        {
            propiedadesAsteroid.level2();
            nivelActual = 2;
            mostrado = true;

            //musica.cambiarPitch(1.2f);
        }
        else if(ScoreManager.score == puntosPara3 || nivel == 3)
        {
            propiedadesAsteroid.level3();
            nivelActual = 3;
            mostrado = true;

            //musica.cambiarPitch(1.4f);
        }
        else if(ScoreManager.score == puntosPara4 || nivel == 4)
        {
            propiedadesAsteroid.level4();
            nivelActual = 4;
            mostrado = true;

            //musica.cambiarPitch(1.6f);
        }
        else if(ScoreManager.score == puntosPara5 || nivel == 5)
        {
            propiedadesAsteroid.level5();
            nivelActual = 5;
            mostrado = true;

            musica.cambiarLevel5();
            //musica.cambiarPitch(1f);
        }
        else if(ScoreManager.score == puntosParaSkin || nivel == 6)
        {
            nivelActual = 6;
        }
        ScoreManager.instanceScore.addLevel(nivelActual, mostrado);
    }

    public void desactivar()
    {
        propiedadesAsteroid.desactivarAsteroids();
    }

    public void activar()
    {
        propiedadesAsteroid.activarAsteroids();
        if (MoverRocky.tutorial)
        {
            instrucciones.SetDown();
            barraFuel.SetUp();
            nivelActual = 1;
            ScoreManager.instanceScore.addLevel(nivelActual, MoverRocky.tutorial);
            MoverRocky.tutorial = false;
            mostrado =  true;
        }
    }
    public string textoPuntosPara(int nivelActualParam)
    {
        string textoFinal = "";
        switch(nivelActualParam)
        {
            case 1:
                textoFinal= "Score to level "+(nivelActualParam+1)+": "+puntosPara2;
            break;
            case 2:
                textoFinal= "Score to level "+(nivelActualParam+1)+": "+puntosPara3;
            break;
            case 3:
                textoFinal= "Score to level "+(nivelActualParam+1)+": "+puntosPara4;
            break;
            case 4:
                textoFinal= "Score to level "+(nivelActualParam+1)+": "+puntosPara5;
            break;
            case 5:
                textoFinal= "Score to unlock final skin: "+puntosParaSkin;
            break;
            case 6:
                textoFinal="Final level";
            break;
            default:
                textoFinal= "Error";
            break;
        }
        return textoFinal;
    }
}
