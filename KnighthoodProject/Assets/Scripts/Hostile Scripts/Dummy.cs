using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour, Ihad
{
    public short maxHealth { get; set; }
    public short currHealth { get; set; }
    public short armour { get; set; }
    public float blockCost { get; set; }
    public bool isBlocking { get; set; }

    public void Die()
    {
        Debug.Log("Dummy hit");
    }

    public void GetHit(Attack strike)
    {
        Die();
    }
}
