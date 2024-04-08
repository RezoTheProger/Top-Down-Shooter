using UnityEngine;
using Guns;
public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private  Rigidbody rb;
    [SerializeField] private CapsuleCollider coll;
    [SerializeField] private Gun Gun;


    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    public static bool IsPicking, IsThrowing;
    private void Start()
    {
        //Setup
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }


    private void OnTriggerStay(Collider collision)
    {
        if (!equipped && IsPicking && !slotFull && collision.gameObject.CompareTag("Player")){ PickUp(collision.gameObject.transform.GetChild(1).transform); IsPicking = false; }

        if (equipped && IsThrowing) { Drop(); IsThrowing = false; }
    }
    private void PickUp(Transform GO)
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(GO);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        WeaponUser.Gun = Gun;
    }

    private void Drop()
    {
        Debug.Log("ijhdsjk");
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        
        //AddForce
        rb.AddForce(transform.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(transform.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //Disable script
    }
}
