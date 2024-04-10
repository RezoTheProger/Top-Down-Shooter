
using UnityEngine;

[CreateAssetMenu(menuName ="Singleton/MasterManager")]

public class MasterManager : ScriptableObjectSingleton<MasterManager>
{

    [SerializeField] public GameSettings gameSettings;
    public  static GameSettings GameSettings { get { return Instance.gameSettings; } }

}
