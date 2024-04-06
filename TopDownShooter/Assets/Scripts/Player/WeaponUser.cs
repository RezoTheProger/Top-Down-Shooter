using Guns;

public class WeaponUser : Gun
{
    public void OnShoot()
    {
        if(readyToShoot && bulletsLeft>0 )
        Gun.Shoot();
    }
    public void OnReload()
    { 
        if(!reloading && bulletsLeft != magSize)
        Gun.Reload();
    }
}
