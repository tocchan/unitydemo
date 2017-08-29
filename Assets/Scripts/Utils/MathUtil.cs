using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class MathUtil 
{
   public static float RangeMap( float value, float oldMin, float oldMax, float newMin, float newMax )
   {
      float oldRange = oldMax - oldMin;
      float newRange = newMax - newMin;

      float offset = value - oldMin;
      float v = offset / oldRange;
      float newVal = newMin + v * newRange;

      return newVal;
   }

   public static Rect BoundsToRect( Bounds b )
   {
      return new Rect( b.center.xy(), b.size.xy() );
   }

   public static Vector2 GetPointOnCircle( float radians )
   {
      return new Vector2( -Mathf.Sin(radians), Mathf.Cos(radians) );
   }

   public static Vector2 RandomPointOnCircle()
   {
      float theta = Random.value * Mathf.PI * 2.0f;
      return GetPointOnCircle(theta);
   }

   
   public static float GetAngle( Vector2 dir )
   {
      return Mathf.Atan2( dir.y, dir.x );
   }

}

