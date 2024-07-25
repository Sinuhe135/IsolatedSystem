using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public MoverRocky Rocky;
    public GameOverScreen GameOverScreen;
    public MusicManager MusicManager;
    public DifficultyManager dificultad;
    public acercarAlejarCam movimientoCamara;

    public GameObject sonidoMenu;

    bool contando = false;
    float tiempo = 0;

    bool permitirRespawnear = false;
    bool gameOver = false;


    void Update()
    {
        if(contando)
        {
            tiempo += Time.deltaTime;
            if(tiempo >= 1)
            {
                tiempo = 0;
                contando = false;
                permitirRespawnear = true;
                gameOver = true;
            }
        }
        if(gameOver)
        {
            GameOverScreen.Setup();
            gameOver = false;
        }
        if(permitirRespawnear)
        {
            respawnear();
        }
    }

    public void activarTimer()
    {
        contando = true;
    }

    void respawnear()
    {
        if((Input.GetKeyDown("space") ||Input.GetKeyDown("return")) && PauseManager.running)
        {
            GameObject ClonSonidoMenu = Instantiate(sonidoMenu);
            Destroy(ClonSonidoMenu, 0.5f);

            movimientoCamara.activarAlejando();
            MusicManager.subirAlRespawnear();
            GameOverScreen.Setdown();

            Rocky.respawn();
            
            ScoreManager.instanceScore.reset();

            dificultad.cambiarDificultad();
            dificultad.activar();

            permitirRespawnear = false;

            Destroy(GameObject.Find("Pedazos(Clone)"));
        }
        else if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
