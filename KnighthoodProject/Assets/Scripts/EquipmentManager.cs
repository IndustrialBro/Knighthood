using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    GameObject chosenArmament;
    GameObject currArmament = null;
    [SerializeField]
    Transform weaponSlot;
    void Start()
    {
        if (GameManager.Instance.lastChosenWeapon != null)
        {
            ChangeWeaponChoice(GameManager.Instance.lastChosenWeapon);
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
        GameManager.Instance.SetLCW(chosenArmament);
    }
    public void ChangeWeaponChoice(GameObject weapon)
    {
        chosenArmament = weapon;
        EquipWeapon();
        Debug.Log("Chose new weapon!");
    }

}
