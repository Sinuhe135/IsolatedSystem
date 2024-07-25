using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Leaderboard leaderBoard;

    public Button back;
    public Button start;

    public Button backHowTo;
    public Button backLeader;

    public GameObject sonidoMenu;

    public InputField enterName;
    public Button setBackButton;

    public Button skinButton;
    public Button backSkin;

    public Skins skin;

    public void startButton()
    {
        Invoke("actionStart",0.2f);
        firstTimeOpen.firstStarted = false;
        reproducirSonido();
        
    }

    void actionStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void creditsButton()
    {
        reproducirSonido();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        back.Select();
    }
    public void quitButton()
    {
        Invoke("actionQuit",0.2f);
        reproducirSonido();   
    }

    void actionQuit()
    {
        Application.Quit();
    }

    public void backButton()
    {
        reproducirSonido();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).gameObject.SetActive(false);
        start.Select();
    }

    public void howToButton()
    {
        reproducirSonido();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        backHowTo.Select();
    }
    public void leaderButton()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        if(PlayerPrefs.GetString("Username", "") == "")
        {
            setNameButton();
        }
        else
        {
            StartCoroutine(leaderBoard.MostrarLeaderBoard());
            reproducirSonido();
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            backLeader.Select();
        }
        
    }
    public void setNameButton()
    {
        reproducirSonido();
        enterName.text = PlayerPrefs.GetString("Username", "");
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
        setBackButton.Select();
    }
    public void BotonSet()
    {
        reproducirSonido();
        if(enterName.text != "")
        {
            PlayerPrefs.SetString("Username", enterName.text);
            leaderBoard.SetLootLockerPlayerName();
            if(PlayerPrefs.GetInt("HighScoreSave", 0) > 0)
            {
                StartCoroutine(leaderBoard.EnviarLeaderBoard(PlayerPrefs.GetInt("HighScoreSave", 0)));     
            }
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
            backLeader.Select();
        }

    }
    public void SkinButton()
    {
        reproducirSonido();
        skin.inicializarIndice();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
        backSkin.Select();
    }
    void reproducirSonido()
    {
        GameObject ClonSonidoMenu = Instantiate(sonidoMenu);
        Destroy(ClonSonidoMenu, 0.5f);
    }
}
