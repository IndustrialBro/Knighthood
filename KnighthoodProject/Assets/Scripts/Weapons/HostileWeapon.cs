using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileWeapon : Weapon
{
    protected void Update()
    {
        MoveThroughQueue();
    }
    protected override void SetTargetTag()
    {
        targetTag = "Player";
    }
    
    public void AddAtt(bool isHeavy)
    {
        if(isHeavy)
        {
            attackQueue.Enqueue(heavyAttack);
        }
        else
        {
            attackQueue.Enqueue(lightAttack);
        }
    }
}
