using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    Equipable chosenArmament;
    List<GameObject> currArmament = new List<GameObject>();
    static Equipable lastChosenWeapon = null;
    [SerializeField]
    List<Transform> weaponSlot;

    Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        //lastChosenWeapon = SaveAndLoad.instance.LoadObjectFromJson<GameObject>("LastChosenWeapon");
        if (lastChosenWeapon != null)
        {
            ChangeWeaponChoice(lastChosenWeapon);
        }
        else
            EquipWeapon();
    }
    void EquipWeapon()
    {
        //Unequip
        for (int i = 0; i < currArmament.Count; i++)
        {
            if (currArmament[i] != null)
            {
                Destroy(currArmament[i]);
            }
        }
        currArmament.Clear();

        //Equip
        for(int i = 0; i < weaponSlot.Count; i++)
        {
            if(i < chosenArmament.weapons.Count)
            {
                GameObject temp = Instantiate(chosenArmament.weapons[i]);
                temp.transform.SetParent(weaponSlot[i], false);
                currArmament.Add(temp);
            }
            else { break; }
        }

        lastChosenWeapon = chosenArmament;

        SetUpAnimator();
    }
    public void ChangeWeaponChoice(Equipable weapon)
    {
        Debug.Log("Chose new weapon!");
        chosenArmament = weapon;
        //SaveAndLoad.instance.SaveObjectAsJson<GameObject>(chosenArmament, "LastChosenWeapon");
        EquipWeapon();
    }
    void SetUpAnimator()
    {
        anim.runtimeAnimatorController = chosenArmament.animCon;
    }
}
