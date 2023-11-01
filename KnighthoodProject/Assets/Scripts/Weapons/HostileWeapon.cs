using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileWeapon : Weapon
{
    protected override void ProcessInputs()
    {
        attackQueue.Enqueue(lightAttack);
    }
    protected override void SetTargetTag()
    {
        targetTag = "Player";
    }
}
