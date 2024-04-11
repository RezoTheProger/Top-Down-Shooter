
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    public void Pause()
    {
        PauseMenu.SetActive(true);

    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
    }
    public void Settings()
    {
        return;
    }
    public void Quit()
    {
        PhotonNetwork.LeaveRoom(true);
        PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
        PhotonNetwork.LoadLevel("Lobby");
    }
}
