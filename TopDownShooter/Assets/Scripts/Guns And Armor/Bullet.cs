
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Destroy(gameObject);

        }
        else Destroy(gameObject);
    }
}
