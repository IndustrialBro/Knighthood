using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class StateSwitchTrigger : MonoBehaviour
{
    [SerializeField] int enterId, exitId;
    [SerializeField] bool switchOnExit = false;
    Enemy e;
    void Start()
    {
        e = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        e.SwitchState(enterId);
    }
    private void OnTriggerExit(Collider other)
    {
        if(switchOnExit)
            e.SwitchState(exitId);
    }
}
