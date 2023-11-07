using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ihad
{
   short maxHealth {  get; set; }
   short currHealth { get; set; }
   short armour { get; set; }
   float blockCost { get; set; }
   bool isBlocking { get; set; }
    void GetHit(Attack strike);
    void Die();
}
