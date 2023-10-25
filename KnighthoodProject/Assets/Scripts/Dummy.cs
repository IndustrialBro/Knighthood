using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : HostileChar
{
    private new void Start()
    {
        SetTag();
    }
    protected override void Die()
    {
        Debug.Log("Dummy hit");
        health = 10;
    }
}
