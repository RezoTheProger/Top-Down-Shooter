using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private TMP_Text txt;

    [SerializeField] private Transform[] Place;

    [SerializeField] private  Transform Parentt;

    public static Transform Parent;


    [SerializeField] private List<Transform> GunPlace = new();
    [SerializeField] private GameObject[] Gun;

    [SerializeField] private GameObject StartButton;

    private void Awake()
    {

        if (PhotonNetwork.IsMasterClient) StartButton.SetActive(true);

        Parent = Parentt;
        int rnd = Random.Range(0, 2);
         PhotonNetwork.Instantiate(PlayerPrefab.name, Place[rnd].position , Quaternion.identity);

    }
    private void FixedUpdate()
    {
        txt.text = "Players: " + PhotonNetwork.CurrentRoom.PlayerCount.ToString();

    }
    
    public void Spawnn()
    {

        StartButton.SetActive(false);
        for (int i = 0; i < GunPlace.Count; i++)
        {

            int j = Random.Range(0, GunPlace.Count);
            PhotonNetwork.InstantiateRoomObject(Gun[i].name, Place[j].position, Gun[i].transform.rotation).transform.SetParent(transform);



            GunPlace.RemoveAt(j);
        }

    }

}
