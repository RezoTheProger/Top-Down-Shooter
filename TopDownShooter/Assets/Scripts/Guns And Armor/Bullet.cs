
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
   
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Gun") || collision.gameObject.CompareTag("Bullet")) return;

         Destroy(gameObject,5);

    }
}
