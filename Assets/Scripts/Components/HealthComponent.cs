using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class HealthComponent : MonoBehaviour
{
   public float health = 10.0f;

   public void Adjust( float v )
   {
      health += v;
      if (health < 0.0f) {
         GameObject.Destroy(gameObject);
         return;
      }
   }

   public void Damage( float v )
   {
      Adjust( -v );
   }
}

