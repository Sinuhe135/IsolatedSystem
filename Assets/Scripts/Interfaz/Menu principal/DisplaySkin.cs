using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySkin : MonoBehaviour
{
    public Sprite skinD;
    public Sprite skin1;
    public Sprite skin2;
    public Sprite skin3;
    public Sprite skin4;
    public Sprite skin5;
    public Sprite skinSpecial;
    public void changeShowSkin(int indiceSkin)
    {
        switch(indiceSkin)
        {
            case 0:
                GetComponent<Image>().sprite = skinD;
            break;
            case 1:
                GetComponent<Image>().sprite = skin1;
            break;
            case 2:
                GetComponent<Image>().sprite = skin2;
            break;
            case 3:
                GetComponent<Image>().sprite = skin3;
            break;
            case 4:
                GetComponent<Image>().sprite = skin4;
            break;
            case 5:
                GetComponent<Image>().sprite = skin5;
            break;
            case 6:
                GetComponent<Image>().sprite = skinSpecial;
            break;
            default:
                Debug.Log("Skin error");
            break;
        }
    }
}
