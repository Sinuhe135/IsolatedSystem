using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPrototipo : MonoBehaviour
{
    public float velX;
    public float velY;
    public float timeContador;
    float timer = 0;

    public float numAst = 0;

    public GameObject pedazosOriginal;
    GameObject ClonPedazos;

    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        switch(numAst)
        {
            case 3:
                mover3();
                break;
            case 4:
                mover4();
                break;
            case 5:
                mover5();
                break;
            case 6:
                moverTrozos();
                break;
        }
        if (numAst != 3)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x+velX*Time.deltaTime, gameObject.transform.position.y+velY*Time.deltaTime, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(velX, velY, 0);
        }
    }
    void mover3()
    {
        timeContador += 0.5f*Time.deltaTime;
        if(timeContador <= -2*Mathf.PI || timeContador >=2*Mathf.PI)
        {
            timeContador=0;
        }
        velX = 8*Mathf.Cos(timeContador)-3;
        velY = 8*Mathf.Sin(timeContador)-6.5f;
        
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
    void mover5()
    {
        if(gameObject.transform.position.y > screenBounds.y + 5)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.y < (screenBounds.y + 5)*-1)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.x > screenBounds.x + 5)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.x < (screenBounds.x + 5)*-1)
        {
            Destroy(gameObject);
        }
    }
    void mover4()
    {
        timer += Time.deltaTime;
        if(timer >= 3)
        {
            ClonPedazos = Instantiate(pedazosOriginal)as GameObject; 
            ClonPedazos.GetComponent<EmptyAsteroids>().setPosicionInicialX(gameObject.transform.position.x);
            ClonPedazos.GetComponent<EmptyAsteroids>().setPosicionInicialY(gameObject.transform.position.y);
            Destroy(gameObject);
        }
    }
    void moverTrozos()
    {
        if(gameObject.transform.position.y > screenBounds.y + 3)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<EmptyAsteroids>().restarCantidad();
        }
        else if(gameObject.transform.position.y < (screenBounds.y + 3)*-1)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<EmptyAsteroids>().restarCantidad();
        }
        else if(gameObject.transform.position.x > screenBounds.x + 3)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<EmptyAsteroids>().restarCantidad();
        }
        else if(gameObject.transform.position.x < (screenBounds.x + 3)*-1)
        {
            Destroy(gameObject);
            gameObject.transform.parent.gameObject.GetComponent<EmptyAsteroids>().restarCantidad();
        }
    }

}
