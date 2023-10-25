using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void HandleFullScreen(bool b)
    {
        Screen.fullScreen = b;
    }
}
