using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitchTrigger : MonoBehaviour
{
    [SerializeField] int enterId, exitId;
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
        if(exitId != 0)
            e.SwitchState(exitId);
    }
}
