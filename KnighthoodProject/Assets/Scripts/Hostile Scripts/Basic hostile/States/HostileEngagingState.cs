using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EngageState", menuName = "ScriptableObjects/States/EngageState")]
public class HostileEngagingState : HostileState
{
    public override void SetUpState(GameObject gameObject)
    {
        base.SetUpState(gameObject);
    }
    public override void EnterState()
    {
        anim.runtimeAnimatorController = weap.engageCon;
    }
}
