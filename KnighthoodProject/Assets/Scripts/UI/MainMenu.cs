using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        SaveAndLoad.instance.LoadAll();
        ChangeScene("LobbyScene");
    }
    public static void ChangeScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            if (sceneName == "MainMenu")
            {
                Cursor.lockState = CursorLockMode.None;
                SaveAndLoad.instance.SaveAll();
            }
        }
        else
        {
            Debug.LogError("Invalid Scene Name");
        }
    }

    public void QuitGame()
    {
        SaveAndLoad.instance.SaveAll();
        Application.Quit();
    }

    public void OpenOrCloseMenu(GameObject menu)
    {
        OpenOrCloseWindow(menu);
        if (menu.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }

    public void OpenOrCloseWindow(GameObject window)
    {
        window.SetActive(!window.activeSelf);
    }
}
