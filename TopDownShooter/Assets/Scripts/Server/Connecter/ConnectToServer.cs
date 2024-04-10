using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;

    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        print(PhotonNetwork.LocalPlayer.NickName);
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server, reason:" + cause.ToString() + "Try again later.");

        
    }
}
