using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageRangeCheck : MonoBehaviour
{
    Enemy enemyScript;
    void Start()
    {
        enemyScript = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            enemyScript.BeginEnagagement();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            enemyScript.BeginChase();
    }
}
