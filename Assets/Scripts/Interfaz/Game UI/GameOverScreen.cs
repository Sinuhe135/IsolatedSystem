using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public Text finalScoreText;
    public Text finalHighText;
    public Text actualLevelText;
    public Text levelText;
    public Text nextLevelText;

    public GameObject congratulations;
    public GameObject congratulationsLevel;

    public Text congratulationsLevelText;

    public acercarAlejarCam movimientoCamara;
    public MainUI interfaz;

    public DifficultyManager dificultad;

    public void Setup()
    {
        movimientoCamara.activarAcercando();
        gameObject.SetActive(true);
        interfaz.SetDown();
        finalScoreText.text = "Score: "+ScoreManager.score.ToString();
        finalHighText.text = "HighScore: "+PlayerPrefs.GetInt("HighScoreSave", 0);
        
        nextLevelText.text = dificultad.textoPuntosPara(PlayerPrefs.GetInt("HighLevelSave", 1));

        ScoreManagerStuff();

    }
    void ScoreManagerStuff()
    {
        if(PlayerPrefs.GetInt("HighLevelSave", 1)>5)
        {
            levelText.text = "High Level: "+(PlayerPrefs.GetInt("HighLevelSave", 1)-1);
        }
        else
        {
            levelText.text = "High Level: "+PlayerPrefs.GetInt("HighLevelSave", 1);
        }

        if(ScoreManager.level>5)
        {
            actualLevelText.text = "Level "+(ScoreManager.level-1);
        }
        else
        {
            actualLevelText.text = "Level "+ScoreManager.level;
        }

        if (ScoreManager.newHighScored)
        {
            congratulations.SetActive(true);
        }
        else
        {
            congratulations.SetActive(false);
        }

        if(ScoreManager.newHighLeveled)
        {
            congratulationsLevel.SetActive(true);
            if(PlayerPrefs.GetInt("HighLevelSave", 1)==6)
            {
                congratulationsLevelText.text = "Final skin unlocked";
            }
        }
        else
        {
            congratulationsLevel.SetActive(false);
        }

    }
    public void Setdown()
    {
        gameObject.SetActive(false);
        interfaz.SetUp();
    }
}
