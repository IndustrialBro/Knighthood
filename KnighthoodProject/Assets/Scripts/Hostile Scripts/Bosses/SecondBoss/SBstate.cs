using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBstate : HostileState
{
    protected SecondBoss sb;
    public override void SetUpState(GameObject gameObject)
    {
        go = gameObject;
        anim = go.GetComponentInChildren<Animator>();
        mother = go.GetComponent<Enemy>().stateMachine;
        sb = go.GetComponent<SecondBoss>();
    }
}
