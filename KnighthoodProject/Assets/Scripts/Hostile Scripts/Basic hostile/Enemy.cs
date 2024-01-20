using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Stavy
    public HostileStateManager stateMachine { get; protected set; } = new HostileStateManager();
    [SerializeField] protected HostileIdleState idleState;
    [SerializeField] protected HostileChasingState chasingState;
    [SerializeField] protected HostileEngagingState engagingState;

    protected HostileIdleState IdleState;
    protected HostileChasingState ChasingState;
    protected HostileEngagingState EngagingState;
    

    
    protected void Start()
    {
        SetUpStates();
        stateMachine.ChangeState(IdleState);
    }
    protected void Update()
    {
        stateMachine.Update();
    }
    protected void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
    protected void SetUpStates()
    {
        IdleState = Instantiate(idleState);
        ChasingState = Instantiate(chasingState);
        EngagingState = Instantiate(engagingState);

        IdleState.SetUpState(gameObject);
        ChasingState.SetUpState(gameObject);
        EngagingState.SetUpState(gameObject);
    }
    public void BeginChase()
    {
        stateMachine.ChangeState(ChasingState);
    }
    public void BeginEnagagement()
    {
        stateMachine.ChangeState(EngagingState);
    }
}
