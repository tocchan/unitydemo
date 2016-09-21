using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class TransformUtil
{
   public static void LookIn2D( this Transform t, Vector2 dir )
   {
      if (dir.sqrMagnitude > 0) {
         dir.Normalize();

         float theta = Mathf.Atan2( -dir.x, dir.y );
         Quaternion rot = Quaternion.AngleAxis( Mathf.Rad2Deg *theta, Vector3.forward );
         t.rotation = rot;
      }
   }

   public static void LookAt2D( this Transform t, Vector2 pos )
   {
      Vector2 dir = pos - t.position.xy();
      t.LookIn2D( dir );
   }
}

