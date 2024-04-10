using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnGun : MonoBehaviour
{
    [SerializeField] private List<Transform> Place = new();
    [SerializeField] private GameObject[] Gun;
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < Place.Count; i++)
            {

                int j = Random.Range(0, Place.Count);
                PhotonNetwork.Instantiate(Gun[i].name, Place[j].position, Gun[i].transform.rotation).transform.SetParent(transform); ;
                

                Place.RemoveAt(j);
            }

        }
    }
}
