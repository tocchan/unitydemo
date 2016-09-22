using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class WrapAroundScreen : MonoBehaviour
{
   public Bounds myBounds;
   public float buffer = 2.0f;

   Collider2D myCollider;

   //-----------------------------------------------------------------------------
   void Start()
   {
      myCollider = GetComponent<Collider2D>();
   }
   
   //-----------------------------------------------------------------------------
   void Update()
   {
      // Update Bounds - ineffecient, should probably cache off
      if (myCollider != null) {
         Bounds bounds = myCollider.bounds;
         bounds.center = Vector3.zero;
         myBounds.Encapsulate(bounds);
      }

      // Check bounds, if I left, wrap!
      Bounds screen = ScreenUtil.GetVisibleBounds();
      Bounds me = new Bounds( transform.position, myBounds.size );
      screen.size += buffer * myBounds.size;
      
      if (!screen.Contains(me.center)) {
         Vector3 newPos = me.center;
         if (me.center.x < (screen.min.x)) {
            newPos.x = screen.max.x - .1f;
         } else if (me.center.x > (screen.max.x)) {
            newPos.x = screen.min.x + .1f;
         } 

         if (me.center.y < (screen.min.y)) {
            newPos.y = screen.max.y - .1f;
         } else if (me.center.y > (screen.max.y)) {
            newPos.y = screen.min.y + .1f;
         }

         transform.position = newPos;
      }
   }

   //-----------------------------------------------------------------------------
   void OnDrawGizmosSelected()
   {
      Bounds me = new Bounds( transform.position, myBounds.size );

      Gizmos.color = Color.green;
      Gizmos.DrawWireCube( me.center, me.size );

      Bounds screen = ScreenUtil.GetVisibleBounds();
      Gizmos.color = Color.blue;
      Gizmos.DrawWireCube( screen.center, screen.size );

      screen.size += buffer * me.size;
      Gizmos.color = Color.red;
      Gizmos.DrawWireCube( screen.center, screen.size );
   }
}

