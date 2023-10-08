using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon : Weapon
{
    [SerializeField]
    protected float heavyAttTimer; //Pokud mouseDownTime >= heavyAttTimer tak se pøidá do fronty tìžký útok, jinak se pøidá lehký
    protected float mouseDownTime = 0;

    protected override void ProcessInputs()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            mouseDownTime += Time.deltaTime;
        }
        else if (mouseDownTime >= heavyAttTimer)
        {
            attQueue.Add(heavyAttack);
            mouseDownTime = 0;
        }
        else if(mouseDownTime > 0)
        {
            attQueue.Add(lightAttack);
            mouseDownTime = 0;
        }
    }
}
