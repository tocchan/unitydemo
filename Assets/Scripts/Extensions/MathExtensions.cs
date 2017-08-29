using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class MathExtensions
{
   // Extension
   public static Vector2 xy( this Vector3 v )
   {
      return new Vector2( v.x, v.y );
   }

   public static Vector2 forward2D( this Transform t )
   {
      return t.right.xy();
   }
}

