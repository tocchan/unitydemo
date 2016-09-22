using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class CreateObjectOnFire : MonoBehaviour
{
   public FireTrigger Trigger;
   public GameObject Projectile;
   public float speed = 20.0f;

   public float ReloadTime = .1f;
   
   
   float m_lastFireTime;

   //-----------------------------------------------------------------------------
   void Start()
   {
      if (Trigger == null) {
         Trigger = GetComponentInParent<FireTrigger>();
      }

      if (Trigger != null) {
         Trigger.OnFire += OnFire;
      }
   }

   //-----------------------------------------------------------------------------
   void OnDestroy()
   {
      if (Trigger != null) {
         Trigger.OnFire -= OnFire;
      }
   }
   
   //-----------------------------------------------------------------------------
   void OnFire( Vector2 direction, Vector2 ownerSpeed )
   {
      if (Projectile == null) {
         return;
      }

      // CanFire
      var delay = Time.timeSinceLevelLoad - m_lastFireTime;
      if (delay < ReloadTime) {
         return;
      }

      direction = transform.forward2D();

      // Create the projectile
      GameObject bullet = GameObject.Instantiate( Projectile, transform.position, transform.rotation ) as GameObject;
      if (bullet == null) {
         return;
      }

      bullet.transform.LookIn2D( direction );      

      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      if (null != rb) {
         rb.velocity = (direction * speed) + ownerSpeed;
      }

      m_lastFireTime = Time.timeSinceLevelLoad;
   }
}

