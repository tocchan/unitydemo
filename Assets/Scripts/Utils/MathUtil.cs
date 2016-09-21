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
}

