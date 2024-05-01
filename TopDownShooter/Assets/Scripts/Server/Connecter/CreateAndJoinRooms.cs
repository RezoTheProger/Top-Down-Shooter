using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField CreateInput;
    [SerializeField] private GameObject Create;

    [SerializeField] private TMP_InputField JoinInput;
    [SerializeField] private RoomListing RoomListing;
    [SerializeField] private Transform Content;
    private List<RoomListing> list = new();

    
    private void Awake()
    {
        PhotonNetwork.JoinLobby();

    }
  
    public void CreateOpener()
    {
        
        Create.transform.LeanScale(new(.7f,.7f), .3f).setEaseInExpo();
    }

    public void CreateRoom()
    {
        
        RoomOptions options = new();
        options.MaxPlayers = 10;
        options.CleanupCacheOnLeave = true;
        PhotonNetwork.CreateRoom(CreateInput.text,options,TypedLobby.Default) ;
    }



   

    public override void OnCreateRoomFailed(short returnCode, string message)=> Debug.Log("Room Creation failed" +message);

    

    public void JoinRand() => PhotonNetwork.JoinRandomOrCreateRoom();

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
