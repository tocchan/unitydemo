using UnityEngine;
using System.Collections;

public class YellOnCollision : MonoBehaviour
{
   void OnCollisionEnter2D( Collision2D c )
   {
      Debug.Log("Enter");
   }

   void OnCollisionExit2D( Collision2D c )
   {
      Debug.Log("Exit: " + c.contacts.Length );
      for (int i = 0; i < c.contacts.Length; ++i) {
         var contact = c.contacts[i];
         Debug.Log( "Contact: " 
            + contact.collider.gameObject.layer 
            + " <-> " + contact.otherCollider.gameObject.layer );
      }
   }
}
