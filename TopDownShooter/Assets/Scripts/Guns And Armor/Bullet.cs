
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Gun")) return;
        else Destroy(gameObject);
    }
}
