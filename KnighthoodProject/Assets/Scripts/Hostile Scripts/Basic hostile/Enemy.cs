using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Ihad
{
    [field: SerializeField] public short maxHealth { get; set; }
    public short currHealth { get; set; }
    [field: SerializeField] public short armour { get; set; }
    public float blockCost { get; set; }
    public bool isBlocking { get; set; }


    //Stavy
    public HostileStateManager stateMachine = new HostileStateManager();
    [SerializeField] HostileIdleState idleState;
    [SerializeField] HostileChasingState chasingState;
    [SerializeField] HostileEngagingState engagingState;

    public HostileIdleState IdleState { get; private set; }
    public HostileChasingState ChasingState { get; private set; }
    public HostileEngagingState EngagingState { get; private set; }
    public void Die()
    {
        Destroy(gameObject);
    }

    public void GetHit(Attack strike)
    {
        if (strike.armourPen >= armour)
        {
            currHealth -= (short)Mathf.Abs(strike.damage - armour);
       
            if (currHealth <= 0)
                Die();
        }
    }
    void Start()
    {
        currHealth = maxHealth;
        SetUpStates();
        stateMachine.ChangeState(IdleState);
    }
    void Update()
    {
        stateMachine.Update();
    }
    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
    void SetUpStates()
    {
        IdleState = Instantiate(idleState);
        ChasingState = Instantiate(chasingState);
        EngagingState = Instantiate(engagingState);

        IdleState.SetUpState(gameObject);
        ChasingState.SetUpState(gameObject);
        EngagingState.SetUpState(gameObject);
    }
}
