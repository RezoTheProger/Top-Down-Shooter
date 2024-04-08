using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private float minX, maxX, Y, minZ, maxZ;

    private void Start()
    {
        Vector3 rndPos = new(Random.Range(minX, maxX), Y, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(PlayerPrefab.name, rndPos, Quaternion.identity);
    }

}
