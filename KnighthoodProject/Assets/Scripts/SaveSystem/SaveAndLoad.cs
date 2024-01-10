using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public sealed class SaveAndLoad
{
    public static SaveAndLoad instance {  get; private set; } = new SaveAndLoad();
    private SaveAndLoad() { }

    public void SaveObjectAsJson<T>(T obj, string name)
    {
        string json = JsonConvert.SerializeObject(obj);

        PlayerPrefs.SetString(name, json);
    }

    public T LoadObjectFromJson<T>(string name)
    {
        string json = PlayerPrefs.GetString(name);

        T obj = JsonConvert.DeserializeObject<T>(json);
        
        return obj;
    }
}
