using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HostileChar : Character
{
    protected override void Die()
    {
        //P�ehraje animaci smrti a pak zmiz�
    }

    protected override void SetTag()
    {
        tag = "Hostile";
    }
}
