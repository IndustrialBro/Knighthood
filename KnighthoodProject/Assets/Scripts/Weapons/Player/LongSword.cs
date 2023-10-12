using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSword : PlayerWeapon
{
    protected override void CreateAttacks()
    {
        lightAttack = new Attack(20, 5, true);
        heavyAttack = new Attack(30, 15, false);
    }
}
