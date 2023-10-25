using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HostileChar : Character
{
    protected override void Die()
    {
        //Pøehraje animaci smrti a pak zmizí
    }

    protected override void SetTag()
    {
        tag = "Hostile";
    }
}
