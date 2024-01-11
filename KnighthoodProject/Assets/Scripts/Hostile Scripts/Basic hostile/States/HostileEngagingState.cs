using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EngageState", menuName = "ScriptableObjects/States/EngageState")]
public class HostileEngagingState : HostileState
{
    HostileWeapon hw;

    [SerializeField]
    int maxComboCount;
    [SerializeField]
    float maxComboCool, heavyAttChance;
    float curComboCool;

    int engageHash = Animator.StringToHash("Engage");
    public override void SetUpState(GameObject gameObject)
    {
        base.SetUpState(gameObject);
        hw = go.GetComponentInChildren<HostileWeapon>();
    }
    public override void EnterState()
    {
        anim.SetTrigger(engageHash);
        curComboCool = 0;
    }
    public override void Update()
    {
        AddAttacks();
        LookAtPlayer();
    }
    public override void ExitState()
    {
        hw.EmptyQueue();
    }
    void LookAtPlayer()
    {
        if (!hw.ReadyToStrike())
        {
            Vector3 targetDir = GameManager.instance.playerTransform.position - go.transform.position;
            Vector3 newDir = Vector3.RotateTowards(go.transform.forward, targetDir, 3.14f, 0);
            go.transform.rotation = Quaternion.LookRotation(newDir);

            mother.canChangeState = true;
        }
        else
            mother.canChangeState = false;
    }
    void AddAttacks()
    {
        if (curComboCool <= 0)
        {
            for (int i = 0; i < maxComboCount; i++)
            {
                if(Random.Range(0f, 1f) < heavyAttChance)
                {
                    hw.AddAtt(true);
                }
                else
                {
                    hw.AddAtt(false);
                }
            }
            curComboCool = maxComboCool;
        }
        else
            curComboCool -= Time.deltaTime;
    }
}