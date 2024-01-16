using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBstate : HostileState
{
    Transform palm;
    public override void SetUpState(GameObject gameObject)
    {
        go = gameObject;
        anim = go.GetComponentInChildren<Animator>();
        mother = go.GetComponent<Enemy>().stateMachine;
        palm = go.GetComponent<SecondBoss>().palm;
    }
}
