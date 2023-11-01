using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : Character
{
    [SerializeField]
    GameObject DeathScreen;
    PlayerMovementWPrebuilt pm;

    protected override void Die()
    {
        //Ohl�s�, �e hr�� zem�el a d� mu mo�nost vr�tit se do lobby nebo ukon�it hru
        Time.timeScale = 0;
        DeathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public override void GetHit(Attack strike) 
    {
        if (strike.armourPen > armour && (!isBlocking || pm.currStamina <= 0))
        {
            TakeDamage(strike.damage);
        }
        else if(isBlocking)
        {
            pm.currStamina -= blockCost;
        }
    }
    protected override void SetTag()
    {
        tag = "Player";
    }
}
