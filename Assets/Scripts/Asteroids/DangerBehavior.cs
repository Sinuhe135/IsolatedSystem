using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBehavior : MonoBehaviour
{
    public float factorTransparencia;

    float transparencia;
    float tiempo = 0;


    void Start()
    {
        if(!(gameObject.transform.position.x == 3.5f || gameObject.transform.position.x == -3.5f))
        {
            if(gameObject.transform.position.y != 0.5f)
            {
                this.enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        }

    }
    void Update()
    {
        transparencia = Mathf.Sin(tiempo);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,transparencia);
        tiempo += Time.deltaTime * factorTransparencia;
        

    }
}
