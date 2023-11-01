using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    GameObject armament;
    [SerializeField]
    Transform weaponSlot;
    void Start()
    {
        EquipWeapon();
    }

    protected void EquipWeapon()
    {
        Instantiate(armament).transform.SetParent(weaponSlot, false);
    }
}
