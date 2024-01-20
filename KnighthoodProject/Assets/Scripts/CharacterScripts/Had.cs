using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Had : MonoBehaviour
{
    [SerializeField]
    protected int MaxHealth, armour;
    protected int currHealth;
    public bool isblocking = false;
    public float blockCost;

    protected virtual void Start()
    {
        currHealth = MaxHealth;
    }
    public virtual void GetHit(Attack a)
    {
        if (a.armourPen > armour)
        {
            currHealth -= a.damage;
            if (currHealth <= 0)
                Die();
        }
    }
    protected abstract void Die();
}
