using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected short health, armour;
    [SerializeField]
    GameObject armament;
    [SerializeField]
    Transform weaponSlot;
    public bool isBlocking;

    protected void Start()
    {
        EquipWeapon();
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
    protected void EquipWeapon()
    {
        Instantiate(armament).transform.SetParent(weaponSlot, false);
    }
    protected abstract void SetTag();
}
