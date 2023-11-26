using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileStateManager
{
    HostileState currState = null;
    HostileState nextState = null;
    public bool canChangeState = true;
    public void ChangeState(HostileState state)
    {
        nextState = state;
    }
    public void Update()
    {
        if(currState != nextState && canChangeState)
        {
            if (currState != null)
                currState.ExitState();
            currState = nextState;
            currState.EnterState();
        }
        currState.Update();
    }
    public void FixedUpdate()
    {
        if(currState!= null)
            currState.FixedUpdate();
    }
}
