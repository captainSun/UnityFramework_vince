using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinceFramework;

public class StartUp : MonoBehaviour
{
    
    private void Start()
    {
        print("Game Start " + Time.realtimeSinceStartup);
        AppCore.Instance.StartUp();   //启动游戏
    }
}
