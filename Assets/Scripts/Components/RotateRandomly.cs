using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandomly : MonoBehaviour
{
   public float MinSpeed = 40.0f;
   public float MaxSpeed = 180.0f;

   private Vector3 m_axis;
   private float m_speed; 

	// Use this for initialization
	void Start ()
   {
      m_axis = Random.onUnitSphere;
      m_speed = Random.Range( MinSpeed, MaxSpeed );
	}

   void Update()
   {
      float dt = Time.deltaTime;
      Quaternion rot = Quaternion.AngleAxis( m_speed * dt, m_axis );
      transform.rotation *= rot;
   }
}
