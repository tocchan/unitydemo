using UnityEngine;
using System.Collections;

public class DestroyWhenLeavingScreen : MonoBehaviour
{

	Camera _camera;

   public float Buffer = 2.0f;

	// Use this for initialization
	void Start()
   {
	   _camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
   {
      Bounds b = _camera.Get2DBounds( Buffer );  
      Vector3 position = transform.position;

      if (!b.Contains(position)) {
         GameObject.Destroy(gameObject);
      }
	}
}
