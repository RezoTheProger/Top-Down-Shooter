using UnityEngine;
using Photon.Pun;
namespace Guns
{
    public  class Gun : MonoBehaviour
    {
        [SerializeField] private  int  damage, magSize, bulletsPerShot, bulletsLeft, bulletsShot;
        [SerializeField] private float speed, timeBetweenShots,  range, reloadTime;
        private bool FastShot;
        private bool  readyToShoot, reloading;
        [SerializeField] private Transform attackPoint;
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
            if (readyToShoot  && !reloading && bulletsLeft >= bulletsPerShot)
            {
                for (int i = 0; i < bulletsPerShot; i++)
                {
                    bulletsShot = bulletsPerShot;

                    readyToShoot = false;



                    PhotonView view = GetComponent<PhotonView>();
                    view.RPC("Bullet", RpcTarget.AllBuffered);

                    bulletsLeft--;
                    bulletsShot++;


                    Invoke(nameof(ResetShot), timeBetweenShots);

                    if (bulletsLeft == 0) Reload();
                }

            }
            else return;
        }
        private void ResetShot()
        {
            readyToShoot = true;
        }
        [PunRPC]
        private void Bullet()
        {
            GameObject inst = Instantiate(ball, attackPoint.position, attackPoint.rotation);
            Rigidbody rb = inst.GetComponent<Rigidbody>();
            rb.AddForce(speed * attackPoint.up , ForceMode.Impulse);
     

            Destroy(inst,5);
        }
       
    }
    
}