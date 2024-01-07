using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour, Ihad
{
    public int maxHealth { get; set; }
    public int armour { get; set; }
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
