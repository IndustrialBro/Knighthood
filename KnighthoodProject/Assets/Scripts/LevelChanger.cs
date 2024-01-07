using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LevelChanger
{
    static LevelChanger instance = new LevelChanger();
    public static LevelChanger Instance {  get { return instance; } }
    private LevelChanger() { }

    public GameObject lastChosenWeapon = null;

    public void ChangeScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            if (sceneName == "MainMenu")
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            Debug.LogError("Invalid Scene Name");
        }
    }
}
