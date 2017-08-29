using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
[RequireComponent(typeof(Rigidbody2D), typeof(FireTrigger))]
public class PlayerController : MonoBehaviour
{
   public float propulsion = 5.0f;

   // Events
   public FireTrigger fireTrigger;


   Rigidbody2D rb;

   //-----------------------------------------------------------------------------
   void Start()
   {
      // Don't search for a rigid body every frame - that search takes time
      // you don't actually need to do.
      rb = GetComponent<Rigidbody2D>();
      
      if (null == fireTrigger) {
         fireTrigger = GetComponent<FireTrigger>();
      }
   }
	
   //-----------------------------------------------------------------------------
   void Update()
   {
      Vector2 f = transform.forward2D();
	   if (Input.GetButtonDown("Fire1")) {
         // Way One - You can just fire an event, document it, and any
         // script that has a "OnFire" call will get this called.
         // gameObject.SendMessage("OnFire", SendMessageOptions.DontRequireReceiver);

         // Second way, find every component that can potentially fire, and call
         // a method directly

         // Third, create a delegate, and any component that cares about the fire event
         // can listen in here.
         if (fireTrigger != null) {
            fireTrigger.Fire(f, rb.velocity);
         }
      }
      
      Vector2 pos = Camera.main.GetMouseScreenPosition2D();
      transform.LookAt2D( pos );

      if (Input.GetButton("Jump")) {
         rb.AddForce( f * propulsion );
      }
   }
}
