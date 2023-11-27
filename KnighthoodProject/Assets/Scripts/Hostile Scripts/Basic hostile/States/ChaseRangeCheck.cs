using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRangeCheck : MonoBehaviour
{

    Enemy enemyScript;
    HostileStateManager stateMachine;
    private void Start()
    {
        enemyScript = GetComponentInParent<Enemy>();

        stateMachine = enemyScript.stateMachine;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            stateMachine.ChangeState(enemyScript.ChasingState);
        }
    }
}
