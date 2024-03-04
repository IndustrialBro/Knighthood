using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    [SerializeField]
    public int ttl;
    public abstract void StartEffect(GameObject go);
    
    public abstract void DoYourThing();
}
