
using UnityEngine;

[CreateAssetMenu(menuName ="Singleton/MasterManager")]

public class MasterManager : ScriptableObjectSingleton<MasterManager>
{

     public GameSettings gameSettings;

}
