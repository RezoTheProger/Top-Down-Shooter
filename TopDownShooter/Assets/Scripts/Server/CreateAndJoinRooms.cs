using UnityEngine;
using TMPro;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField CreateInput;
    [SerializeField] private TMP_InputField JoinInput;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateInput.text);
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
