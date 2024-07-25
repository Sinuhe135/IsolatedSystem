using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroidC : MonoBehaviour
{
    float radio = 5f; 
    float velocidad = 0.5f;

    float tiempo = 0f;
    float tiempoEspera = 0f;
    float tiempoCurva = 0f;
    float sentido = 1;

    public float x=0;
    public float y=0;
    float posicionInicialX = 0f;
    float posicionInicialY = 0f;

    bool visto = false;

    private Vector2 screenBounds;
    
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
    public void setSent(float parametroS)
    {
        sentido = parametroS;
    }

    public void setRad(float parametroR)
    {
        radio = parametroR;
    }
    public void setTiempCurv(float parametroTC)
    {
        tiempoCurva = parametroTC;
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
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        gameObject.transform.position = new Vector3(posicionInicialX, posicionInicialY, 0);
        rotar();
        
    }

    void Update()
    {
        if(tiempo < tiempoEspera)
        {
            tiempo += Time.deltaTime;
        }
        
        if(tiempo >= tiempoEspera)
        {
            tiempoCurva += velocidad*Time.deltaTime*sentido;
            if(tiempoCurva <= -2*Mathf.PI || tiempoCurva >=2*Mathf.PI)
            {
                tiempoCurva=0;
            }
            x = radio*Mathf.Cos(tiempoCurva)+posicionInicialX;
            y = radio*Mathf.Sin(tiempoCurva)+posicionInicialY;
            gameObject.transform.position = new Vector3(x, y, 0);
        }
        
        
        if(visto)
        {
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
        else if(gameObject.transform.position.y < screenBounds.y && gameObject.transform.position.y > -screenBounds.y && gameObject.transform.position.x < screenBounds.x && gameObject.transform.position.x > -screenBounds.x)
        {
            visto = true;
        }
        
    }

}
