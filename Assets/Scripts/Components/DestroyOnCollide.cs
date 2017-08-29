using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class DestroyOnCollide : MonoBehaviour
{
   public string LayerName = "Asteroid";
   public GameObject DeathEffect;

   private int m_layer; 


   private void Start()
   {
      m_layer = LayerMask.NameToLayer(LayerName);
   }

   void OnCollisionEnter2D( Collision2D collision )
   {
      if ((m_layer == 0) || (collision.gameObject.layer == m_layer)) {
         if (DeathEffect != null) {
            GameObject.Instantiate( DeathEffect, transform.position, Quaternion.identity, null );
         }

         GameObject.Destroy(gameObject);
      }
   }
}

