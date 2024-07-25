using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScreen : MonoBehaviour
{
    
    public Button resume;
    public Button menu;

    public GameObject sonidoMenu;
    public MusicManager musica;

    public SonidoLlamas sonidoPropulsion;
    public SonidoLlamas sonidoAlerta;

    

    public void Setup()
    {
        if(MoverRocky.vivo)
        {
            musica.bajarPoquito();
        }
        Pausar();
        gameObject.SetActive(true);
        resume.Select();
    }
    public void Pausar()
    {
        PauseManager.running = false;
        Time.timeScale = 0;
        sonidoPropulsion.desactivar();
        sonidoAlerta.desactivar();
    }
    public void Despausar()
    {
        PauseManager.running = true;
        Time.timeScale = 1;
    }
    public void Setdown()
    {
        if(MoverRocky.vivo)
        {
            musica.subirAlRespawnear();
        }
        Despausar();
        gameObject.SetActive(false);
        menu.Select();
    }

    public void resumeButton()
    {
        GameObject ClonSonidoMenu = Instantiate(sonidoMenu);
        Destroy(ClonSonidoMenu, 0.5f);
        PauseManager.running = true;
        Time.timeScale = 1;
        Setdown();
    }

    public void menuButton()
    {
        //GameObject ClonSonidoMenu = Instantiate(sonidoMenu);
        //Destroy(ClonSonidoMenu, 0.5f);
        PauseManager.running = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void restartButton()
    {
        //GameObject ClonSonidoMenu = Instantiate(sonidoMenu);
        //Destroy(ClonSonidoMenu, 0.5f);
        PauseManager.running = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
