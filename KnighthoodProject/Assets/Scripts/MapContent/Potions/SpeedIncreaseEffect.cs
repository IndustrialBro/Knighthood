using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedIncreaseEffect", menuName = "ScriptableObjects/Potions/SpeedIncreaseAttack")]
public class SpeedIncreaseEffect : Effect
{
    [SerializeField]
    float speedBoost;
    PlayerMovementWPrebuilt pm;
    public override void StartEffect(GameObject go)
    {
        pm = go.GetComponent<PlayerMovementWPrebuilt>();
        pm.SetAdditionalSpeed(speedBoost);
    }

    protected override void EndEffect()
    {
        pm.SetAdditionalSpeed(0);
    }
}
