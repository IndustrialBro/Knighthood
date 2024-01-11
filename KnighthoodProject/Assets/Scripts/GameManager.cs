using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : ISavable
{
    private static GameManager instance = new GameManager();
    public static GameManager Instance {  get { return instance; } }
    private GameManager() 
    {
        SaveAndLoad.instance.AddSavable(this);
    }

    public Transform playerTransform { get; private set; }
    public GameObject lastChosenWeapon { get; private set; } = null;

    public void SetPlayerTransform(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }
    public void SetLCW(GameObject weap)
    {
        lastChosenWeapon = weap;
    }
    public void Save()
    {
        SaveAndLoad.instance.SaveObjectAsJson<GameObject>(lastChosenWeapon, "LastChosenWeapon");
    }

    public void Load()
    {
        lastChosenWeapon = SaveAndLoad.instance.LoadObjectFromJson<GameObject>("LastChosenWeapon");
    }
}