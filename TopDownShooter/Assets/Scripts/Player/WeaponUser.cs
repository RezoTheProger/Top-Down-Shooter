using Guns;
using Photon.Pun;
using UnityEngine;
public class WeaponUser : MonoBehaviour
{
     public  Gun Gun;
    
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
    public void OnPick()
    {
        PickUpWeapon.IsPicking = true;
    }
    public void OnThrow()
    {
        PickUpWeapon.IsThrowing = true;
    }
}
