using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class IniciarSesionJugador : MonoBehaviour
{
    public Leaderboard leaderBoard;
    void Start()
    {
        StartCoroutine(SetUp());
    }
    IEnumerator SetUp()
    {
        yield return IniciarSesion();
    }
    IEnumerator IniciarSesion()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response)=>
        {
            if(response.success)
            {
                Debug.Log("Exito al iniciar sesion");
                done = true;
            }
            else
            {
                Debug.Log("Falla al iniciar sesion"+response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(()=> done == false);
    }
}
