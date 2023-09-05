using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VinceFramework;

public class StartUp : MonoBehaviour
{
    
    private void Start()
    {
        print("Game Start " + Time.realtimeSinceStartup);
        AppCore.Instance.StartUp();   //启动游戏
        
        //GameObject UICanvas = Instantiate(AppCore.Instance.resMgr.LoadPrefab("Res/Prefabs/UICanvas.prefab"));
        // GameObject go = Instantiate(resMgr.LoadPrefab("Res/Prefabs/TestImage.prefab"), UICanvas.transform);
        // var image = go.GetComponent<Image>();
        // image.sprite = resMgr.LoadSprite("Res/Textures/equip_1.png");
    }
    
    [MenuItem("VinceSettings/DeveloperMode")]
    static void ActiveDeveloperMode()
    {
        bool flag = EditorPrefs.GetBool("DeveloperMode");
        EditorPrefs.SetBool("DeveloperMode", !flag);
    }
}
