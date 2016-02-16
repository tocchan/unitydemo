using UnityEngine;

public static class MathExtensions
{
   public static float RangeMap( this float v, float s0, float s1, float f0, float f1 )
   {
      return ((v - s0) / (s1 - s0)) * (f1 - f0) + f0;
   }
}