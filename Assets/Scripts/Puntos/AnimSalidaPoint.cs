using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSalidaPoint : MonoBehaviour
{
    
    float tamanoP = 0.7f;
    public float disminucionTamano;

    void Update()
    {
        if(tamanoP > 0.1f)
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(tamanoP,tamanoP,1);
            tamanoP-= disminucionTamano* Time.deltaTime;
        }
        else if(tamanoP <=0.1f)
        {
            Destroy(gameObject);
        }
    }
}
