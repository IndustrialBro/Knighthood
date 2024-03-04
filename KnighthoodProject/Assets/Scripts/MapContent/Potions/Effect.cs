using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    [field : SerializeField]
    public int ttl { get; protected set; }
    public abstract void StartEffect(GameObject go);
    
    public virtual void DoYourThing()
    {
        ttl--;
        if(ttl == 0)
        {
            EndEffect();
        }
    }

    protected abstract void EndEffect();
}
