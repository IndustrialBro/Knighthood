using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Attack lightAttack;
    protected Attack heavyAttack;
    protected bool attReady = true;
    protected bool attacking = false;
    [SerializeField]
    protected float maxAttCool, currAttCool;
    //Fronta útokù
    protected List<Attack> attQueue = new List<Attack>();
    [SerializeField]
    protected float maxQueueCool;
    protected float currQueueCool;
    protected void Start()
    {
        CreateAttacks();
    }

    
    protected void Update()
    {
        ProcessInputs();
        ProcessCooldowns();
        ExecuteAttacks();
    }

    protected abstract void CreateAttacks(); //Každá zbraò si to udìlá sama lol
    protected void ProcessCooldowns()
    {
        if(attacking && currAttCool > 0)
        {
            currAttCool -= Time.deltaTime;
        }

        if(attQueue.Count > 0 && currQueueCool > 0)
        {
            currQueueCool -= Time.deltaTime;
        }
    }
    protected abstract void ProcessInputs(); //Zaøídí tøídy PlayerWeapon a HostileWeapon nebo jak je pojmenuju
    protected void ExecuteAttacks()
    {
        if(attQueue.Count > 0)
        {

        }
    }
}
