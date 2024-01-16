using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoss : Enemy
{
    [SerializeField]
    public Transform palm { get; private set; }
    [SerializeField]
    public List<ArenaMarker> arenas { get; private set; } = new List<ArenaMarker>();
}