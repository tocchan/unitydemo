using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
[RequireComponent(typeof(LineRenderer), typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Asteroid : MonoBehaviour
{
   public LineRenderer lines;
   public float radius = 4.0f;
   public float variance = .10f;
   public int splits = 12;

   public float minSpeed = 2.0f;
   public float maxSpeed = 4.0f;
   public float minAngularSpeed = 20.0f;
   public float maxAngularSpeed = 30.0f;

   //-----------------------------------------------------------------------------
   void Start()
   {
      if (lines == null) {
         lines = GetComponent<LineRenderer>();
      }

      lines.SetWidth( .1f, .1f );

      float difference = radius * variance;
      List<Vector3> positions = new List<Vector3>();

      for (int i = 0; i < splits; ++i) {
         float theta = ((float)i / (float)(splits)) * Mathf.PI * 2.0f;

         float r = Random.Range( radius - difference, radius + difference );
         Vector3 pos = new Vector3( Mathf.Sin(theta), Mathf.Cos(theta), 0.0f );
         pos *= r;

         positions.Add(pos);
      }
      positions.Add( positions[0] );

      lines.useWorldSpace = false;
      lines.SetVertexCount( positions.Count );
      lines.SetPositions( positions.ToArray() );

      // Initialize Speed
      Rigidbody2D rb = GetComponent<Rigidbody2D>();
      if (null != rb) {
         float initialSpeed = Random.Range( minSpeed, maxSpeed );
         float initialAngular = Random.Range( minAngularSpeed, maxAngularSpeed );
         if (Random.value < .5f) {
            initialAngular = -initialAngular;
         }

         rb.velocity = MathUtil.RandomPointOnCircle() * initialSpeed;
         rb.angularVelocity = initialAngular;
         rb.mass = Mathf.PI * radius * radius;
      }
      
      // Update Collider
      CircleCollider2D col = GetComponent<CircleCollider2D>();
      if (null != col) {
         col.offset = Vector3.zero;
         col.radius = radius;
      }
   }

   void OnDrawGizmos()
   {
      Gizmos.color = Color.white;
      Gizmos.DrawWireSphere( transform.position, radius );
   }
}

