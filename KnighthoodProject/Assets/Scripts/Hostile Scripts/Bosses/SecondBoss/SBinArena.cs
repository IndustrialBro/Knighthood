using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SecondBossInArena", menuName = "ScriptableObjects/States/SecondBoss/SecondBossInArena")]
public class SBinArena : SBstate
{
    [SerializeField] float maxTeleCool, maxAttCool;
    float currTeleCool, currAttCool;
    RangedWeapon weapon;
    public override void SetUpState(GameObject gameObject)
    {
        base.SetUpState(gameObject);
        weapon = go.GetComponentInChildren<RangedWeapon>();
    }
    public override void EnterState()
    {
        //teleportace
        Teleport();
    }
    public override void Update()
    {
        //útoèí na hráèe
        //odpoèet pøed další teleportací
        currTeleCool -= Time.deltaTime;
        if(currTeleCool < 0 )
            Teleport();
        if( currAttCool < 0)
        {
            weapon.Fire();
            currAttCool = maxAttCool;
        }
    }
    void Teleport()
    {
        sb.TeleportAlone();
        anim.Play("Teleport");
        currTeleCool = maxTeleCool;
        currAttCool = maxAttCool;
    }
}
