using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public sealed class SaveAndLoad
{
    public static SaveAndLoad instance {  get; private set; } = new SaveAndLoad();
    private SaveAndLoad() { }
    List<ISavable> savables = new List<ISavable>();

    public void SaveObjectAsJson<T>(T obj, string name)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.None);

        PlayerPrefs.SetString(name, json);
    }

    public T LoadObjectFromJson<T>(string name)
    {
        string json = PlayerPrefs.GetString(name);

        T obj = JsonConvert.DeserializeObject<T>(json);
        
        return obj;
    }
    public void SaveAll()
    {
        for (int i = 0; i < savables.Count; i++)
        {
            savables[i].Save();
        }
    }

    public void LoadAll()
    {
        for (int i = 0; i < savables.Count; i++)
        {
            savables[i].Load();
        }
    }
    public void AddSavable(ISavable savable)
    {
        if (!savables.Contains(savable))
        {
            savables.Add(savable);
            Debug.Log("added savable");
        }
    }
}
