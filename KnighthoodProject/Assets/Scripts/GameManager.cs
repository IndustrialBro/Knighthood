using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager
{
    private static GameManager instance = new GameManager();
    public static GameManager Instance {  get { return instance; } }
    private GameManager() { }

    public Transform playerTransform;

    public void SetPlayerTransform(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }
}