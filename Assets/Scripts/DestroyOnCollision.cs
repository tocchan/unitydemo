using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
	void OnCollisionEnter2D( Collision2D c )
   {
      GameObject.Destroy(gameObject);
   }
}
