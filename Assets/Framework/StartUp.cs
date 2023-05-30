using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VinceFramework;

public class StartUp : MonoBehaviour
{
    
    private void Start()
    {
        print("Game Start " + Time.realtimeSinceStartup);
        AppCore.Instance.StartUp();   //启动游戏

        ResManager resMgr = AppCore.Instance.GetManager<ResManager>(ManagerName.Resource);
       
        GameObject UICanvas = Instantiate(resMgr.LoadPrefab("Assets/Res/Prefabs/UICanvas.prefab"));
        GameObject go = Instantiate(resMgr.LoadPrefab("Assets/Res/Prefabs/TestImage.prefab"), UICanvas.transform);
        var image = go.GetComponent<Image>();
        image.sprite = resMgr.LoadSprite("Assets/Res/Textures/equip_1.png");
    }
}
