using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState", menuName = "ScriptableObjects/States/ChaseState")]
public class HostileChasingState : HostileState
{ // Pot�ebuje navMeshAgent a odkaz na hr��e (kter� d�m do gameMangeru, aby si to nemusel ka�d� nep��tel ukl�dat u sebe)

    public NavMeshAgent agent;
    int chaseHash = Animator.StringToHash("Chase");
    public override void EnterState()
    {
        agent.isStopped = false;
        anim.SetTrigger(chaseHash);
    }
    public override void ExitState()
    {
        agent.isStopped = true;
    }
    public override void Update()
    {
        
    }
    public override void FixedUpdate()
    {
        agent.SetDestination(GameManager.instance.playerTransform.position);
    }
    public override void SetUpState(GameObject gameObject)
    {
        base.SetUpState(gameObject);
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
}
