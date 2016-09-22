using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class DestroyAfterTime : MonoBehaviour
{
   public float lifetime = 10.0f;

   float killtime = 0.0f;

   //-----------------------------------------------------------------------------
   void OnEnable()
   {
      killtime = Time.timeSinceLevelLoad + lifetime;
   }
   
   //-----------------------------------------------------------------------------
   void Update()
   {
      if (Time.timeSinceLevelLoad >= killtime) {
         GameObject.Destroy(gameObject);
      }
   }
}

