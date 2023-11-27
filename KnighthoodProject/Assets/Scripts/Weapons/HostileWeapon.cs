using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileWeapon : Weapon
{
    [SerializeField]
    protected RuntimeAnimatorController idleCon;
    public RuntimeAnimatorController IdleCon { get { return idleCon; } private set { } }
    [SerializeField]
    protected RuntimeAnimatorController chaseCon;
    public RuntimeAnimatorController ChaseCon { get {return chaseCon;} private set { } }
    [SerializeField]
    protected RuntimeAnimatorController engageCon;
    public RuntimeAnimatorController EngageCon { get { return engageCon; } private set { } }

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
