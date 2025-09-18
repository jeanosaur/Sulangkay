using UnityEngine;

public class FallDamage : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("FallDamage"))
      {
         Destroy(gameObject);
      }
   }
}
