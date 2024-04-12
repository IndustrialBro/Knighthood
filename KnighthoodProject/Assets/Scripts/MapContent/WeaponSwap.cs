using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour, IInteractable
{
    [SerializeField]
    Equipable weapon;
    public void Interact(GameObject sender)
    {
        Debug.Log("Interacted with weapon swap.");
        EquipmentManager temp = sender.GetComponent<EquipmentManager>();
        temp.ChangeWeaponChoice(weapon);
    }
}
