using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public void SetUp()
    {
        gameObject.SetActive(true);
    }
    public void SetDown()
    {
        gameObject.SetActive(false);
    }
}
