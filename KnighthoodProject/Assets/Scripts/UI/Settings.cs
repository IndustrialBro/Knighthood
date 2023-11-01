using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void HandleFullScreen(bool b)
    {
        Screen.fullScreen = b;
    }

    private void LoadSettings()
    {
        //TODO: naèítání nastavení ze souboru
    }
}
