using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageRangeCheck : MonoBehaviour
{
    Enemy enemyScript;
    HostileStateManager stateMachine;
    void Start()
    {
        enemyScript = GetComponentInParent<Enemy>();

        stateMachine = enemyScript.stateMachine;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            stateMachine.ChangeState(enemyScript.EngagingState);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            stateMachine.ChangeState(enemyScript.ChasingState);
    }
}
