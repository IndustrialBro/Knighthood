using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager
{
    public static GameManager instance { get; private set; } = new GameManager();
    private GameManager(){}

    public Transform playerTransform { get; private set; }

    public void SetPlayerTransform(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }
}