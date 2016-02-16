using UnityEngine;
using System.Collections;

public class Hitpoints : MonoBehaviour
{
   public float HP = 10.0f;

	void OnCollisionEnter2D( Collision2D c )
   {
      for (int i = 0; i < c.contacts.Length; ++i) {
         var contact = c.contacts[i];
         Debug.Log( contact.collider.name );
         var damage = contact.collider.GetComponent<DamageOnCollision>();
         if (damage != null) {
            HP -= damage.Power;
         }
      }

      if (HP <= 0.0f) {
         GameObject.Destroy(gameObject);
      }
	}
}
