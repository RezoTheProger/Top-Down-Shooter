using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Gun") || collision.gameObject.CompareTag("Bullet")) return;

        PhotonView PV = GetComponent<PhotonView>();
        PV.RPC("OnColl", RpcTarget.AllBuffered);

    }
    [PunRPC]
    private void OnColl()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 5);
    }
}
