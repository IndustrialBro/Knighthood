using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ihad
{
   int maxHealth {  get; set; }
   int armour { get; set; }
   float blockCost { get; set; }
   bool isBlocking { get; set; }
    void GetHit(Attack strike);
    void Die();
}
