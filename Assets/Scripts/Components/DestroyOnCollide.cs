using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class DestroyOnCollide : MonoBehaviour
{
   void OnCollisionEnter2D( Collision2D collision )
   {
      GameObject.Destroy(gameObject);
   }
}

