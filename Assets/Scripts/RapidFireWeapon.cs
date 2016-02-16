using UnityEngine;
using System.Collections;

public class RapidFireWeapon : WeaponSystem
{
   public override void OnShotHeld()
   {
      Fire();
   }
}
