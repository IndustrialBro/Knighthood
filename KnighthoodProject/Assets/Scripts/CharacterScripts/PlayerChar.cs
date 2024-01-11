using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour, Ihad
{
    [SerializeField]
    GameObject DeathScreen;
    PlayerUI menu;
    PlayerMovementWPrebuilt pm;
    [field: SerializeField] public int maxHealth { get; set; }
    public int currHealth { get; set; }
    [field: SerializeField] public int armour { get; set; }
    public float blockCost { get; set; }
    public bool isBlocking { get; set; } = false;

    private void Start()
    {
        pm = GetComponent<PlayerMovementWPrebuilt>();
        menu = GetComponentInChildren<PlayerUI>();
        currHealth = maxHealth;
        GameManager.instance.SetPlayerTransform(this.transform);
    }
    public void Die()
    {
        menu.OpenOrCloseMenu(DeathScreen);
    }

    public void GetHit(Attack strike)
    {
        Debug.Log("hit");
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
