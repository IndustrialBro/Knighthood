using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour, IInteractable
{
    [SerializeField]
    string sceneName;
    public void Interact(GameObject sender)
    {
        Debug.Log(sceneName);
        MainMenu.ChangeScene(sceneName);
    }
}
