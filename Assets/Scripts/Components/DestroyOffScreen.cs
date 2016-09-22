using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class DestroyOffScreen : MonoBehaviour
{
   public Bounds bounds = new Bounds( Vector3.zero, Vector3.one );

   //-----------------------------------------------------------------------------
   void Update()
   {
      Bounds screen = ScreenUtil.GetVisibleBounds();
      screen.size += bounds.size * 2.0f;
      if (!screen.Contains(transform.position)) {
         GameObject.Destroy(gameObject);
      }
   }

   //-----------------------------------------------------------------------------
   void OnDrawGizmosSelected()
   {
      Bounds me = new Bounds( transform.position, bounds.size );
      Gizmos.color = Color.green;
      Gizmos.DrawWireCube( me.center, me.size );
   }
}

