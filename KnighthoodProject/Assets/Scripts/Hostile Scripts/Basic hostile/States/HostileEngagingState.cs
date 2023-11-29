using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EngageState", menuName = "ScriptableObjects/States/EngageState")]
public class HostileEngagingState : HostileState
{
    HostileWeapon hw;
    public override void SetUpState(GameObject gameObject)
    {
        base.SetUpState(gameObject);
        hw = go.GetComponentInChildren<HostileWeapon>();
    }
    public override void EnterState()
    {
        anim.runtimeAnimatorController = weap.EngageCon;
    }
    public override void Update()
    {
        LookAtPlayer();

        hw.AddAtt(false);
    }
    public override void ExitState()
    {
        hw.EmptyQueue();
    }
    void LookAtPlayer()
    {
        Vector3 targetDir = (go.transform.position - GameManager.Instance.playerTransform.position) * -1;
        Vector3 newDir = Vector3.RotateTowards(go.transform.forward, targetDir, 3.14f, 0);
        go.transform.rotation = Quaternion.LookRotation(newDir);
    }

}
