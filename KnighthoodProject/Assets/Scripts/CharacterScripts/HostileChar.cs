using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HostileChar : MonoBehaviour, Ihad
{
    [field: SerializeField]public short maxHealth { get ; set ; }
    public short currHealth { get ; set ; }
    [field: SerializeField]public short armour { get ; set ; }
    public float blockCost { get ; set ; }
    public bool isBlocking { get ; set ; }

    public void Die()
    {
        //P�ehraje animaci smrti a zmiz�
    }

    public void GetHit(Attack strike)
    {
        if(strike.armourPen >= armour)
        {
            currHealth -= strike.damage;

            if(currHealth <= 0)
            {
                Die();
            }
        }
    }
}
