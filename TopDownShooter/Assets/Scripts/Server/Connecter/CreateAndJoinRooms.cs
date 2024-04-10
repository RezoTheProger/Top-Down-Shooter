using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField CreateInput;
    [SerializeField] private TMP_InputField JoinInput;
    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return print("Connexion Expired");
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
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
