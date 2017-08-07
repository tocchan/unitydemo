using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class SpawnOnDestroy : MonoBehaviour
{
   public GameObject[] pool;
   public int count = 1;

   [Range(0.0f, 360.0f)]
   public float arc = 360.0f;

   public float minVelocity = 1.0f;
   public float maxVelocity = 5.0f;

   public float minAngularVelocity = 20.0f;
   public float maxAngularVelocity = 20.0f;

   void OnApplicationQuit()
   {
      Debug.Log("Shutting Down");
      count = 0;
   }

   void OnDestroy()
   {
      if ((pool == null) || (pool.Length == 0)) {
         return;
      }

      int c = count;
      while (c > 0) {
         SpawnObject();
         --c;
      }
   }

   void SpawnObject()
   {
      int idx = Random.Range(0, pool.Length);
      GameObject prefab = pool[idx];

      float rot = TransformUtil.GetRotation(transform);
      float minRot = rot - arc / 2.0f;
      float maxRot = rot + arc / 2.0f;

      float deg = Random.Range(minRot, maxRot);
      Vector2 p = MathUtil.GetPointOnCircle( deg * Mathf.Deg2Rad );

      GameObject obj = GameObject.Instantiate( prefab, transform.position, transform.rotation ) as GameObject;
      if (obj == null) {
         return;
      }

      obj.transform.LookIn2D(p);

      Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
      if (rb != null) {
         float vel = Random.Range( minVelocity, maxVelocity );
         float av = Random.Range( minAngularVelocity, maxAngularVelocity );
         if (Random.value < .5f) {
            av = -av;
         }

         rb.velocity = p * vel;
         rb.angularVelocity = av;
      }
   }
}

