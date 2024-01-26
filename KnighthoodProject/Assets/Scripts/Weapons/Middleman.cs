using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Middleman : MonoBehaviour
{
    Weapon w;
    
    public void SetReadyToStrike(int i)
    {
        switch (i)
        {
            case 0:
                w.SetReadyToStrike(false);
                break;
            case 1:
                w.SetReadyToStrike(true);
                break;
            default:
                Debug.LogError($"SetReadyToStrike parameter out of bounds in middleman of {gameObject.name}");
                break;
        }
    }
    public void SetAttacking(int i)
    {
        switch (i)
        {
            case 0:
                w.SetAttacking(false);
                break;
            case 1:
                w.SetAttacking(true);
                break;
            default:
                Debug.LogError($"SetAttack parameter out of bounds in middleman of {gameObject.name}");
                break;
        }
    }
    public void SetNewWeaponComponent(Weapon newW)
    {
        w = newW;
    }
}
