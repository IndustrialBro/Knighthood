using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantHealPotion : MonoBehaviour, IInteractable
{
    [SerializeField]
    int health;
    public void Interact(GameObject sender)
    {
        sender.GetComponent<Had>().Heal(health);
        Destroy(gameObject);
    }
}
