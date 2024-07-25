using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstTimeOpen : MonoBehaviour
{
    public static bool firstStarted = true;
    float transparency = 1f;

    Image img;

    void Start()
    {
        img =  GameObject.Find("PanelEntrada").GetComponent<Image>();
        if(firstStarted)
        {
            img.color = new Color(0,0,0,transparency);
        }
    }

    void Update()
    {
        if(transparency > 0 && firstStarted == true)
        {
        
            transparency -= 0.7f*Time.deltaTime;
            img.color = new Color(0,0,0,transparency);
        }
        else
        {
            firstStarted = false;
            Destroy(gameObject);

        }
    }

}
