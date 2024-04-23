using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Had : MonoBehaviour
{
    [SerializeField]
    protected int MaxHealth, armour;
    protected int currHealth;
    public float blockCost;

    protected virtual void Start()
    {
        currHealth = MaxHealth;
    }
    public virtual void GetHit(Attack a, int ad)
    {
        int temp = armour - a.armourPen;
        if (temp < 0)
        {
            currHealth -= a.damage + ad;
            Debug.Log($"{gameObject.name} has suffered {a.damage + ad} damage");
        }
        else
        {
            currHealth -= a.damage - temp + ad;
            Debug.Log($"{gameObject.name} has suffered {a.damage - temp + ad} damage");
        }
        
        if (currHealth <= 0)
            Die();
    }
    public virtual void Heal(int howMuch)
    {
        Debug.Log("Get healed, ya fuckin' nerd");
        currHealth += howMuch;
        if(currHealth > MaxHealth)
            currHealth = MaxHealth;
    }
    protected abstract void Die();
    public void IncreaseArmour(int howMuch)
    {
        armour += howMuch;
        Debug.Log($"Armour is {armour}");
    }
    public virtual void KnockBack(Attack a, Vector3 sourceLoc)
    {
        //Nefunctionální
        Vector3 dir = transform.position - sourceLoc;
        dir = dir.normalized;

        Debug.Log($"Knocked back: x={dir.x}, y={dir.y}, z={dir.z}");
    }
}