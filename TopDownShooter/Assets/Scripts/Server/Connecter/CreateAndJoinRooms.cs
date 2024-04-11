using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField CreateInput;
    [SerializeField] private TMP_InputField JoinInput;
    [SerializeField] private RoomListing RoomListing;
    [SerializeField] private Transform Content;
    private List<RoomListing> list = new();

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return ;
        RoomOptions options = new();
        options.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(CreateInput.text,options,TypedLobby.Default) ;
    }



    public override void OnCreatedRoom()
    {

        Debug.Log("CreatedRoom");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation failed" +message);

    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = list.FindIndex(x => x.ri.Name == info.Name);
                if (index != -1){
                    Destroy(list[index].gameObject);
                    list.RemoveAt(index);
                }
            }
            else
            {
                RoomListing listing = Instantiate(RoomListing, Content);
                if (listing != null) { 
                    listing.SetRoomInfo(info);
                    list.Add(listing);
                }
            }
        }
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
