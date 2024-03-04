using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMarker : MonoBehaviour
{
    [SerializeField] 
    List<Transform> markers = new List<Transform>();

    public Transform GetRandomMarker()
    {
        if(markers.Count > 0)
        {
            int i = Random.Range(0, markers.Count);
            return markers[i];
        }
        return transform;
    }
}
