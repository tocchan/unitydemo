using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEffectFinished : MonoBehaviour
{
   public ParticleSystem SystemToWatch;

   private void Start()
   {
      SystemToWatch = GetComponent<ParticleSystem>();
   }

   private void Update()
   {
      if ((SystemToWatch == null) || (false == SystemToWatch.IsAlive(true))) {
         GameObject.Destroy(gameObject);
      }
   }
}
