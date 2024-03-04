using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SecondBossChanging", menuName = "ScriptableObjects/States/SecondBoss/SecondBossChanging")]
public class SBarenaChanging : SBstate
{
    [SerializeField] float maxCool;
    float currCool;
    public override void EnterState()
    {
        //teleportuje se s hráèem do jiné arény
        currCool = maxCool;
        sb.SwitchArena();
        anim.Play("Teleport");
    }
    public override void Update()
    {
        //odpoèet než zmìní stav na SBinArena
        currCool -= Time.deltaTime;
        if (currCool < 0)
            sb.SwitchState(2);
    }
}
