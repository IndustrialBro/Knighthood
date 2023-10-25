using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MainMenu
{
    [SerializeField]
    GameObject escMenu;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OpenOrCloseMenu(escMenu);
        }
    }
}
