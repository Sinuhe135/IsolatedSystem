using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClonSkin : MonoBehaviour
{
    public Sprite skinD;
    public Sprite skin1;
    public Sprite skin2;
    public Sprite skin3;
    public Sprite skin4;
    public Sprite skin5;
    public Sprite skinSpecial;

     Sprite actual;

    void Start()
    {
        switch(PlayerPrefs.GetInt("SkinNumber", 0))
        {
            case 0:
                actual = skinD;
            break;
            case 1:
                actual = skin1;
            break;
            case 2:
                actual = skin2;
            break;
            case 3:
                actual = skin3;
            break;
            case 4:
                actual = skin4;
            break;
            case 5:
                actual = skin5;
            break;
            case 6:
                actual = skinSpecial;
            break;
        }
        for(int i = 0;i<=7;i++)
        {
            gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = actual;
        }
    }


}
