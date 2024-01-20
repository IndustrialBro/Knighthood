using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileHad : Had
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
