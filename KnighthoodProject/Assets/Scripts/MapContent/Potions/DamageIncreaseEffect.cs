using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageIncreaseEffect", menuName = "ScriptableObjects/Potions/DamageIncreaseEffect")]
public class DamageIncreaseEffect : Effect
{
    [SerializeField]
    int dmgBonus;
    Weapon w;
    public override void StartEffect(GameObject go)
    {
        w = go.GetComponentInChildren<Weapon>();
        w.SetAdditionalDamage(dmgBonus);
    }

    protected override void EndEffect()
    {
        w.SetAdditionalDamage(0);
    }
}
