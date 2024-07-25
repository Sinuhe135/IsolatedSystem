using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEmptyPedazos : MonoBehaviour
{
    float posicionInicialX = 0f;
    float posicionInicialY = 0f;

    float rotacion = 0f;
    float velocidad = 0f;

    int cantidadRestante = 5;

    void Start()
    {
        gameObject.transform.position = new Vector3(posicionInicialX,posicionInicialY,0);
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * rotacion);

        for(int indice=0;indice<5;indice++)
        {
            gameObject.transform.GetChild(indice).gameObject.GetComponent<MoverPedazos>().setAngulo(rotacion+72*indice);
            gameObject.transform.GetChild(indice).gameObject.GetComponent<MoverPedazos>().setVelocidad(velocidad);
        }
    }

    public void restarCantidad()
    {
        cantidadRestante--;
        if(cantidadRestante <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setPosicionInicialX(float paramPosicionInicialX)
    {
        posicionInicialX = paramPosicionInicialX;
    }
    public void setPosicionInicialY(float paramPosicionInicialY)
    {
        posicionInicialY = paramPosicionInicialY;
    }
    public void setRotacion(float paramRotacion)
    {
        rotacion = paramRotacion;
    }
    public void setVelocidad(float paramVelocidad)
    {
        velocidad = paramVelocidad;
    }
}
