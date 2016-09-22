using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ParticleSystem))]
public class ChangeEmissionByVelocity : MonoBehaviour
{
   public float MinVelocity = 1.0f;
   public float MaxVelocity = 10.0f;
   public AnimationCurve SpawnControl = AnimationCurve.Linear( 0.0f, 0.0f, 1.0f, 1.0f );

   public float SpawnRate = 20.0f;
   public float AccelSpawnRate = 60.0f;

   public bool IsAccelerating = false;
   
   ParticleSystem m_system;
   Rigidbody2D m_rb;

   void Start()
   {
      m_system = GetComponent<ParticleSystem>();
      m_rb = GetComponentInParent<Rigidbody2D>();
   }
   
   void Update()
   {
      float rate = 0.0f;
      if (!IsAccelerating) {
         float v = m_rb.velocity.magnitude;
         float t = MathUtil.RangeMap( v, MinVelocity, MaxVelocity, 0.0f, 1.0f );
         t = Mathf.Clamp01(t);
         t = SpawnControl.Evaluate(t);

         rate = t * SpawnRate;
      } else {
         rate = AccelSpawnRate;
      }

      var em = m_system.emission;
      em.rate = rate;
   }
}

