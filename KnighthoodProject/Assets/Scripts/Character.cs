using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int health {  get; private set; }
    public int armour { get; private set; }
    [SerializeField]
    GameObject armament;
    protected void Start()
    {
        EquipWeapon();
    }

    protected void TakeDamage(int howMuch)
    {
        health -= howMuch;
        if(health <= 0)
        {
            Die();
        }
    }
    protected abstract void Die();
    protected void GetHit(Attack strike)
    {
        if(strike.armourPen > armour)
        {
            TakeDamage(strike.damage);
        }
    }
    protected void EquipWeapon()
    {
        
    }
}
