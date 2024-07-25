using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRocky : MonoBehaviour
{
    public float multiplicadorVelocidad = 1f;

    float velocidadX = 0f;
    public float velocidadXTotal = 0f;

    float velocidadY = 0f;
    public float velocidadYTotal = 0f;
    
    public float aceleracion = 0f;

    public float factorRotacion = 0f;
    float valorRotacion = 0f;

    bool llamasActivadas = false;
    bool llamasNormales = false;
    public static bool vivo = true;

    public float tiempoRespawn = 0f;
    float time = 0f;
    public static bool justRespawned = false;

    public float cantidadTurbo = 0f;
    float turbo = 1f;

    public float multiCombTurbo = 0f;
    public float restarCombCons = 0f;
    float combustible = 100f;
    public float restarComb = 0f;
    public float sumarComb = 0f;

    public static bool tutorial = true;

    public MoverClones ClonU;
    public MoverClones ClonD;
    public MoverClones ClonR;
    public MoverClones ClonL;
    public MoverClones ClonUL;
    public MoverClones ClonUR;
    public MoverClones ClonDL;
    public MoverClones ClonDR;

    private Vector2 screenBounds;

    public SonidoLlamas sonidoPropulsion;
    public SonidoLlamas sonidoAlerta;
    public GameObject sonidoMorir;

    GameObject ClonSonidoMorir;

    void Start()
    {
        vivo = true;
        tutorial = true;
        gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        ScoreManager.instanceScore.desplegarFuel(combustible);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if(PauseManager.running)
        {
            moverPersonaje();
            controlarClones();
            if(justRespawned)
            {
                afterRespawn();
            }
        }
    }

    void activarEnPantalla()
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

    public void respawn()
    {
        vivo = true;
        justRespawned = true;
        velocidadX = 0;
        velocidadY = 0;
        gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * 0);
        valorRotacion = 0;
        restaurarComb(true);
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        controlarClones();
        Destroy(ClonSonidoMorir, 0f);

        ClonU.respawn();
        ClonD.respawn();
        ClonL.respawn();
        ClonR.respawn();
        ClonUL.respawn();
        ClonUR.respawn();
        ClonDL.respawn();
        ClonDR.respawn();

    }

    void afterRespawn()
    {
        time+=Time.deltaTime;
        if(time >= tiempoRespawn)
        {
            time = 0;
            justRespawned = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1f);
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1f);
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1f);
            ClonU.afterRespawn();
            ClonD.afterRespawn();
            ClonL.afterRespawn();
            ClonR.afterRespawn();
            ClonUL.afterRespawn();
            ClonUR.afterRespawn();
            ClonDL.afterRespawn();
            ClonDR.afterRespawn();
        }
    }

    public void morir()
    {
        vivo = false;
        gameObject.SetActive(false);
        sonidoPropulsion.desactivar();
        sonidoAlerta.desactivar();

        ClonSonidoMorir = Instantiate(sonidoMorir)as GameObject;
        float volumen = getVelocidad() * 0.25f/50f;
        if(volumen < 0.2f)
        {
            volumen = 0.2f;
        }
        else if(volumen > 5f)
        {
            volumen = 5f;
        }
            ClonSonidoMorir.GetComponent<AudioSource>().volume = volumen;
        

        ClonU.morir();
        ClonD.morir();
        ClonL.morir();
        ClonR.morir();
        ClonUL.morir();
        ClonUR.morir();
        ClonDL.morir();
        ClonDR.morir();

    }

    public float getRotacion()
    {
        return valorRotacion;
    }
    public float getVelocidad()
    {
        return (Mathf.Pow(Mathf.Pow(velocidadXTotal,2) + Mathf.Pow(velocidadYTotal,2),0.5f));
    }

    public void restaurarComb(bool muerto)
    {
        factorRotacion = 550;
        sonidoAlerta.desactivar();
        if (muerto)
        {
            combustible = 100f;
        }
        else if(combustible == 0)
        {
            combustible += sumarComb*2;
        }
        else
        {
            combustible += sumarComb;
        }
    
        if(combustible > 100)
        {
            combustible = 100f;
        }
        ScoreManager.instanceScore.desplegarFuel(combustible);

    }

    void controlarLlamas(bool encendidas, bool normales)
    {
        if(encendidas)
        {
            llamasActivadas = true;
            if(normales)
            {
                llamasNormales = true;
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                llamasNormales = false;
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            llamasActivadas = false;
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void controlarClones()
    {
        ClonU.mover(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y+10f);
        ClonR.mover(gameObject.GetComponent<Transform>().position.x+18f, gameObject.GetComponent<Transform>().position.y);
        ClonD.mover(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y-10f);
        ClonL.mover(gameObject.GetComponent<Transform>().position.x-18f, gameObject.GetComponent<Transform>().position.y);
        ClonUL.mover(gameObject.GetComponent<Transform>().position.x-18f, gameObject.GetComponent<Transform>().position.y+10f);
        ClonUR.mover(gameObject.GetComponent<Transform>().position.x+18f, gameObject.GetComponent<Transform>().position.y+10f);
        ClonDL.mover(gameObject.GetComponent<Transform>().position.x-18f, gameObject.GetComponent<Transform>().position.y-10f);
        ClonDR.mover(gameObject.GetComponent<Transform>().position.x+18f, gameObject.GetComponent<Transform>().position.y-10f);


        ClonU.rotar(valorRotacion);
        ClonD.rotar(valorRotacion);
        ClonL.rotar(valorRotacion);
        ClonR.rotar(valorRotacion);
        ClonUL.rotar(valorRotacion);
        ClonUR.rotar(valorRotacion);
        ClonDL.rotar(valorRotacion);
        ClonDR.rotar(valorRotacion);

        ClonU.llamas(llamasActivadas, llamasNormales);
        ClonD.llamas(llamasActivadas, llamasNormales);
        ClonL.llamas(llamasActivadas, llamasNormales);
        ClonR.llamas(llamasActivadas, llamasNormales);
        ClonUL.llamas(llamasActivadas, llamasNormales);
        ClonUR.llamas(llamasActivadas, llamasNormales);
        ClonDL.llamas(llamasActivadas, llamasNormales);
        ClonDR.llamas(llamasActivadas, llamasNormales);
        

        if(justRespawned==false)
        {
            ClonU.activarEnPantalla();
            ClonD.activarEnPantalla();
            ClonL.activarEnPantalla();
            ClonR.activarEnPantalla();
            ClonUL.activarEnPantalla();
            ClonUR.activarEnPantalla();
            ClonDL.activarEnPantalla();
            ClonDR.activarEnPantalla();
        }

    }

    public void transportar()
    {
        if(gameObject.transform.position.y > screenBounds.y + 1.5f)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y-10, 0);
        }
        else if(gameObject.transform.position.y < (screenBounds.y + 1.5f)*-1)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y+10, 0);
        }
        else if(gameObject.transform.position.x > screenBounds.x + 1.5f)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x-18, gameObject.GetComponent<Transform>().position.y, 0);
        }
        else if(gameObject.transform.position.x < (screenBounds.x + 1.5f)*-1)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x+18, gameObject.GetComponent<Transform>().position.y, 0);
        }
        
    }

    void moverPersonaje()
    {
        if((Input.GetKey("a") || Input.GetKey("left")) && (Input.GetKey("w") || Input.GetKey("up")))
        {
            rotar(5);
            acelerar(5);
        }
        else if((Input.GetKey("a") || Input.GetKey("left")) && (Input.GetKey("s") || Input.GetKey("down")))
        {
            rotar(6);
            acelerar(6);
        }
        else if((Input.GetKey("d") || Input.GetKey("right")) && (Input.GetKey("w") || Input.GetKey("up")))
        {
            rotar(7);
            acelerar(7);
        }
        else if((Input.GetKey("d") || Input.GetKey("right")) && (Input.GetKey("s") || Input.GetKey("down")))
        {
            rotar(8);
            acelerar(8);
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rotar(1);
            acelerar(1);
        }
        else if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rotar(2);
            acelerar(2);
        }
        else if(Input.GetKey("s") || Input.GetKey("down"))
        {
            rotar(3);
            acelerar(3);
        }
        else if(Input.GetKey("w") || Input.GetKey("up"))
        {
            rotar(4);
            acelerar(4);
        }
        else
        {
            if(combustible <= 0)
            {
                sonidoAlerta.activar();
            }
            else if(!tutorial)
            {
                combustible = combustible - restarCombCons *Time.deltaTime;
                ScoreManager.instanceScore.desplegarFuel(combustible);
            }
            sonidoPropulsion.desactivar();
            controlarLlamas(false, true);

            //Debug.Log(getVelocidad());
        }
        
        velocidadXTotal = velocidadX*multiplicadorVelocidad;
        velocidadYTotal = velocidadY*multiplicadorVelocidad;

        gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x+velocidadXTotal * Time.deltaTime, gameObject.GetComponent<Transform>().position.y+velocidadYTotal* Time.deltaTime, 0);
        
        transportar();
        activarEnPantalla();
    }

    void acelerar(int tecla)
    {
        /*
            1 = izquierda
            2 = derecha
            3 = abajo
            4 = arriba
            5 = arriba-izquierda
            6 = abajo-izquierda
            7 = arriba-derecha
            8 = abajo-derecha
        */
        if(combustible > 0)
        {
            if(Input.GetKey("space"))
            {
                sonidoPropulsion.subir();
                turbo = cantidadTurbo;
                if(!tutorial)
                {
                    combustible = combustible - restarComb * multiCombTurbo *Time.deltaTime;
                }
                controlarLlamas(true, false);
            }
            else
            {
                sonidoPropulsion.bajar();
                turbo = 1f;
                if(!tutorial)
                {
                    combustible = combustible - restarComb *Time.deltaTime;
                }
                controlarLlamas(true, true);
            }
            sonidoPropulsion.activar();
            switch(tecla)
            {
                case 1:
                    velocidadX -= aceleracion *turbo* Time.deltaTime;
                break;
                case 2:
                    velocidadX += aceleracion *turbo* Time.deltaTime;
                break;
                case 3:
                    velocidadY -= aceleracion *turbo* Time.deltaTime;
                break;
                case 4:
                    velocidadY += aceleracion *turbo* Time.deltaTime;
                break;
                case 5:
                    velocidadY += aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                    velocidadX -= aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                break;
                case 6:
                    velocidadY -= aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                    velocidadX -= aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                break;
                case 7:
                    velocidadY += aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                    velocidadX += aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                break;
                case 8:
                    velocidadY -= aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                    velocidadX += aceleracion*turbo*Mathf.Cos(45*Mathf.PI/180) * Time.deltaTime;
                break;
            }
        }
        else
        {
            sonidoAlerta.activar();
            sonidoPropulsion.bajar();
            turbo = 1f;
            combustible = 0;

            sonidoPropulsion.desactivar();
            controlarLlamas(false, true);

            factorRotacion = 200;
        }
        ScoreManager.instanceScore.desplegarFuel(combustible);
    }

    void rotar(int tecla)
    {
        switch(tecla)
        {
            case 1:
                
                if((valorRotacion < 90 && valorRotacion >= 0) || (valorRotacion < 360 && valorRotacion >= 270))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if(valorRotacion > 90 && valorRotacion < 180)
                    {
                        valorRotacion = 90;
                    }
                }
                else if((valorRotacion > 90 && valorRotacion < 180) || (valorRotacion >= 180 && valorRotacion < 270))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if(valorRotacion < 90)
                    {
                        valorRotacion = 90;
                    }
                }
                
                
            break;
            case 2:
                
                if((valorRotacion < 90 && valorRotacion >= 0) || (valorRotacion < 360 && valorRotacion > 270))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if(valorRotacion < 270 && valorRotacion > 180)
                    {
                        valorRotacion = 270;
                    }
                    
                }
                else if((valorRotacion >= 90 && valorRotacion < 180) || (valorRotacion >= 180 && valorRotacion < 270))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if(valorRotacion > 270)
                    {
                        valorRotacion = 270;
                    }
                }
                
            break;
            case 3:
                
                if((valorRotacion < 90 && valorRotacion >= 0) || (valorRotacion >= 90 && valorRotacion < 180))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if(valorRotacion > 180)
                    {
                        valorRotacion = 180;
                    }
                    
                }
                else if((valorRotacion < 360 && valorRotacion >= 270) || (valorRotacion > 180 && valorRotacion < 270))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if (valorRotacion < 180)
                    {
                        valorRotacion = 180;
                    }
                }
               
            break;
            case 4:
                
                if((valorRotacion < 90 && valorRotacion > 0) || (valorRotacion >= 90 && valorRotacion < 180))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if (valorRotacion <0)
                    {
                        valorRotacion = 0;
                    }
                    
                }
                else if((valorRotacion < 360 && valorRotacion >= 270) || (valorRotacion >= 180 && valorRotacion < 270))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if(valorRotacion > 360)
                    {
                        valorRotacion = 0;
                    }
                }
                
            break;
            case 5:
                
                if((valorRotacion > 45 && valorRotacion <= 135) || (valorRotacion > 135 && valorRotacion <= 225))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if(valorRotacion < 45)
                    {
                        valorRotacion = 45;
                    }
                    
                }
                else if((valorRotacion > 225 && valorRotacion <= 315) || (valorRotacion > 315 && valorRotacion < 360) || (valorRotacion >= 0 && valorRotacion < 45))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if(valorRotacion > 45 && valorRotacion < 90)
                    {
                        valorRotacion = 45;
                    }
                }
                
            break;
            case 6:
                
                if((valorRotacion > 135 && valorRotacion <= 225) || (valorRotacion > 225 && valorRotacion <= 315))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if(valorRotacion<135)
                    {
                        valorRotacion = 135;
                    }
                    
                }
                else if((valorRotacion < 135 && valorRotacion >= 45) || (valorRotacion < 45 && valorRotacion >= 0) || (valorRotacion < 360 && valorRotacion > 315))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if(valorRotacion>135 && valorRotacion < 180)
                    {
                        valorRotacion = 135;
                    }
                }
                
            break;
            case 7:
                
                if((valorRotacion < 315 && valorRotacion >= 225) || (valorRotacion < 225 && valorRotacion >= 135))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if (valorRotacion >315)
                    {
                        valorRotacion = 315;
                    }
                    
                }
                else if((valorRotacion > 315 && valorRotacion < 360) || (valorRotacion <= 45 && valorRotacion >= 0) || (valorRotacion > 45 && valorRotacion < 135))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if(valorRotacion < 315 && valorRotacion > 270)
                    {
                        valorRotacion = 315;
                    }
                }
                
            break;
            case 8:
                
                if((valorRotacion > 225 && valorRotacion <= 315) || (valorRotacion > 315 && valorRotacion < 360) || (valorRotacion >= 0 && valorRotacion < 45))
                {
                    valorRotacion -= factorRotacion * Time.deltaTime;
                    if(valorRotacion < 225 && valorRotacion > 270)
                    {
                        valorRotacion = 225;
                    }
                    
                }
                else if((valorRotacion < 225 && valorRotacion >= 135) || (valorRotacion < 135 && valorRotacion >= 45))
                {
                    valorRotacion += factorRotacion * Time.deltaTime;
                    if(valorRotacion > 225)
                    {
                        valorRotacion = 225;
                    }
                }
                
            break;
        }

        valorRotacion = corregirAngulo(valorRotacion);
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(Vector3.forward * valorRotacion);
    }

    float corregirAngulo(float angulo)
    {
        if (angulo >= 360)
        {
            angulo = angulo - 360;
        }
        else if (angulo < 0)
        {
            angulo = 360 + angulo;
        }
        return angulo;
    }
}
