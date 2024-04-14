using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public MasterManager MyMaster;

    private void Start()
    {
        PhotonNetwork.GameVersion = MyMaster.gameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = MyMaster.gameSettings.NickName;
        if(!PhotonNetwork.IsConnected) PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");

        print(PhotonNetwork.LocalPlayer.NickName);
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server, reason:" + cause.ToString() + "Try again later.");

        
    }
}
