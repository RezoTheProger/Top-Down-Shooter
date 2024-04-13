using UnityEngine;
using Photon.Pun;
namespace Guns
{
    public  class Gun : MonoBehaviour
    {
        [SerializeField] private  int damage;
        [SerializeField] private Vector3 OffSet;

        [SerializeField] private  int   magSize, bulletsPerShot, bulletsLeft, bulletsShot;
        [SerializeField] private float speed, timeBetweenShots,  range, reloadTime;
        private bool  readyToShoot, reloading;
        [SerializeField] private Transform attackPoint;

        [SerializeField] private LayerMask WhatIsEnemy;
        [SerializeField] protected GameObject ball;

        [SerializeField] private Color clr;

        private void Awake()
        {
            bulletsLeft = magSize;
            readyToShoot = true;
            
        }
        private void Update()
        {
            if (Physics.Raycast(transform.position, attackPoint.up * speed, out RaycastHit hit, 100f))
            {
                if (hit.transform.gameObject.GetComponent<PlayerManager>()) 

                Debug.DrawRay(transform.position, hit.distance  * attackPoint.up, Color.green);
            }
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

            if (Physics.Raycast(attackPoint.position + OffSet, attackPoint.up * speed, out RaycastHit hit, 100))
            {
                
                Debug.DrawRay(attackPoint.position + OffSet, hit.distance * attackPoint.up, Color.red, 1);
                if (hit.transform.gameObject.GetComponent<PlayerManager>())
                {
                    hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);

                }
            }

            GameObject inst = Instantiate(ball, attackPoint.position, attackPoint.rotation);
            Rigidbody rb = inst.GetComponent<Rigidbody>();
            rb.AddForce(speed * attackPoint.up, ForceMode.Impulse);
            
            Destroy(inst,5);
        }
       
    }
    
}