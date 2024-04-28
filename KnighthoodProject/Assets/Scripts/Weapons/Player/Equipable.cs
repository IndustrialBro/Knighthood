using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipable", menuName = "ScriptableObjects/Equipable")]
public class Equipable : ScriptableObject
{
    [field: SerializeField]
    public GameObject weapon { get; private set; }
    [field: SerializeField]
    public GameObject secondary { get; private set; }
    [field: SerializeField]
    public RuntimeAnimatorController animCon { get; private set; }
    [field: SerializeField]
    public float blockerWidth { get; private set; }
}
