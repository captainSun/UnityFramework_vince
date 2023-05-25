using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinceFramework
{
    public class AppConst
    {
        public const bool DebugMode = false;                        //调试模式-用于内部测试
        public const string AppName = "Framework";                  //应用程序名称
        public const string LuaDirName = "Lua";                      //业务所需Lua文件目录
        public const string ToLuaDirName = "ToLua/Lua";              //ToLua里的lua文件目录
        public static bool AddBundleBuild = false;                    //增量打包
        // public const int TimerInterval = 1;
        // public const int GameFrameRate = 30;                       //游戏帧频
        //
        //
        // public const string LuaTempDir = "Lua/";                    //临时目录
        public const string ExtName = ".unity3d";                   //资源扩展名
        // public const string AppPrefix = AppName + "_";              //应用程序前缀
        // public const string WebUrl = "http://localhost:6688/";      //测试更新地址
        //
        // public static string UserId = string.Empty;                 //用户ID
        // public static int SocketPort = 0;                           //Socket服务器端口
        // public static string SocketAddress = string.Empty;          //Socket服务器地址
        //
        // public static bool UseFileList = true;                      //是否启用配置的filelist
        // public static string LuaFileListName = "LuaFileList.lua";      //要加载的lua 文件列表
        // public static string LuaSecretKey = "u8MaPfYjXKdb/cFs1fk+d5"; //lua 加密用的密钥

        public static string FrameworkRoot
        {
            get
            {
                return Application.dataPath + "/" + AppName;
            }
        }
        
        public static string LuaFileRoot
        {
            get
            {
                return Application.dataPath + "/" + LuaDirName;
            }
        }
        
        public static string ToLuaFileRoot
        {
            get
            {
                return Application.dataPath + "/" + AppName + "/" + ToLuaDirName;
            }
        }
    }
}
