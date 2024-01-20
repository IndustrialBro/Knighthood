using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Had
{
    protected override void Die()
    {
        Debug.Log("Dummy hit!");
        currHealth = MaxHealth;
    }
}
