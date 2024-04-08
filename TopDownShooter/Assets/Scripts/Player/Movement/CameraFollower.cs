
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
     private Transform target;
    [SerializeField] private float Smoother;
    [SerializeField] private Vector3 Offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        target = transform.parent.gameObject.transform.GetChild(1).gameObject.transform;
    }
    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position+ Offset;

            
            transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref velocity,Smoother);
        }
    }



}
