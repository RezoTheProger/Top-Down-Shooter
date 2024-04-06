
using UnityEngine;
namespace Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] protected int damage, magSize, bulletsPerShot, bulletsLeft;
        [SerializeField] private float timeBetweenShots, spread, range, reloadTime;
        [SerializeField] private bool FastShot;
        protected bool shoothing, readyToShoot, reloading;
        private Transform attackPoint;





        public static void Reload()
        {
            Debug.Log("IsReloading");

        }
        public static void Shoot()
        {
            Debug.Log("Isshooting");
        }
    }
}