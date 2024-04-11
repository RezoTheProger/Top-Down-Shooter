using Photon.Pun;
using UnityEngine;
using TMPro;
public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private TMP_Text txt;

    [SerializeField] private Transform[] Place;

    [SerializeField] private  Transform Parentt;

    public static Transform Parent;


    [SerializeField] private float minX, maxX, Y, minZ, maxZ;

    private void Awake()
    {
        Parent = Parentt;
        int rnd = Random.Range(0, 2);
         PhotonNetwork.Instantiate(PlayerPrefab.name, Place[rnd].position , Quaternion.identity);
        
    }
    private void FixedUpdate()
    {
        txt.text ="Players: "+ PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }
}
