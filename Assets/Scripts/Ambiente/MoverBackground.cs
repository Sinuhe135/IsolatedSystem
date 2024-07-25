using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBackground : MonoBehaviour
{
    public float velocidadBackground;
    public GameObject clonBackground;

    bool tieneIzquierda = false;

    private Vector2 screenBounds;
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            
        
    }

    
    void Update()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x+velocidadBackground*Time.deltaTime,gameObject.GetComponent<Transform>().position.y, 0);
        if(gameObject.GetComponent<Transform>().position.x >= 0 && !tieneIzquierda)
        {
            float tamano = -2*screenBounds.x;
            Vector3 vector = new Vector3(tamano, gameObject.GetComponent<Transform>().position.y,0);
            Instantiate(clonBackground,vector,Quaternion.Euler(Vector3.forward * 0));
            tieneIzquierda = true;
        }
        if(gameObject.GetComponent<Transform>().position.x >=2*screenBounds.x+2)
        {
            Destroy(gameObject);
        }
    }
}
