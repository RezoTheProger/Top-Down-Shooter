
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{

    [SerializeField] private int Health;
    [SerializeField] private Slider HealthSlider;
    public void Quit()
    { 
        PhotonNetwork.LeaveRoom(true);
        PhotonNetwork.LoadLevel("Lobby");
    }
    private void Awake()
    {
        HealthSlider.value = Health;
    }
    [PunRPC]
    public void TakeDamage(int damage)
    {
        Debug.Log("Ay bolna v noge*");
        
        Health -= damage;
        HealthSlider.value = Health;
        if (Health <= 0) Destroy(gameObject);
    }
}
