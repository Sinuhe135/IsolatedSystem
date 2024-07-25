using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public GameObject sonidoMenu;
    public DisplaySkin skinMostrada;

    int indiceSkin;
    int limiteSkin;

    void Start()
    {
        limiteSkin = PlayerPrefs.GetInt("HighLevelSave", 1);
    }
    void reproducirSonido()
    {
        GameObject ClonSonidoMenu = Instantiate(sonidoMenu);
        Destroy(ClonSonidoMenu, 0.5f);
    }
    public void inicializarIndice()
    {
        indiceSkin = PlayerPrefs.GetInt("SkinNumber", 0);
        skinMostrada.changeShowSkin(indiceSkin);
    }
    public void nextButton()
    {
        reproducirSonido();
        indiceSkin++;
        if(indiceSkin > limiteSkin)
        {
            indiceSkin = 0;
        }
        skinMostrada.changeShowSkin(indiceSkin);
    }
    public void previousButton()
    {
        reproducirSonido();
        indiceSkin--;
        if(indiceSkin < 0)
        {
            indiceSkin = limiteSkin;
        }
        skinMostrada.changeShowSkin(indiceSkin);
    }
    
    public void SetSkinButton()
    {
        reproducirSonido();
        PlayerPrefs.SetInt("SkinNumber", indiceSkin);
    }
}
