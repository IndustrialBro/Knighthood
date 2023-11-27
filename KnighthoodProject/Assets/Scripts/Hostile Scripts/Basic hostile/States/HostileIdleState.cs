using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "ScriptableObjects/States/IdleState")]
public class HostileIdleState : HostileState
{
    public override void SetUpState(GameObject gameObject)
    {
        base.SetUpState(gameObject);
    }
    public override void EnterState()
    {
        base.EnterState();
        anim.runtimeAnimatorController = weap.idleCon;
    }
}
