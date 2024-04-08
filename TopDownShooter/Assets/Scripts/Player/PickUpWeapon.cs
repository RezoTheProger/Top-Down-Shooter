
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField]private GameObject currentWeapon;
    private bool IsPickingUp;
    public void OnPickUp()
    {
        IsPickingUp = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gun") &&IsPickingUp)
        {
            if (currentWeapon != null)
            {
                Instantiate(currentWeapon, transform.position, currentWeapon.transform.rotation);
                currentWeapon = collision.gameObject;
                collision.gameObject.transform.SetParent(transform);

            }
            else
            {
                currentWeapon = collision.gameObject;
                collision.gameObject.transform.SetParent(transform);
                currentWeapon.transform.rotation = Quaternion.Euler(currentWeapon.transform.rotation.x,transform.rotation.y,transform.rotation.z);
            }
        }
    }
}
