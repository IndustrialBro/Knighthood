using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HostileChar : Character
{
    protected override void Die()
    {
        //P�ehraje animaci smrti a pak zmiz�
        Debug.Log("Dummy is dead. No big surprise.");
        health = 10;
    }

    protected override void SetTag()
    {
        tag = "Hostile";
    }
}
