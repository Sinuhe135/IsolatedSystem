using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRockySkin : MonoBehaviour
{
    public Sprite skinD;
    public Sprite skin1;
    public Sprite skin2;
    public Sprite skin3;
    public Sprite skin4;
    public Sprite skin5;
    public Sprite skinSpecial;

    int indiceSkin;
    void changeSkin()
    {
        switch(indiceSkin)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = skinD;
            break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = skin1;
            break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = skin2;
            break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = skin3;
            break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = skin4;
            break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = skin5;
            break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = skinSpecial;
            break;
            default:
                Debug.Log("Skin error");
            break;
        }
    }
    void Start()
    {
        indiceSkin = PlayerPrefs.GetInt("SkinNumber", 0);
        changeSkin();
    }

}
