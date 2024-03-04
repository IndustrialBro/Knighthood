using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealingOverTimeEffect", menuName = "ScriptableObjects/Potions/HealingOverTimeEffect")]
public class HealingOverTime : Effect
{
    [SerializeField]
    int health;
    Had h;
    public override void StartEffect(GameObject go)
    {
        h = go.GetComponent<Had>();
    }
    public override void DoYourThing()
    {
        h.Heal(health);
        Debug.Log("Get Healed lol");
    }
}
