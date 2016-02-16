using UnityEngine;
using System.Collections;

public class WrapWhenLeavingScreen : MonoBehaviour
{
   Camera _camera;

   public float Buffer = 2.0f;

	// Use this for initialization
	void Start()
   {
	   _camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
   {
      Bounds b = _camera.Get2DBounds( Buffer );  
      Vector3 position = transform.position;

      if (!b.Contains(position)) {
         float left = b.center.x - b.extents.x;
         float right = b.center.x + b.extents.x;
         float top = b.center.y + b.extents.y;
         float bottom = b.center.y - b.extents.y;

         if (position.x < left) {
            position.x = right - (left - position.x);
         } else if (position.x > right) {
            position.x = left + (position.x - right);
         } 

         if (position.y < bottom) {
            position.y = top - (bottom - position.y);
         } else if (position.y > top) {
            position.y = bottom + (position.y - top);
         }

         transform.position = position;
      }
	}
}
