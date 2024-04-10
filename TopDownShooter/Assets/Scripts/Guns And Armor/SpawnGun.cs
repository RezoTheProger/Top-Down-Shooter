using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnGun : MonoBehaviour
{
    [SerializeField] private List<Transform> Place = new();
    [SerializeField] private GameObject[] Gun;
    private static bool Placed =true;
    private void Start()
    {
        if (Placed)
        {
            for (int i = 0; i < Place.Count; i++)
            {

                int j = Random.Range(0, Place.Count);
                var GO = PhotonNetwork.Instantiate(Gun[i].name, Place[j].position, Gun[i].transform.rotation);
                GO.transform.SetParent(transform);

                Place.RemoveAt(j);
            }
        }
        Placed = false;
    }
}
