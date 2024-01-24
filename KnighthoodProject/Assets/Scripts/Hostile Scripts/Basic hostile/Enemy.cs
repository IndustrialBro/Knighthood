using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Stavy
    public HostileStateManager stateMachine { get; protected set; } = new HostileStateManager();

    [SerializeField] protected List<HostileState> HostileStates = new();
    protected List<HostileState> hs = new();
    
    protected void Start()
    {
        SetUpStates();
        SwitchState(0);
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
        for (int i = 0; i < HostileStates.Count; i++)
        {
            HostileState temp = Instantiate(HostileStates[i]);
            temp.SetUpState(gameObject);
            hs.Add(temp);
        }
    }
    public void SwitchState(int id)
    {
        stateMachine.ChangeState(hs[id]);
    }
}
