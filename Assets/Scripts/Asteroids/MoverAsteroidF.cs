using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroidF : MonoBehaviour
{
    float angulo = 0f; 
    float velocidad = 0f;
    float velY = 0f;
    float velX = 0f;

    float tiempo = 0f;
    float tiempoEspera = 0f;

    float tiempoExplotar = 0f;

    float posicionInicialX = 0f;
    float posicionInicialY = 0f;

    private Vector2 screenBounds;

    public GameObject pedazosOriginal;
    GameObject ClonPedazos;
    
    public void setVelocidad(float parametroV)
    {
        velocidad = parametroV;
    }

    public void setTiempoEspera(float parametroT)
    {
        tiempoEspera = parametroT;
    }

    public void setX(float parametroX)
    {
        posicionInicialX = parametroX;
    }

    public void setY(float parametroY)
    {
        posicionInicialY = parametroY;
    }

    public void setAng(float parametroA)
    {
        angulo = parametroA;
    }
    public void setTiempExp(float paramatroE)
    {
        tiempoExplotar = paramatroE;
    }

    void rotar()
    {
        int rotacion = Random.Range(1, 5);
        switch(rotacion)
        {
            case 1:
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * 0);
            break;
            case 2:
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * 90);
            break;
            case 3:
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * 180);
            break;
            case 4:
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * 270);
            break;
        }
    }
    void crearPedazos()
    {
        ClonPedazos = Instantiate(pedazosOriginal)as GameObject; 
        ClonPedazos.GetComponent<EmptyAsteroidF>().setPosicionInicialX(gameObject.transform.position.x);
        ClonPedazos.GetComponent<EmptyAsteroidF>().setPosicionInicialY(gameObject.transform.position.y);
        ClonPedazos.GetComponent<EmptyAsteroidF>().setRotacion(angulo);
        ClonPedazos.GetComponent<EmptyAsteroidF>().setVelocidad(velocidad);

        ClonPedazos.transform.parent = gameObject.transform.parent;  
    
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        gameObject.transform.position = new Vector3(posicionInicialX,posicionInicialY,0);
        rotar();
        
        velY = velocidad*Mathf.Sin(angulo*Mathf.PI/180);
        velX = velocidad*Mathf.Cos(angulo*Mathf.PI/180);
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        
        if(tiempo >= tiempoEspera)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x+velX*Time.deltaTime, gameObject.transform.position.y+velY*Time.deltaTime, 0);
        }
        if((tiempo -tiempoEspera)>= tiempoExplotar)
        {
            crearPedazos();
            Destroy(gameObject);
        }
        

        if(gameObject.transform.position.y > screenBounds.y + 3)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.y < (screenBounds.y + 3)*-1)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.x > screenBounds.x + 3)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.x < (screenBounds.x + 3)*-1)
        {
            Destroy(gameObject);
        }
    }
}
