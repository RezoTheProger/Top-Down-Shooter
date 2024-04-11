using UnityEngine;
using Guns;
using UnityEngine.InputSystem;
using Photon.Pun;
public class PickUpWeapon : MonoBehaviour
{
     private Rigidbody rb;
     private CapsuleCollider coll;
     private Gun Gun;
     private WeaponUser WU;
     private PhotonView view;

    private GameObject GO;
    private Transform MainGO;
    [SerializeField] private float dropForwardForce, dropUpwardForce;

    private bool slotFull, IsPicking,Picked;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        WU = GetComponent<WeaponUser>();

    }


    private void OnTriggerStay(Collider collision)
    {
      

        if (collision.gameObject.CompareTag("Gun"))
        {
            
            GO = collision.gameObject;
            IsPicking = true;

        }

    }
    public void OnPickUp( InputAction.CallbackContext context)
    {
        if (!context.performed || !view.IsMine || slotFull || !IsPicking || Picked)
        {
            return;
        }
        view.RPC("PickUp", RpcTarget.AllBuffered);
    }
    [PunRPC]
    private void PickUp()
    {
        rb = GO.GetComponent<Rigidbody>();
        coll = GO.GetComponent<CapsuleCollider>();
        Gun = GO.GetComponent<Gun>();
        Picked = true;
        IsPicking = false;
        slotFull = true;


        //Make weapon a child of the camera and move it to default position
        Transform tr = GO.transform;
        tr.SetParent(transform.GetChild(1));
        tr.localPosition = Vector3.zero;
        tr.localRotation = Quaternion.Euler(Vector3.zero);
        tr.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
        WU.Gun = Gun;
    }
    
    public void OnDrop(InputAction.CallbackContext context)
    {
        if (!context.performed || !view.IsMine || !Picked)
        {
            return;
        }
        view.RPC("Drop", RpcTarget.AllBuffered);

    }
    [PunRPC]
    private void Drop()
    {

        Picked = false;
        slotFull = false;

        //Set parent to null
        GO.transform.SetParent(null);

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
        WU.Gun = null;

    }
}