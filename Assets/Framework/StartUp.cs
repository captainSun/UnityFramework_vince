using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VinceFramework;
using Logger = VinceFramework.Logger;

public class StartUp : MonoBehaviour
{
    
    private void Start()
    {
        print("Game Start " + Time.realtimeSinceStartup);
        AppCore.Instance.StartUp();  
        TimeUtil.Initialize();
        Logger.Initialize();
        Common.looper = AppCore.Instance.AppGameManager.AddComponent<Looper>();
    }
    
    [MenuItem("VinceSettings/DeveloperMode")]
    static void ActiveDeveloperMode()
    {
        bool flag = EditorPrefs.GetBool("DeveloperMode");
        EditorPrefs.SetBool("DeveloperMode", !flag);
    }
}
