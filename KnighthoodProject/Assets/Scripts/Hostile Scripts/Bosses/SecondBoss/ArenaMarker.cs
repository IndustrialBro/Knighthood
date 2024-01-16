using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMarker : MonoBehaviour
{
    [SerializeField] 
    public int arenaId {  get; private set; }
    [SerializeField]
    public float arenaRadius { get; private set; }
}
