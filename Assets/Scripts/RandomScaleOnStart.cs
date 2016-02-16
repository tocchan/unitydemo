using UnityEngine;
using System.Collections;

public class RandomScaleOnStart : MonoBehaviour 
{
   public float MinScale = .8f;
   public float MaxScale = 1.2f;


	// Use this for initialization
	void Start ()
   {
      float scale = Random.Range( MinScale, MaxScale );
      scale = transform.localScale.x * scale; // use it's starting scale as "1"

      transform.localScale = new Vector3( scale, scale, scale );
	}
}
