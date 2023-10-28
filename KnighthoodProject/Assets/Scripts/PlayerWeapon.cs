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
        if(Input.GetButton("Fire1"))
        {
            mouseDownTime += Time.deltaTime;
        }
        else if (mouseDownTime >= heavyAttTimer)
        {
            mouseDownTime = 0;
            attackQueue.Enqueue(heavyAttack);
            return;
        }
        else if(mouseDownTime > 0)
        {
            mouseDownTime = 0;
            attackQueue.Enqueue(lightAttack);
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Block();
        }
    }

    protected override void SetTargetTag()
    {
        targetTag = "Hostile";
    }
}
