using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    
    public pauseScreen pause;
    public static bool running = true;

    void Update()
    {
        if(Input.GetKeyDown("escape") && MoverRocky.vivo)
        {
            if (running)
            {
                pause.Setup();
            }
            else
            {
                pause.Setdown();
            }
        }
    }
}
