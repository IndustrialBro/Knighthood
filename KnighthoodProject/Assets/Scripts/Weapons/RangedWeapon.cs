using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire()
    {
        Instantiate(projectile);
    }
}
