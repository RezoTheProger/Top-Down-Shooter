using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private  Transform Parentt;

    public static Transform Parent;


    [SerializeField] private float minX, maxX, Y, minZ, maxZ;

    private void Awake()
    {
        Parent = Parentt;
        Vector3 rndPos = new(Random.Range(minX, maxX), Y, Random.Range(minZ, maxZ));
         PhotonNetwork.Instantiate(PlayerPrefab.name, rndPos, Quaternion.identity);
        
    }

}
