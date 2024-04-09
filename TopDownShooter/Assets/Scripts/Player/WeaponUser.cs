using Guns;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponUser : MonoBehaviour
{
     public static Gun Gun;
    
    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    public void OnFire()
    {
        if (Gun != null && view.IsMine )
        {
            Gun.Shoot();
            Debug.Log("pew");
        }
    }
    public void OnReload()
    {
        if (Gun != null && view.IsMine)
            Gun.Reload();
    }
   
}
