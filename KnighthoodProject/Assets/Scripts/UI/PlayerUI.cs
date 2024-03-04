using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MainMenu
{
    [SerializeField]
    GameObject escMenu, healthBar;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OpenOrCloseMenu(escMenu);
        }
    }
    public void UpdateHealthBar(int maxHP, int currHP)
    {
        float barLength = (float)currHP / (float)maxHP;
        healthBar.transform.localScale = new Vector3(barLength, 1, 1);
    }
}
