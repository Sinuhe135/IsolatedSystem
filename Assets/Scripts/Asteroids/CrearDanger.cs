using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearDanger : MonoBehaviour
{
    public GameObject DangerOriginal;
    public GameObject AsteroidContainer;
    public void crear(float posicionInicialX,float posicionInicialY, float tiempoEspera, bool desactivarDanger, float sumarX, float sumarY)
    {
        if(desactivarDanger == false)
        {
            if(posicionInicialX == 10f)
            {
                GameObject ClonDanger = Instantiate(DangerOriginal, new Vector3(8.5f+sumarX, posicionInicialY+sumarY), Quaternion.Euler(Vector3.forward * 0));
                ClonDanger.transform.parent = AsteroidContainer.transform;  
                Destroy(ClonDanger, tiempoEspera);
            }
            else if(posicionInicialX == -10f)
            {
                GameObject ClonDanger = Instantiate(DangerOriginal, new Vector3(-8.5f+sumarX, posicionInicialY+sumarY), Quaternion.Euler(Vector3.forward * 0));
                ClonDanger.transform.parent = AsteroidContainer.transform;  
                Destroy(ClonDanger, tiempoEspera);
            }
            else if(posicionInicialY == -6f)
            {
                GameObject ClonDanger = Instantiate(DangerOriginal, new Vector3(posicionInicialX+sumarX, -4.5f+sumarY), Quaternion.Euler(Vector3.forward * 0));
                ClonDanger.transform.parent = AsteroidContainer.transform;  
                Destroy(ClonDanger, tiempoEspera);
            }
            else if(posicionInicialY == 6f)
            {
                GameObject ClonDanger = Instantiate(DangerOriginal, new Vector3(posicionInicialX+sumarX, 4.5f+sumarY), Quaternion.Euler(Vector3.forward * 0));
                ClonDanger.transform.parent = AsteroidContainer.transform;  
                Destroy(ClonDanger, tiempoEspera);
            }
            else if(posicionInicialX == 3.5f)
            {
                GameObject ClonDanger = Instantiate(DangerOriginal, new Vector3(3.75f,0.5f), Quaternion.Euler(Vector3.forward * 0));
                ClonDanger.transform.localScale = new Vector3(2.8f, 3f, 1f);;
                ClonDanger.transform.parent = AsteroidContainer.transform;  
                Destroy(ClonDanger, tiempoEspera);
            }
            else if(posicionInicialX == -3.5f)
            {
                GameObject ClonDanger = Instantiate(DangerOriginal, new Vector3(-3.75f, 0.5f), Quaternion.Euler(Vector3.forward * 0));
                ClonDanger.transform.localScale = new Vector3(-2.8f, 3f, 1f);
                ClonDanger.transform.parent = AsteroidContainer.transform;  
                Destroy(ClonDanger, tiempoEspera);
            }
        }
    }
}
