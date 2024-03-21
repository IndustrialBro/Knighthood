using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProtectionEffect", menuName = "ScriptableObjects/Potions/ProtectionEffect")]
public class ProtectionEffect : Effect
{
    [SerializeField]
    int armourBonus;
    Had h;
    public override void StartEffect(GameObject go)
    {
        h = go.GetComponent<Had>();
        h.IncreaseArmour(armourBonus);
    }

    protected override void EndEffect()
    {
        h.IncreaseArmour(-armourBonus);
    }
}
