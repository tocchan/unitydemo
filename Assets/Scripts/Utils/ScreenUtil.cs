using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class ScreenUtil
{
   // Used to just get the bounding rect for my game
   public static Bounds GetVisibleBounds()
   {
      Camera mc = Camera.main;
      if (null == mc) {
         return new Bounds();
      }

      float height = mc.orthographicSize * 2.0f;
      float width = mc.aspect * height;

      Vector2 pos = mc.transform.position.xy();
      Vector2 dim = new Vector2( width, height );

      return new Bounds( pos, dim );
   }


   // Extension for Camera
   public static Vector2 GetMouseScreenPosition2D( this Camera cam )
   {
      if (cam != null) {
         Vector3 screen = cam.ScreenToWorldPoint( Input.mousePosition );
         return screen.xy();
      }

      return Vector2.zero;
   }


}

