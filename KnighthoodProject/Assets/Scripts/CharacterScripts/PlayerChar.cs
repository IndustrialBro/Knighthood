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
    public override void GetHit(Attack a, int ad)
    {
        base.GetHit(a, ad);
        menu.UpdateHealthBar(MaxHealth, currHealth);
    }
    public override void Heal(int howMuch)
    {
        base.Heal(howMuch);
        menu.UpdateHealthBar(MaxHealth, currHealth);
    }
    public override void KnockBack(Attack a, Vector3 sourceLoc)
    {
        if (pm.currStamina > 0)
            pm.DepleteStamina(blockCost, false);
        else
            GetHit(a, 0);
        
        base.KnockBack(a, sourceLoc);
    }
}
