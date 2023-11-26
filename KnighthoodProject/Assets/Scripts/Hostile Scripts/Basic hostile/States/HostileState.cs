using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileState : ScriptableObject
{
    protected GameObject go;
    public virtual void EnterState() { Debug.Log("entered new state"); }
    public virtual void ExitState() { Debug.Log("exited a state"); }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }

    public abstract void SetUpState(GameObject gameObject);
}
