using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public MasterManager MyMaster;
    public TMP_Text problemString;
 
    private void Start()
    {
        PhotonNetwork.GameVersion = MyMaster.gameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = MyMaster.gameSettings.NickName;

    }
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");

        print(PhotonNetwork.LocalPlayer.NickName);
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        problemString.text = "Disconnected from server, reason:" + cause.ToString() + " Retrying...";
        
        PhotonNetwork.ConnectUsingSettings();

    }
    
}
