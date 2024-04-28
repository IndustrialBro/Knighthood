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
    Transform primarySlot, secondarySlot;
    [SerializeField]
    GameObject blockTriggerMount;
    BoxCollider bt;

    Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        bt = blockTriggerMount.GetComponent<BoxCollider>();

        //lastChosenWeapon = SaveAndLoad.instance.LoadObjectFromJson<Equipable>("LastChosenWeapon");
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
        GameObject temp = Instantiate(chosenArmament.weapon);
        temp.transform.SetParent(primarySlot, false);
        currArmament.Add(temp);
        temp.GetComponent<Weapon>().SetBlockTrigger(bt);

        //Equip secondary Weapon
        if(chosenArmament.secondary != null)
        {
            GameObject temp2 = Instantiate(chosenArmament.secondary);
            temp2.transform.SetParent(secondarySlot, false);
            currArmament.Add(temp2);
            temp.GetComponent<Weapon>().SetSecondaryWeapon(temp2.GetComponent<SecondaryWeapon>());
        }

        lastChosenWeapon = chosenArmament;

        anim.runtimeAnimatorController = chosenArmament.animCon;
        
        SetupBlockTrigger();
    }
    public void ChangeWeaponChoice(Equipable weapon)
    {
        Debug.Log("Chose new weapon!");
        chosenArmament = weapon;
        //SaveAndLoad.instance.SaveObjectAsJson<Equipable>(chosenArmament, "LastChosenWeapon");
        EquipWeapon();
    }
    void SetupBlockTrigger()
    {
        bt.size = new Vector3(chosenArmament.blockerWidth, 2);
        bt.isTrigger = true;
    }
}
