using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileState : ScriptableObject
{
    protected Animator anim;
    protected HostileWeapon weap;
    protected GameObject go;
    protected HostileStateManager mother;
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }

    public virtual void SetUpState(GameObject gameObject)
    {
        go = gameObject;
        weap = go.GetComponentInChildren<HostileWeapon>();
        anim = go.GetComponentInChildren<Animator>();
        mother = go.GetComponent<Enemy>().stateMachine;
    }
}
