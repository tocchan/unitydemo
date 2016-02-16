using UnityEngine;
using System.Collections;

public static class CameraExtensions
{
   // Well, getting bounds of my camera would be super useful
   public static Bounds Get2DBounds( this Camera c, float extend = 0.0f )
   {
      float width = c.orthographicSize * c.aspect * 2.0f;
      float height = c.orthographicSize * 2.0f;
      Vector3 pos = c.transform.position;
      pos.z = 0.0f; // zero out the Z
      Bounds b = new Bounds( pos, new Vector3( width + extend, height + extend, 10.0f ) );

      return b;
   }
}
