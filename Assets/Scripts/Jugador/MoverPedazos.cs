using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPedazos : MonoBehaviour
{
    float velocidad = 0f;
    float angulo = 0f; 

    float velY = 0f;
    float velX = 0f;

    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        velY = velocidad*Mathf.Sin(angulo*Mathf.PI/180);
        velX = velocidad*Mathf.Cos(angulo*Mathf.PI/180);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x+velX*Time.deltaTime, gameObject.transform.position.y+velY*Time.deltaTime, 0);

        if(gameObject.transform.position.y > screenBounds.y + 1)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<MoverEmptyPedazos>().restarCantidad();
        }
        else if(gameObject.transform.position.y < (screenBounds.y + 1)*-1)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<MoverEmptyPedazos>().restarCantidad();
        }
        else if(gameObject.transform.position.x > screenBounds.x + 1)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<MoverEmptyPedazos>().restarCantidad();
        }
        else if(gameObject.transform.position.x < (screenBounds.x + 1)*-1)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<MoverEmptyPedazos>().restarCantidad();
        }
    }

    public void setAngulo(float parametroAng)
    {   
        angulo = parametroAng;
    }

    public void setVelocidad(float parametroVel)
    {   
        velocidad = parametroVel;
    }
}
