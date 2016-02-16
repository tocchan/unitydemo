using UnityEngine;
using System.Collections;

public class RandomVelocityAndRotationOnStart : MonoBehaviour
{
   public float MinVelocity = 1.0f;
   public float MaxVeloicty = 4.0f;

   public float MinAngularVelocity = 30.0f;
   public float MaxAngularVeloicty = 160.0f;


	// Use this for initialization
	void Start ()
   {
	   var rb = GetComponent<Rigidbody2D>();
      if (rb == null) {
         return;
      }

      Vector3 dir = Random.insideUnitSphere;
      dir.z = 0.0f;
      if (dir.magnitude == 0.0f) {
         dir = Vector3.right;
      }
      dir.Normalize(); // there's a small change this might not exist... ohnoes!

      rb.velocity = dir * Random.Range( MinVelocity, MaxVeloicty );
      rb.angularVelocity = Random.Range( MinAngularVelocity, MaxAngularVeloicty );
	}
}
