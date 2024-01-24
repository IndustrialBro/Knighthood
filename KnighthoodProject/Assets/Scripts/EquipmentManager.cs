using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    GameObject chosenArmament;
    GameObject currArmament = null;
    static GameObject lastChosenWeapon = null;
    [SerializeField]
    Transform weaponSlot;
    Middleman m = null;
    void Start()
    {
        m = GetComponentInChildren<Middleman>();
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
        if(currArmament != null)
            Destroy(currArmament);

        currArmament = Instantiate(chosenArmament);
        currArmament.transform.SetParent(weaponSlot, false);
        lastChosenWeapon = chosenArmament;
        m.SetNewWeaponComponent(currArmament.GetComponent<Weapon>());
    }
    public void ChangeWeaponChoice(GameObject weapon)
    {
        Debug.Log("Chose new weapon!");
        chosenArmament = weapon;
        //SaveAndLoad.instance.SaveObjectAsJson<GameObject>(chosenArmament, "LastChosenWeapon");
        EquipWeapon();
    }

}
