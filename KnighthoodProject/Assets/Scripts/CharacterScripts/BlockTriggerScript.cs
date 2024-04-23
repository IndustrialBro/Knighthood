using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTriggerScript : MonoBehaviour
{
    Weapon w;
    private void OnTriggerEnter(Collider other)
    {
        w = other.GetComponent<Weapon>();
        if (w != null)
            w.Parry();
    }
}
