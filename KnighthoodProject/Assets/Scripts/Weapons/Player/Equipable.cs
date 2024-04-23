using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipable", menuName = "ScriptableObjects/Equipable")]
public class Equipable : ScriptableObject
{
    [field: SerializeField]
    public List<GameObject> weapons { get; private set; } = new List<GameObject>();
    [field: SerializeField]
    public RuntimeAnimatorController animCon { get; private set; }
    [field: SerializeField]
    public float blockerWidth { get; private set; }
}
