using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SecondaryWeapon : MonoBehaviour
{
    [SerializeField]
    string targetTag;

    Attack currAtt;
    int addDmg;
    Collider[] triggers;
    private void Start()
    {
    }
    private void Awake()
    {
        triggers = GetComponents<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            other.GetComponent<Had>().GetHit(currAtt, addDmg);
        }
    }

    public void GetReadyToStrike(Attack att, int addDmg)
    {
        currAtt = att;
        this.addDmg = addDmg;

        for(int i = 0; i < triggers.Length; i++)
        {
            triggers[i].enabled = true;
        }
    }
    public void StopStriking()
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].enabled = false;
        }
    }
}