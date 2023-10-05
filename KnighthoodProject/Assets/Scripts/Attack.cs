using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public int damage {  get; private set; }
    public int armourPen {  get; private set; }

    public Attack(int damage, int armourPen)
    {
        this.damage = damage;
        this.armourPen = armourPen;
    }
}
