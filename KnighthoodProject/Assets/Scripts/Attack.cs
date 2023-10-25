using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public byte damage {  get; private set; }
    public byte armourPen {  get; private set; }
    public bool light {  get; private set; }
    public Attack(byte damage, byte armourPen, bool light)
    {
        this.damage = damage;
        this.armourPen = armourPen;
        this.light = light;
    }
}
