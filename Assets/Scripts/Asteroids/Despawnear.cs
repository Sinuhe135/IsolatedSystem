using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawnear : MonoBehaviour
{
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    public void checarDespawneo(float margen)
    {
        if(gameObject.transform.position.y > screenBounds.y + margen)
        {
            quitarPasando(margen);
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.y < (screenBounds.y + margen)*-1)
        {
            quitarPasando(margen);
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.x > screenBounds.x + margen)
        {
            quitarPasando(margen);
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.x < (screenBounds.x + margen)*-1)
        {
            quitarPasando(margen);
            Destroy(gameObject);
        }
    }
    void quitarPasando(float margen)
    {
        if(margen == 5)
        {
            CrearAsteroid.pasandoG = 0;
        }
    }
}
