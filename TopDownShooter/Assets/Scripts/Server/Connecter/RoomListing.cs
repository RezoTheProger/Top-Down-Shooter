using Photon.Realtime;
using TMPro;
using UnityEngine;
using Photon.Pun;
public class RoomListing : MonoBehaviour
{
    [SerializeField] private TMP_Text[] txt;
    public RoomInfo ri { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        ri = roomInfo;
        txt[0].text =  roomInfo.Name;
        txt[1].text = "Max players: " + roomInfo.MaxPlayers;


    }
    public void OnCLick_Button()
    {
        PhotonNetwork.JoinRoom(ri.Name);
    }
}
