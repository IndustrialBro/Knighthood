using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "ScriptableObjects/Attack")]
public class Attack : ScriptableObject
{
    [field: SerializeField] public byte damage {  get; private set; }
    [field: SerializeField] public byte armourPen {  get; private set; }
    [field: SerializeField] public bool light {  get; private set; }
}
