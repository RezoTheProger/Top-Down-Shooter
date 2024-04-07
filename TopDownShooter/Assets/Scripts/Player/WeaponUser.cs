using Guns;
using UnityEngine;
public class WeaponUser : MonoBehaviour
{
     public  Gun Gun;
    public void OnFire()
    {
        if (Gun != null)
        {
            Gun.Shoot();
            Debug.Log("pew");
        }
    }
    public void OnReload()
    {
        if (Gun != null)
            Gun.Reload();
    }
}
