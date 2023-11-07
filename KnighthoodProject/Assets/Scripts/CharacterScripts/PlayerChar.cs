using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour, Ihad
{
    [SerializeField]
    GameObject DeathScreen;
    PlayerUI menu;
    PlayerMovementWPrebuilt pm;
    [field: SerializeField] public short maxHealth { get; set; }
    public short currHealth { get; set; }
    [field: SerializeField] public short armour { get; set; }
    public float blockCost { get; set; }
    public bool isBlocking { get; set; } = false;

    private void Start()
    {
        pm = GetComponent<PlayerMovementWPrebuilt>();
        menu = GetComponent<PlayerUI>();
        currHealth = maxHealth;
    }
    public void Die()
    {
        menu.OpenOrCloseMenu(DeathScreen);
    }

    public void GetHit(Attack strike)
    {
        if (isBlocking && pm.currStamina > 0)
        {
            pm.currStamina -= blockCost;
        }
        else
        {
            if (strike.armourPen >= armour)
            {
                currHealth -= strike.damage;

                if (currHealth <= 0)
                {
                    Die();
                }
            }
        }
    }
}
