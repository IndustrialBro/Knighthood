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
        //Ohlásí, že hráè zemøel a dá mu možnost vrátit se do lobby nebo ukonèit hru
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
