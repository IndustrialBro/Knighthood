using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IInteractable
{
    [SerializeField]
    Effect effect;
    public void Interact(GameObject sender)
    {
        sender.GetComponent<PotionAffected>().ChangeEffect(effect);
        Destroy(gameObject);
    }
}
