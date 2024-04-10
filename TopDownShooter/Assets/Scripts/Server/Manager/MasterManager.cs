
using UnityEngine;

[CreateAssetMenu(menuName ="Singleton/MasterManager")]

public class MasterManager : ScriptableObjectSingleton<MasterManager>
{

    [SerializeField] private GameSettings gameSettings;
    public  static GameSettings GameSettings { get { return Instance.gameSettings; } }

}
