using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedByLasers : MonoBehaviour
{
   public float Health = 4;

   public GameObject DeathEffect;

   public GameObject SpawnOnDeath;
   public int NumberToSpawn = 0;

	// Use this for initialization
	void Start ()
   {
		
	}
	
	// Update is called once per frame
	void Update ()
   {
		
	}

   private void OnCollisionEnter2D( Collision2D collision )
   {
      if (collision.gameObject.layer == LayerMask.NameToLayer("Projectile")) {
         --Health;
         if (Health < 0) {
            Die();
         }
      }
   }

   private void Die()
   {
      if (DeathEffect != null) {
         GameObject.Instantiate( DeathEffect, transform.position, Quaternion.identity, null );
      }

      if (SpawnOnDeath != null) {
         for (int i = 0; i < NumberToSpawn; ++i) {
            GameObject.Instantiate( SpawnOnDeath, transform.position, Quaternion.identity, null );
         }
      }

      GameObject.Destroy(gameObject);
   }
}
