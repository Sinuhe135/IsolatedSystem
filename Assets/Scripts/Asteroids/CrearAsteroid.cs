using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearAsteroid : MonoBehaviour
{

    public GameObject AsteroidOriginal1;
    public GameObject AsteroidOriginal2;
    public GameObject AsteroidOriginal3;
    public GameObject AsteroidOriginal4;
    public GameObject AsteroidOriginal5;

    public GameObject AsteroidOriginalC;
    public GameObject AsteroidOriginalF;
    public GameObject AsteroidOriginalG;

    GameObject ClonAsteroid;
    public GameObject AsteroidContainer;

    public static int pasandoG = 0;

    float tiempo;
    public bool desactivarDanger = false;
    public bool desactivar = false;
    public bool tutorial = true;

    float radioAparicion = 0f;
    float tiempoEspera = 0f;
    float velocidad = 0f;

    float radio = 0f;
    public float tiempoExplotar = 0f;

    public float radioAparicionG = 0f;
    public float tiempoEsperaG = 0f;
    public float velocidadG = 0f;
    
    float tiempoParaG = 0f;

    public float radioAparicion1 = 0f;
    public float tiempoEspera1 = 0f;
    public float velocidad1 = 0f;

    public float radioAparicion2 = 0f;
    public float tiempoEspera2 = 0f;
    public float velocidad2 = 0f;

    public float radioAparicion3 = 0f;
    public float tiempoEspera3 = 0f;
    public float velocidad3 = 0f;

    public float radioAparicion4 = 0f;
    public float tiempoEspera4 = 0f;
    public float velocidad4 = 0f;

    public float radioAparicion5 = 0f;
    public float tiempoEspera5 = 0f;
    public float velocidad5 = 0f;
    public bool estaEnMenu = false;

    float posicionInicialX = 0f;
    float posicionInicialY = 0f;
    float angulo = 0f;

    float sentido = 0f;
    float tiempoCurva = 0f;
    float sumarX = 0f;
    float sumarY = 0f;

    int limiteNivel = 0;

    void Start()
    {
        level1();
        if(tutorial)
        {
            desactivarAsteroids();
        }
        else
        {
            tiempo = 0;
            tiempoParaG = (radioAparicionG*3)/4;
            
        }
    }

    void Update()
    {
        if(desactivar == false)
        {
            tiempo += Time.deltaTime;

            if (tiempo >= radioAparicion && radioAparicion > 0)
            {
                tiempo = 0;
                int numeroAsteroid = Random.Range(1,limiteNivel);

                switch(numeroAsteroid)
                {
                    case 1:
                        ClonAsteroid = Instantiate(AsteroidOriginal1)as GameObject; 
                    break;
                    case 2:
                        ClonAsteroid = Instantiate(AsteroidOriginal2)as GameObject;
                    break;
                    case 3:
                        ClonAsteroid = Instantiate(AsteroidOriginal3)as GameObject;
                    break;
                    case 4:
                        ClonAsteroid = Instantiate(AsteroidOriginal4)as GameObject;
                    break;
                    case 5:
                        ClonAsteroid = Instantiate(AsteroidOriginal5)as GameObject;
                    break;
                    case 6:
                        crearAsteroidC();
                    break;
                    case 7:
                        crearAsteroidF();
                    break;
                }
                
                ClonAsteroid.transform.parent = AsteroidContainer.transform;  
                
                if(numeroAsteroid >= 1 && numeroAsteroid <=5)
                {
                    parametrizarAsteroid();
                }
            }

            if(!estaEnMenu)
                aparecerG();
        }
    }

    void aparecerG()
    {
        if(velocidad >= velocidad2)
        {
            tiempoParaG += Time.deltaTime;
            
            if(tiempoParaG >= radioAparicionG)
            {
                tiempoParaG = 0;
                crearAsteroidG();
            }
        }
    }

    void parametrizarAsteroid()
    {
        ClonAsteroid.GetComponent<MoverAsteroid>().setVelocidad(velocidad);
        ClonAsteroid.GetComponent<MoverAsteroid>().setTiempoEspera(tiempoEspera);

        calcularPosicion();
        ClonAsteroid.GetComponent<MoverAsteroid>().setX(posicionInicialX);
        ClonAsteroid.GetComponent<MoverAsteroid>().setY(posicionInicialY);
        ClonAsteroid.GetComponent<MoverAsteroid>().setAng(angulo);
                            
        gameObject.GetComponent<CrearDanger>().crear(posicionInicialX, posicionInicialY, tiempoEspera, desactivarDanger,0 , 0);
    }
    void crearAsteroidC()
    {
        ClonAsteroid = Instantiate(AsteroidOriginalC)as GameObject;
        ClonAsteroid.GetComponent<MoverAsteroidC>().setTiempoEspera(tiempoEspera);

        calcularPosicionC();
        ClonAsteroid.GetComponent<MoverAsteroidC>().setX(posicionInicialX);
        ClonAsteroid.GetComponent<MoverAsteroidC>().setY(posicionInicialY);
        ClonAsteroid.GetComponent<MoverAsteroidC>().setSent(sentido);
        ClonAsteroid.GetComponent<MoverAsteroidC>().setRad(radio);
        ClonAsteroid.GetComponent<MoverAsteroidC>().setTiempCurv(tiempoCurva);
                                
        gameObject.GetComponent<CrearDanger>().crear(posicionInicialX, posicionInicialY, tiempoEspera, desactivarDanger, sumarX, sumarY);
    }
    void crearAsteroidF()
    {
        ClonAsteroid = Instantiate(AsteroidOriginalF)as GameObject;

        ClonAsteroid.GetComponent<MoverAsteroidF>().setVelocidad(velocidad);
        ClonAsteroid.GetComponent<MoverAsteroidF>().setTiempoEspera(tiempoEspera);
        ClonAsteroid.GetComponent<MoverAsteroidF>().setTiempExp(tiempoExplotar);

        calcularPosicion();
        ClonAsteroid.GetComponent<MoverAsteroidF>().setX(posicionInicialX);
        ClonAsteroid.GetComponent<MoverAsteroidF>().setY(posicionInicialY);
        ClonAsteroid.GetComponent<MoverAsteroidF>().setAng(angulo);
                                
        gameObject.GetComponent<CrearDanger>().crear(posicionInicialX, posicionInicialY, tiempoEspera, desactivarDanger,0 , 0);
    }
    void crearAsteroidG()
    {
        ClonAsteroid = Instantiate(AsteroidOriginalG)as GameObject;

        ClonAsteroid.GetComponent<MoverAsteroid>().setVelocidad(velocidadG);
        ClonAsteroid.GetComponent<MoverAsteroid>().setTiempoEspera(tiempoEsperaG);

        calcularPosicionG();
        ClonAsteroid.GetComponent<MoverAsteroid>().setX(posicionInicialX);
        ClonAsteroid.GetComponent<MoverAsteroid>().setY(posicionInicialY);
        ClonAsteroid.GetComponent<MoverAsteroid>().setAng(angulo);
                                
        gameObject.GetComponent<CrearDanger>().crear(posicionInicialX, posicionInicialY, tiempoEsperaG, desactivarDanger,0 , 0);
    }

    void calcularPosicion()
    {
        int numLado = Random.Range(1, 5);
        switch(numLado)
        {
            case 1:
                //Arriba
                posicionInicialX = Random.Range(-7f, 7f);
                posicionInicialY = 6f;

                angulo = Random.Range(225f, 315);
            break;
            case 2:
                //Abajo
                posicionInicialX = Random.Range(-7f, 7f);
                posicionInicialY = -6f;

                angulo = Random.Range(45f, 135f);
            break;

            case 3:
                //Izquierda
                posicionInicialX = -10f;
                posicionInicialY = Random.Range(-3f, 3f);

                angulo = Random.Range(-45f, 45f);
            break;
            case 4:
                //Derecha
                posicionInicialX = 10f;
                posicionInicialY = Random.Range(-3f,3f);

                angulo = Random.Range(135f, 225f);
            break;
        }
    }
    void calcularPosicionC()
    {
        int numLado = Random.Range(1, 5);
        
        switch(numLado)
        {
            case 1:
                //Arriba
                posicionInicialX = Random.Range(-7f, 7f);
                if(posicionInicialX >0)
                {
                    sumarX = +5;
                    posicionInicialX-=5;
                    sentido = -1f;
                    tiempoCurva = 0;
                    
                }
                else
                {
                    sumarX = -5;
                    posicionInicialX+=5;
                    sentido = 1f;
                    tiempoCurva = Mathf.PI;
                }
                sumarY = 0;
                posicionInicialY = 6f;
                radio = 7;

            break;
            case 2:
                //Abajo
                posicionInicialX = Random.Range(-7f, 7f);
                posicionInicialY = -6f;
                sumarY = 0;
                if(posicionInicialX >=0)
                {
                    sumarX = +5;
                    posicionInicialX-=5;
                    sentido = 1f;
                    tiempoCurva = 0;
                }
                else
                {
                    sumarX = -5;
                    posicionInicialX+=5;
                    sentido = -1f;
                    tiempoCurva = Mathf.PI;
                }
                radio = 7;

            break;

            case 3:
                //Izquierda
                posicionInicialX = -10f;
                sumarX = 0;
                posicionInicialY = Random.Range(-3f, 3f);
                if(posicionInicialY >=0)
                {
                    sumarY = 5;
                    posicionInicialY-=5;
                    sentido = -1f;
                    tiempoCurva = Mathf.PI/2;
                }
                else
                {
                    sumarY = -5;
                    posicionInicialY+=5;
                    sentido = 1f;
                    tiempoCurva = Mathf.PI*3/2;
                }
                radio = 5;
            break;
            case 4:
                //Derecha
                posicionInicialX = 10f;
                sumarX = 0;
                posicionInicialY = Random.Range(-3f,3f);
                if(posicionInicialY >=0)
                {
                    sumarY = 5;
                    posicionInicialY-=5;
                    sentido = 1f;
                    tiempoCurva = Mathf.PI/2;
                }
                else
                {
                    sumarY = -5;
                    posicionInicialY+=5;
                    sentido = -1f;
                    tiempoCurva = Mathf.PI*3/2;
                }
                radio = 5;
            break;
        }
    }

    void calcularPosicionG()
    {
        int numLado = Random.Range(1, 3);
        switch(numLado)
        {
            case 1:
                //Arriba - izquierda
                posicionInicialX = -3.5f;
                posicionInicialY = 10f;

                angulo = 265;
                //pasandoG = 2;
            break;
            case 2:
                //Arriba - Derecha
                posicionInicialX = 3.5f;
                posicionInicialY = 10f;

                angulo = 275;
                //pasandoG = 1;
            break;

            case 3:
                //Abajo - izquierda
                posicionInicialX = -3.5f;
                posicionInicialY = -10f;

                angulo = 95;
                //pasandoG = 2;
            break;
            case 4:
                //Abajo - Derecha
                posicionInicialX = 3.5f;
                posicionInicialY = -10f;

                angulo = 85;
                //pasandoG = 1;
            break;
            
        }
    }
    
    public void desactivarAsteroids()
    {
        desactivar = true;
        tiempo = 0;
        //tiempoParaG = (radioAparicionG*3)/4;
        tiempoParaG = radioAparicionG-1;
    }

    public void activarAsteroids()
    {
        desactivar = false;
    }

    public void level1()
    {
        radioAparicion = radioAparicion1;
        tiempoEspera = tiempoEspera1;
        velocidad = velocidad1;

        limiteNivel = 6;
    }

    public void level2()
    {
        radioAparicion = radioAparicion2;
        tiempoEspera = tiempoEspera2;
        velocidad = velocidad2;

    }

    public void level3()
    {
        radioAparicion = radioAparicion3;
        tiempoEspera = tiempoEspera3;
        velocidad = velocidad3;

        limiteNivel = 7;
    }

    public void level4()
    {
        radioAparicion = radioAparicion4;
        tiempoEspera = tiempoEspera4;
        velocidad = velocidad4;

        limiteNivel = 8;
    }

    public void level5()
    {
        radioAparicion = radioAparicion5;
        tiempoEspera = tiempoEspera5;
        velocidad = velocidad5;
    }
}
