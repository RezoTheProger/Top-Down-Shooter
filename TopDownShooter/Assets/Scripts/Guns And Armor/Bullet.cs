using Guns;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _bulletRb;
    public delegate void OnDisableCallback(Bullet instance);
    public OnDisableCallback Disable;
    private void Awake()
    {
        _bulletRb = gameObject.GetComponent<Rigidbody>();
        
    }
    public void Ball(Vector3 Direction, float speed)
    {
        _bulletRb.AddForce(Direction* speed, ForceMode.VelocityChange);
        Debug.Log("PewPew");
    }
    private void Start()
    {
        Debug.Log("PewPewPew");

        Ball(transform.position, Gun.ballSpeed);
    }
  
}
