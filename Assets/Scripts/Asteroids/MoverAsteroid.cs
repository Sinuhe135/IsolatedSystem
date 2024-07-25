using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroid : MonoBehaviour
{

    float angulo = 0f; 
    float velocidad = 0f;
    float velY = 0f;
    float velX = 0f;

    float tiempo = 0f;
    float tiempoEspera = 0f;

    float posicionInicialX = 0f;
    float posicionInicialY = 0f;

    public float margen = 0f;
    
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
    

    void Start()
    {
        gameObject.transform.position = new Vector3(posicionInicialX,posicionInicialY,0);
        rotar();
        
        velY = velocidad*Mathf.Sin(angulo*Mathf.PI/180);
        velX = velocidad*Mathf.Cos(angulo*Mathf.PI/180);
    }

    void Update()
    {
        if(tiempo < tiempoEspera)
        {
            tiempo += Time.deltaTime;
        }
        
        if(tiempo >= tiempoEspera)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x+velX*Time.deltaTime, gameObject.transform.position.y+velY*Time.deltaTime, 0);
        }
        
        gameObject.GetComponent<Despawnear>().checarDespawneo(margen);
    }

}
