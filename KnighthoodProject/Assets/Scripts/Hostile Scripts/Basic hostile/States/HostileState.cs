using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileState : ScriptableObject
{
    protected Animator anim;
    protected HostileWeapon weap;
    protected GameObject go;
    public virtual void EnterState() { Debug.Log("entered new state"); }
    public virtual void ExitState() { Debug.Log("exited a state"); }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }

    public virtual void SetUpState(GameObject gameObject)
    {
        weap = gameObject.GetComponentInChildren<HostileWeapon>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }
}
