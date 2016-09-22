using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class DamageOnCollide : MonoBehaviour
{
   public float amount = 1.0f;

   void OnCollisionEnter2D( Collision2D collision )
   {
      GameObject other = collision.gameObject;
      if (other != null) {
         HealthComponent health = other.GetComponent<HealthComponent>();
         if (health != null) {
            health.Damage(amount);
         }
      }
   }
}

