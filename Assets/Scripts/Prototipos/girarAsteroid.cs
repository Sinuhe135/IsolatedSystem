using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girarAsteroid : MonoBehaviour
{
    public float factorRotacion;
    float rotacion = 0;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rotacion = 350;
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * rotacion);
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += factorRotacion*Time.deltaTime;
        if(rotacion >=360)
        {
            rotacion = 0;
        }
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * rotacion);

        gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * 0);

        if(gameObject.transform.GetChild(0).gameObject.transform.position.y > screenBounds.y + 3)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.GetChild(0).gameObject.transform.position.y < (screenBounds.y + 1)*-3)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.GetChild(0).gameObject.transform.position.x > screenBounds.x + 3)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.GetChild(0).gameObject.transform.position.x < (screenBounds.x + 3)*-1)
        {
            Destroy(gameObject);
        }
    }
}
