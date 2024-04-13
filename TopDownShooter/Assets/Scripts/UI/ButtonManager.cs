
using UnityEngine;
using Photon.Pun;
public class ButtonManager : MonoBehaviourPunCallbacks
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
   
}
