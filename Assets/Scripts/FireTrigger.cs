using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void DOnFire( Vector2 direction, Vector2 ownerSpeed );

//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
public class FireTrigger : MonoBehaviour
{
   public DOnFire OnFire;

   //-----------------------------------------------------------------------------
   public void Fire( Vector2 dir, Vector2 ownerSpeed )
   {
      OnFire(dir, ownerSpeed);
   }
}

