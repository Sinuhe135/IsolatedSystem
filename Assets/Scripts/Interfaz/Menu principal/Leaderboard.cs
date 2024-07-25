using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    int leaderBoardID = 0;

    public Text nombres;
    public Text scores;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator EnviarLeaderBoard(int score)
    {
        Debug.Log("entro");
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, score, leaderBoardID, (response)=>
        {
            if(response.success)
            {
                Debug.Log("Highscore subido");
                done = true;
            }
            else
            {
                Debug.Log("Highscore no subido"+response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(()=> done == false);
    }
    public void SetLootLockerPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(PlayerPrefs.GetString("Username", ""), (response)=>
        {
            if(response.success)
            {
                Debug.Log("Nombre establecido con exito");
            }
            else
            {
                Debug.Log("Error al establecer el nombre");
            }
        });
    }
    public IEnumerator MostrarLeaderBoard()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(leaderBoardID, 5, 0, (response)=>
        {
            if(response.success)
            {
                string textoNombres = "ID\n";
                string textoScores = "Score\n";
                LootLockerLeaderboardMember[] members = response.items;

                for(int i = 0; i<members.Length;i++)
                {
                    //textoNombres+= members[i].rank+". ";
                    if(members[i].player.name != "")
                    {
                        textoNombres+=members[i].player.name;
                    }
                    else
                    {
                        textoNombres+=members[i].player.id;
                    }
                    textoScores+= members[i].score+"\n";
                    textoNombres+="\n";
                }
                done = true;
                nombres.text = textoNombres;
                scores.text = textoScores;
            }
            else
            {
                Debug.Log("Falla al mostrar"+response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(()=>done == false);
    }

}
