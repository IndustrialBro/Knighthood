using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Ihad
{
    [field: SerializeField] public int maxHealth { get; set; }
    int currHealth { get; set; }
    [field: SerializeField] public int armour { get; set; }
    public float blockCost { get; set; }
    public bool isBlocking { get; set; }


    //Stavy
    public HostileStateManager stateMachine = new HostileStateManager();
    [SerializeField] HostileIdleState idleState;
    [SerializeField] HostileChasingState chasingState;
    [SerializeField] HostileEngagingState engagingState;

    HostileIdleState IdleState;
    HostileChasingState ChasingState;
    HostileEngagingState EngagingState;
    public void Die()
    {
        Destroy(gameObject);
    }

    public void GetHit(Attack strike)
    {
        if (strike.armourPen >= armour)
        {
            currHealth -= strike.damage;
       
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
    public void BeginChase()
    {
        stateMachine.ChangeState(ChasingState);
    }
    public void BeginEnagagement()
    {
        stateMachine.ChangeState(EngagingState);
    }
}
