using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileWeapon : Weapon
{
    protected override void ProcessInputs()
    {
        attQueue.Add(lightAttack);
    }
}
