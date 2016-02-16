using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
   public float TimeTillDeath = 15.0f;

	// Update is called once per frame
	void Update ()
   {
	   TimeTillDeath -= Time.deltaTime;
      if (TimeTillDeath <= 0.0f) {
         GameObject.Destroy(gameObject);
      }
	}
}
