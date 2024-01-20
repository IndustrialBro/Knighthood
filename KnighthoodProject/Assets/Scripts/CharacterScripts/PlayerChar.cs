using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : Had
{
    [SerializeField]
    GameObject DeathScreen;
    PlayerUI menu;
    PlayerMovementWPrebuilt pm;

    protected override void Die()
    {
        menu.OpenOrCloseMenu(DeathScreen);
    }

    protected override void Start()
    {
        base.Start();
        pm = GetComponent<PlayerMovementWPrebuilt>();
        menu = GetComponentInChildren<PlayerUI>();
        GameManager.instance.SetPlayerTransform(this.transform);
    }
    public override void GetHit(Attack a)
    {
        if (isblocking && pm.currStamina > 0)
        {
            pm.currStamina -= blockCost;
        }
        else
            base.GetHit(a);
    }
}
