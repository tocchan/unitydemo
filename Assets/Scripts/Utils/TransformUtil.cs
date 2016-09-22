using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class TransformUtil
{
   public static float GetRotation( this Transform t )
   {
      return t.eulerAngles.z;
   }

   public static void SetRotation( this Transform t, float degrees )
   {
      Vector3 euler = t.eulerAngles;
      euler.z = degrees;
      t.eulerAngles = euler;
   }

   public static void LookIn2D( this Transform t, Vector2 dir )
   {
      if (dir.sqrMagnitude > 0) {
         dir.Normalize();

         float theta = MathUtil.GetAngle(dir);
         t.SetRotation( Mathf.Rad2Deg * theta );
         // Quaternion rot = Quaternion.AngleAxis( Mathf.Rad2Deg * theta, Vector3.forward );
         // t.rotation = rot;
      }
   }

   public static void LookAt2D( this Transform t, Vector2 pos )
   {
      Vector2 dir = pos - t.position.xy();
      t.LookIn2D( dir );
   }
}

