using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour
{
   public GameObject Bullet;
   public float LaunchVelocity;

   public float RefireRate = .25f;
   
   private float _lastFireTime;
	
   public void Start()
   {
      _lastFireTime = 0.0f;
   }

   public virtual void OnStartShot()
   {
      Fire();
   }

   public virtual void OnEndShot()
   {
   }

   public virtual void OnShotHeld()
   {
   }

   public virtual void OnFire()
   {
      GameObject newBullet = (GameObject) GameObject.Instantiate(Bullet, transform.position, transform.rotation);
      if (newBullet == null) {
         return;
      }

      Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
      if (rb != null) {
         rb.velocity = LaunchVelocity * transform.up;
      }
   }

   protected void Fire()
   {
      if ((Time.time - _lastFireTime) >= RefireRate) {
         _lastFireTime = Time.time;
         OnFire();
      }
   }
}
