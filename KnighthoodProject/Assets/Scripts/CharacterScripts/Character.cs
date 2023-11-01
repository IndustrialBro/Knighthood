using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected short health, armour;
    
    public bool isBlocking;
    public float blockCost;

    protected void Start()
    {
        SetTag();
    }

    protected void TakeDamage(short howMuch)
    {
        health -= howMuch;
        if(health <= 0)
        {
            Die();
        }
    }
    protected abstract void Die();
    public virtual void GetHit(Attack strike)
    {
        if (strike.armourPen > armour && !isBlocking)
        {
            TakeDamage(strike.damage);
        }
    }
    protected abstract void SetTag();
}
