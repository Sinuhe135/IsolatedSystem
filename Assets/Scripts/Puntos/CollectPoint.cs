using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPoint : MonoBehaviour
{
    public GameObject animacionSalidaOriginal;

    public MoverRocky Rocky;
    public GameObject sonidoPunto;

    public DifficultyManager dificultad;

    public Sprite spriteCosa;
    bool cosaActivado = false;

    float minimoX = 0f;
    float maximoX = 0f;

    float limiteMaximo = 7f;
    float limiteMinimo = -7f;

    float tamanoP = 0.1f;
    public float aumentoTamano;

    void Start()
    {
        //gameObject.GetComponent<Transform>().position = new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f), 0);
        animacionEntrada();
    }
    void Update()
    {
        if(!cosaActivado)
        {
            if(Input.GetKey("t"))
            {
                if(Input.GetKey("i"))
                {   
                    if(Input.GetKey("m"))
                    {
                        if(Input.GetKeyDown("o"))
                        {
                            gameObject.GetComponent<SpriteRenderer>().sprite = spriteCosa;
                            GameObject ClonSonidoPunto = Instantiate(sonidoPunto)as GameObject;
                            Destroy(ClonSonidoPunto, 0.5f);
                            cosaActivado = true;
                        }
                    }
                }
            }
        }
        animacionEntrada();
    }
    void moverPunto()
    {
        minimoX = gameObject.transform.position.x - 2.5f;
        maximoX = gameObject.transform.position.x + 2.5f;
        /*
        switch(CrearAsteroid.pasandoG)
        {
            case 0:
                limiteMaximo = 7;
                limiteMinimo = -7;
            break;
            case 1:
                limiteMaximo = 0;
                limiteMinimo = -7;
            break;
            case 2:
                limiteMinimo = 0;
                limiteMaximo = 7;
            break;
        }
        */


        

        if(minimoX>=limiteMinimo && maximoX <= limiteMaximo)
        {
            int escogerLado = Random.Range(1, 2);
            if(escogerLado == 1)
            {
                gameObject.GetComponent<Transform>().position = new Vector3(Random.Range(limiteMinimo, minimoX), Random.Range(-3f, 3f), 0);
            }
            else
            {
                gameObject.GetComponent<Transform>().position = new Vector3(Random.Range(maximoX, limiteMaximo), Random.Range(-3f, 3f), 0);
            }
        }
        else if(minimoX <= limiteMinimo)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(Random.Range(maximoX, limiteMaximo), Random.Range(-3f, 3f), 0);
        }
        else
        {
            gameObject.GetComponent<Transform>().position = new Vector3(Random.Range(limiteMinimo, minimoX), Random.Range(-3f, 3f), 0);
        }
    }
    void animacionEntrada()
    {
        if(tamanoP < 0.7f)
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(tamanoP,tamanoP,1);
            tamanoP+= aumentoTamano* Time.deltaTime;
        }
        else if(tamanoP > 0.7f)
        {
            tamanoP = 0.7f;
            gameObject.GetComponent<Transform>().localScale = new Vector3(tamanoP,tamanoP,1);
        }
        
    }
    void aparecerAnimacionSalida()
    {
        GameObject clonAnimacionSalida = Instantiate(animacionSalidaOriginal);
        clonAnimacionSalida.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x,gameObject.GetComponent<Transform>().position.y,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Clon"))
        {
            GameObject ClonSonidoPunto = Instantiate(sonidoPunto)as GameObject;
            Destroy(ClonSonidoPunto, 0.5f);

            ScoreManager.instanceScore.addPoint();
            Rocky.restaurarComb(false);
            
            aparecerAnimacionSalida();
            tamanoP = 0.1f;
            moverPunto();

            dificultad.cambiarDificultad();
            dificultad.activar();
  
        }
        /*
        if(collision.CompareTag("AsteroidG"))
        {
            moverPunto();
        }
        */
    }
}
