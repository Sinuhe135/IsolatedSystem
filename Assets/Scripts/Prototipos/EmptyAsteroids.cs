using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyAsteroids : MonoBehaviour
{
    float posicionInicialX = 0f;
    float posicionInicialY = 0f;
    int cantidadRestante = 3;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(posicionInicialX,posicionInicialY,0);
    }

    // Update is called once per frame
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
}
