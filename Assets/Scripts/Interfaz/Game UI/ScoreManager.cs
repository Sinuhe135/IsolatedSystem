using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instanceScore;

    public Leaderboard leaderBoard;

    public Text scoreText;
    public Text highScoreText;
    public Text fpsText;
    public Text levelText;
    public Image fuelImage;

    public static int score = 0;
    public static int level = 0;
    public static bool newHighScored = false;
    public static bool newHighLeveled = false;

    //float DeltaTime = 0;

    private void Awake()
    {
        instanceScore = this;
    }

    void Start()
    {
        newHighScored = false;
        score = 0;
        scoreText.text = "Score: " + score.ToString(); 
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScoreSave", 0);
    }

    public void addPoint()
    {
        score+=1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void registerHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScoreSave", 0))
        {
            newHighScored = true;
            PlayerPrefs.SetInt("HighScoreSave", score);
            if(PlayerPrefs.GetString("Username", "") != "")
            {
                StartCoroutine(leaderBoard.EnviarLeaderBoard(score));
            }
        }
        if (level > PlayerPrefs.GetInt("HighLevelSave", 1))
        {
            newHighLeveled = true;
            PlayerPrefs.SetInt("HighLevelSave", level);
        }
    }

    public void reset()
    {
        score=0;
        newHighScored = false;
        newHighLeveled = false;
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScoreSave", 0);
    }

    public void desplegarFuel(float floatFuel)
    {
        fuelImage.fillAmount = floatFuel/100;
    }

    public void addLevel(int nivel, bool mostrado)
    {
        level = nivel;
        if(mostrado)
        {
            if (nivel == 5)
            {
                levelText.color = Color.red;
            }
            else if(nivel == 1)
            {
                levelText.color = Color.white;
            }
            if(nivel >5)
            {
                levelText.text = "Level " + (nivel-1).ToString();
            }
            else
            {
                levelText.text = "Level " + nivel.ToString();
            }
            
        }
        else
        {
            levelText.text = "";
        }
    }

    /*
    public void desplegarFps()
    {
        DeltaTime += (Time.deltaTime - DeltaTime) * 0.1f;
        float fps = 1.0f / DeltaTime;
        fpsText.text = "fps "+Mathf.Ceil (fps).ToString ();
    }
    */
}
