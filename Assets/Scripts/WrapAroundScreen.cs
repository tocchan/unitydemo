using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WrapAroundScreen : MonoBehaviour
{
   public Bounds MyBounds;

   void Start()
   {
      Collider2D col = GetComponent<Collider2D>();
      Bounds bounds = col.bounds;
      MyBounds.Encapsulate(bounds);
   }
   
   void Update()
   {
      Bounds screen = ScreenUtil.GetVisibleBounds();
      Bounds me = new Bounds( transform.position, MyBounds.size );
      screen.size += 2.0f * MyBounds.size;
      
      if (!screen.Contains(me.center)) {
         Vector3 newPos = me.center;
         if (me.center.x < (screen.min.x)) {
            newPos.x = screen.max.x + me.size.x;
         } else if (me.center.x > (screen.max.x)) {
            newPos.x = screen.min.x;
         } 

         if (me.center.y < (screen.min.y)) {
            newPos.y = screen.max.y;
         } else if (me.center.y > (screen.max.y)) {
            newPos.y = screen.min.y;
         }

         transform.position = newPos;
      }
   }

   void OnDrawGizmosSelected()
   {
      Bounds me = new Bounds( transform.position, MyBounds.size );

      Gizmos.color = Color.green;
      Gizmos.DrawWireCube( me.center, me.size );

      Bounds screen = ScreenUtil.GetVisibleBounds();
      Gizmos.color = Color.blue;
      Gizmos.DrawWireCube( screen.center, screen.size );

      screen.size += 2 * me.size;
      Gizmos.color = Color.red;
      Gizmos.DrawWireCube( screen.center, screen.size );
   }
}

