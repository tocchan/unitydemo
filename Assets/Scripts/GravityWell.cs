using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour
{
   public float Radius = 10.0f;
   public float Power = 5.0f;

   void Update()
   {
      var colliders = Physics2D.OverlapCircleAll( transform.position, Radius );
      for (int i = 0; i < colliders.Length; ++i) {
         var collider = colliders[i];
         Vector2 dir = transform.position - collider.transform.position;
         float dist = dir.magnitude;
         float power = Mathf.Clamp( dist / Radius, .25f, 1.0f );
         dir = dir / dist;

         power = Power / (power * power);
         Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
         if (rb != null) {
            rb.AddForce( power * dir );
         }
      }
   }

   void OnDrawGizmos()
   {
      Gizmos.color = new Color( 1.0f, 0.0f, .5f );
      Gizmos.DrawWireSphere( transform.position, Radius );
   }
}
