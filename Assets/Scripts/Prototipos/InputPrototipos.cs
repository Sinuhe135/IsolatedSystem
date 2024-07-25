using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPrototipos : MonoBehaviour
{
    public GameObject prot3Original;
    public GameObject prot4Original;
    public GameObject prot5Original;

    GameObject ClonPrototipo;
    void Start()
    {
         Application.targetFrameRate = 60;
    }
    void Update()
    {
        if(Input.GetKeyDown("3"))
        {
            ClonPrototipo = Instantiate(prot3Original)as GameObject; 
        }
        else if(Input.GetKeyDown("4"))
        {
            ClonPrototipo = Instantiate(prot4Original)as GameObject; 
        }
        else if(Input.GetKeyDown("5"))
        {
            ClonPrototipo = Instantiate(prot5Original)as GameObject; 
        }
    }
}
