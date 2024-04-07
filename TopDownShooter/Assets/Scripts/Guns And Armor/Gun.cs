using System.Collections;
using UnityEngine;
namespace Guns
{
    public  class Gun : MonoBehaviour
    {
        [SerializeField] protected int  damage, magSize, bulletsPerShot, bulletsLeft, bulletsShot;
        [SerializeField] private float speed, timeBetweenShots, spread, range, reloadTime;
        protected bool FastShot;
        protected bool shooting, readyToShoot, reloading;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] private LayerMask whatisenemy;
        private RaycastHit rayHit;


        [SerializeField] protected GameObject ball;
        
        private void Awake()
        {
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
               for(int i = 0; i < bulletsPerShot; i++)
                {
                    bulletsShot = bulletsPerShot;

                    readyToShoot = false;




                    Bullet();
                    bulletsLeft--;
                    bulletsShot++;


                    Invoke(nameof(ResetShot), timeBetweenShots);

                    if (bulletsLeft == 0) Reload();
                }

            }
        }
        private void ResetShot()
        {
            readyToShoot = true;
        }
        private void Bullet()
        {

            GameObject inst = Instantiate(ball, attackPoint.position, attackPoint.rotation);
            Rigidbody rb = inst.GetComponent<Rigidbody>();
            Transform tr = inst.GetComponent<Transform>();
            rb.AddForce(speed * attackPoint.up, ForceMode.Impulse);
            float dist = Vector3.Distance(transform.position,tr.position);
           

            if (dist > range) Destroy(inst);

            Destroy(inst,3);
        }
       
    }
    
}