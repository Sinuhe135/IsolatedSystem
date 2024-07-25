using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverClones : MonoBehaviour
{
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void activarEnPantalla()
    {
        if(gameObject.transform.position.y > screenBounds.y || gameObject.transform.position.y < screenBounds.y*-1 || gameObject.transform.position.x > screenBounds.x || gameObject.transform.position.x < screenBounds.x*-1)
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    public void mover(float coordX, float coordY)
    {
        gameObject.GetComponent<Transform>().position = new Vector3(coordX, coordY, 0);
    }

    public void rotar(float valorRotacion)
    {
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * valorRotacion);
    }

    public void llamas(bool encendidas, bool normales)
    {
        if(encendidas)
        {
            if(normales)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void morir()
    {
        gameObject.SetActive(false);
    }

    public void respawn()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        rotar(0f);
        llamas(false, true);
    }

    public void afterRespawn()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }
}
