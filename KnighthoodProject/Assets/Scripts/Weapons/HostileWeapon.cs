using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileWeapon : Weapon
{
    [SerializeField]
    public RuntimeAnimatorController idleCon { get; private set;}
    [SerializeField]
    public RuntimeAnimatorController chaseCon { get; private set;}
    [SerializeField]
    public RuntimeAnimatorController engageCon { get; private set;}
    [SerializeField]
    float engagementRange;

    protected override void Start()
    {
        base.Start();
        //Pøidej nastavení engagementRange
    }
    protected void Update()
    {
        MoveThroughQueue();
    }
    protected override void SetTargetTag()
    {
        targetTag = "Player";
    }
    protected override void SetUpAnimator()
    {
        anim = GetComponentInParent<Animator>();
        anim.runtimeAnimatorController = idleCon;
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
