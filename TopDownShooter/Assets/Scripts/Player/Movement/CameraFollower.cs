
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float Smoother;
    [SerializeField] private Vector3 Offset;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position+ Offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref velocity,Smoother);
        }
    }



}
