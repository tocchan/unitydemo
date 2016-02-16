using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
   public float ForwardForce = 10.0f;
   public float BackForce = 5.0f;
   public float Torque = 60.0f;

   public WeaponSystem Weapons;

   private Rigidbody2D _rigidbody;
   private bool _was_firing;


   void Start()
   {
      // DO NOT USE FIND IF YOU CAN AVOID IT!
      _rigidbody = GetComponent<Rigidbody2D>();
      _was_firing = false;
   }

   void Update()
   {
      float thrust = Input.GetAxis("Vertical");
      float turn = Input.GetAxis("Horizontal");

      thrust = (thrust < 0.0f) ? thrust * BackForce : thrust * ForwardForce;
      Vector2 force = thrust * transform.up;
      _rigidbody.AddForce(force);

      // Not as physical - can turn on a time.
      _rigidbody.angularVelocity = -Torque * turn;

      bool firing = Input.GetButton("Fire1") && (Weapons != null);
      if (firing != _was_firing) {
         _was_firing = firing;
         if (firing) {
            Weapons.OnStartShot();
         } else {
            Weapons.OnEndShot();
         }
      } else if (firing) {
         Weapons.OnShotHeld();
      }
   }

}

