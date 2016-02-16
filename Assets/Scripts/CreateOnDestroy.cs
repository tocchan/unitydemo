using UnityEngine;
using System.Collections;

public class CreateOnDestroy : MonoBehaviour
{
   public GameObject Prefab;
   public float Radius = 0.0f;
   public int Count = 1;

	void OnDestroy()
   {
      if (Prefab == null) {
         return;
      }

      for (int i = 0; i < Count; ++i) {
         Vector3 offset = Random.insideUnitSphere;
         offset.z = 0.0f;

         GameObject.Instantiate( Prefab, transform.position + (Radius * offset), transform.rotation );
      }
   }
}
