using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomVelocity : MonoBehaviour
{
   public float MinSpeed = 4.0f;
   public float MaxSpeed = 8.0f;


	// Use this for initialization
	void Start()
   {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
      
      Vector2 dir = MathUtil.RandomPointOnCircle();

      float speed = Random.Range( MinSpeed, MaxSpeed );
      rb.velocity = dir * speed;
	}
}
