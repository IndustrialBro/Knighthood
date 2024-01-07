using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRangeCheck : MonoBehaviour
{

    Enemy enemyScript;
    private void Start()
    {
        enemyScript = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemyScript.BeginChase();
        }
    }
}
