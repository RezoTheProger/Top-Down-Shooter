
using UnityEngine;
namespace Guns
{
    public  class Gun : MonoBehaviour
    {
        [SerializeField] protected int speed, damage, magSize, bulletsPerShot, bulletsLeft, bulletsShot;
        [SerializeField] private float timeBetweenShots, spread, range, reloadTime;
        protected bool FastShot;
        protected bool shooting, readyToShoot, reloading;
        public static float ballSpeed;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] private LayerMask whatisenemy;
        private RaycastHit rayHit;


        [SerializeField] protected GameObject ball;

        
        private void Awake()
        {
            ballSpeed = speed;
            bulletsLeft = magSize;
            readyToShoot = true;
        }

        public void Reload()
        {
            if (!reloading && bulletsLeft < magSize)
            {
                reloading = true;
                Invoke(nameof(ReloadFinish), reloadTime);
            }
        }
        private void ReloadFinish()
        {
            bulletsLeft = magSize;
            reloading = false;
        
        }
        public void Shoot()
        {
            if (readyToShoot || shooting && !reloading && bulletsLeft > 0)
            {
                bulletsShot = bulletsPerShot;


                float x = Random.Range(-spread, spread);
                float y = Random.Range(-spread, spread);

                Vector3 Dir = transform.position + new Vector3(x, y, 0);
                readyToShoot = false;
                Instantiate(ball, attackPoint.position,transform.rotation);

                if (Physics.Raycast(transform.position, Dir, out rayHit, range, whatisenemy))
                {
                    Debug.Log("PewPewPewPew");
    
                    if (rayHit.collider.CompareTag("Enemy")) Debug.Log("Ouch");
                }
                bulletsLeft--;
                bulletsShot--;
                Invoke(nameof(ResetShot), timeBetweenShots);
                if (bulletsShot > 0 && bulletsLeft > 0)
                    Invoke(nameof(Shoot), timeBetweenShots);

            }
        }
        private void ResetShot()
        {
            readyToShoot = true;
        }
        
    
}
    
}