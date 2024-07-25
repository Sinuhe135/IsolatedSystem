using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public int fps;

    void Start()
    {
        Application.targetFrameRate = fps;
    }
}
