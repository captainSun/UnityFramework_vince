using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using LitJson;
using VinceFramework;

public class BuildUtils
{
    /// <summary>
    /// 递归遍历获取目标目录中的所有文件
    /// </summary>
    /// <param name="sourceDir">目标目录</param>
    /// <param name="splitAssetPath">是否要切割目录，以Assets目录为根</param>
    public static List<string> GetFiles(string sourceDir, bool splitAssetPath)
    {
        List<string> fileList = new List<string>();
        string[] fs = Directory.GetFiles(sourceDir);
        string[] ds = Directory.GetDirectories(sourceDir);
        for (int i = 0, len = fs.Length; i < len; ++i)
        {
            var index = splitAssetPath ? fs[i].IndexOf("Assets") : 0;
            fileList.Add(fs[i].Substring(index));
        }
        for (int i = 0, len = ds.Length; i < len; ++i)
        {
            fileList.AddRange(GetFiles(ds[i], splitAssetPath));
        }
        return fileList;
    }

    public static List<string> GetFiles(string[] sourceDirs, bool splitAssetPath)
    {
        List<string> fileList = new List<string>();
        foreach (var sourceDir in sourceDirs)
        {
            fileList.AddRange(GetFiles(sourceDir, splitAssetPath));
        }
        return fileList;
    }



    /// <summary>
    /// 根据哈希表构建AssetBundleBuild列表
    /// </summary>
    /// <param name="tb">哈希表，key为assetBundleName，value为目录</param>
    /// <returns></returns>
    public static AssetBundleBuild[] MakeAssetBundleBuildArray(Hashtable tb)
    {
        AssetBundleBuild[] buildArray = new AssetBundleBuild[tb.Count];
        int index = 0;
        foreach (string key in tb.Keys)
        {
            buildArray[index].assetBundleName = key + AppConst.ExtName;
            List<string> fileList = new List<string>();
            fileList = GetFiles(Application.dataPath + "/" + tb[key], true);
            buildArray[index].assetNames = fileList.ToArray();
            ++index;
        }

        return buildArray;
    }

    /// <summary>
    /// 打包常规配置表AssetBundle
    /// </summary>
    public static void BuildNormalCfgBundle(string targetPath)
    {
        // Hashtable tb = new Hashtable();
        // tb["normal_cfg.bundle"] = "GameRes/Config";
        // AssetBundleBuild[] buildArray = BuildUtils.MakeAssetBundleBuildArray(tb);
        // BuildUtils.BuildBundles(buildArray, targetPath);
    }

    /// <summary>
    /// 打包Lua的AssetBundle
    /// </summary>
    public static void BuildLuaBundle(string targetPath)
    {
        // 创建Lua的Bundle临时目录
        var luabundleDir = CreateTmpDir("luabundle");
        // 将Lua代码拷贝到Bundle临时目录（做加密处理）
        var luaFiles = GetFiles(new string[] { VinceFramework.AppConst.LuaFileRoot, VinceFramework.AppConst.ToLuaFileRoot }, true);
        BuildUtils.CopyLuaToBundleDir(luaFiles, luabundleDir);
        // 构建AssetBundleBuild列表
        Hashtable tb = new Hashtable();
        tb["lua"] = "luabundle";
        AssetBundleBuild[] buildArray = MakeAssetBundleBuildArray(tb);
        // 打包AssetBundle
        BuildBundles(buildArray, targetPath);

        // 删除Lua的Bundle临时目录
        DeleteDir(luabundleDir);
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 打包游戏资源AssetBundle
    /// </summary>
    public static void BuildResBundle(string targetPath)
    {
        Hashtable tb = new Hashtable();
        tb[AppConst.ResFontDirName] = AppConst.ResDirPath + AppConst.ResFontDirName;
        tb[AppConst.ResPrefabDirName] = AppConst.ResDirPath + AppConst.ResPrefabDirName;
        tb[AppConst.ResTexturesDirName] = AppConst.ResDirPath + AppConst.ResTexturesDirName;
        AssetBundleBuild[] buildArray = MakeAssetBundleBuildArray(tb);
        BuildBundles(buildArray, targetPath);
    }
    
    /// <summary>
    /// 场景单独打包
    /// </summary>
    public static void BuildSceneBundle(string targetPath)
    {
        Hashtable tb = new Hashtable();
        string[] files = Directory.GetFiles(Application.dataPath+"/"+"Res/Scenes");
        AssetBundleBuild[] buildArray = new AssetBundleBuild[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            List<string> fixedFiles = new List<string>();
            if (files[i].EndsWith(".unity"))
            {
                //切出场景文件名
                string fullName = files[i].Replace('\\', '/');
                fullName = fullName.Substring(fullName.LastIndexOf("/")+1);
                string name = fullName.Substring(0, fullName.IndexOf("."));
                //Assets目录为根切出文件目录
                var index = files[i].IndexOf("Assets");
                fixedFiles.Add(files[i].Substring(index));
                
                AssetBundleBuild build = new AssetBundleBuild();
                build.assetBundleName = "scene_" + name.ToLower() + AppConst.ExtName;
                build.assetNames = fixedFiles.ToArray();
               
                buildArray[i] = build;
                
            }
        }
        BuildBundles(buildArray, targetPath);
    }
    
    /// <summary>
    /// 打AssetBundle
    /// </summary>
    /// <param name="buildArray">AssetBundleBuild列表</param>
    public static void BuildBundles(AssetBundleBuild[] buildArray, string targetPath)
    {
        if (!Directory.Exists(targetPath))
        {
            Directory.CreateDirectory(targetPath);
        }
        BuildPipeline.BuildAssetBundles(targetPath, buildArray, BuildAssetBundleOptions.ChunkBasedCompression, GetBuildTarget());

    }

    /// <summary>
    /// 打包APP
    /// </summary>
    public static void BuildApp()
    {
        // 根据你的需求设置各种版本号
        SetAppVersion();
        // 设置APP名称
        SetAppName("VinceFramework");
        // 设置IL2CPP还是Mono
        SetScriptingBackend(false);
        // PC平台的一些设置
        SetStandalone();
        

        string[] scenes = new string[] { "Assets/Res/Scenes/Main.unity" };
        string appName = PlayerSettings.productName + "_" + VersionMgr.instance.appVersion + GetTargetPlatfromAppPostfix();
        string outputPath = Application.dataPath + "/../Bin/";
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
        string appPath = Path.Combine(outputPath, appName);
        // 执行打包APP
        BuildPipeline.BuildPlayer(scenes, appPath, GetBuildTarget(), BuildOptions.None);
        // 自动打开Bin目录
        FastOpenTools.OpenFileOrDirectory("/../Bin");
        GameLogger.Log("Build APP Done");
    }

    /// <summary>
    /// 设置各种版本号
    /// </summary>
    private static void SetAppVersion()
    {
        PlayerSettings.bundleVersion = VersionMgr.instance.appVersion;
        PlayerSettings.Android.bundleVersionCode = VersionMgr.VersionCode(VersionMgr.instance.appVersion);
        PlayerSettings.iOS.buildNumber = VersionMgr.instance.appVersion;
    }

    /// <summary>
    /// 设置APP名称，安装后显示的名称
    /// </summary>
    /// <param name="name"></param>
    private static void SetAppName(string name)
    {
        PlayerSettings.productName = name;
    }

    /// <summary>
    /// 设置IL2CPP还是Mono
    /// </summary>
    private static void SetScriptingBackend(bool il2cpp)
    {
        if (il2cpp)
        {
            PlayerSettings.SetScriptingBackend(GetBuildTargetGroup(), ScriptingImplementation.IL2CPP);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64 | AndroidArchitecture.ARMv7;
        }
        else
        {
            PlayerSettings.SetScriptingBackend(GetBuildTargetGroup(), ScriptingImplementation.Mono2x);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7;
        }
    }

    /// <summary>
    /// PC平台的一些设置
    /// </summary>
    private static void SetStandalone()
    {
#if UNITY_STANDALONE
        // 设置窗口分辨率
        PlayerSettings.fullScreenMode = FullScreenMode.Windowed;
        PlayerSettings.defaultScreenWidth = 1280;
        PlayerSettings.defaultScreenHeight = 720;
        // 设置后台运行
        PlayerSettings.runInBackground = true;
        // 后台可见
        PlayerSettings.visibleInBackground = true;
        // 允许全屏
        PlayerSettings.allowFullscreenSwitch = true;
        // 使用.Net 2.0
        PlayerSettings.SetApiCompatibilityLevel(BuildTargetGroup.Standalone, ApiCompatibilityLevel.NET_Standard_2_0);
#endif
    }

    /// <summary>
    /// 生成原始lua代码的md5
    /// </summary>
    public static void GenOriginalLuaFrameworkMD5File()
    {
        VersionMgr.instance.Init();
        JsonData jd = GetOriginalLuaframeworkMD5Json();
        var jsonStr = JsonMapper.ToJson(jd);
        jsonStr = jsonStr.Replace(",", ",\n");
        if (!Directory.Exists(BIN_PATH))
        {
            Directory.CreateDirectory(BIN_PATH);
        }
        using (StreamWriter sw = new StreamWriter(BIN_PATH + "VinceFrameworkFiles_" + VersionMgr.instance.appVersion + ".json"))
        {
            sw.Write(jsonStr);
        }
        GameLogger.Log("GenLuaframeworkMd5 Done");
    }

    public static JsonData GetOriginalLuaframeworkMD5Json()
    {
        var sourceDirs = new string[] { VinceFramework.AppConst.LuaFileRoot, VinceFramework.AppConst.ToLuaFileRoot };
        JsonData jd = new JsonData();
        foreach (var sourceDir in sourceDirs)
        {
            List<string> fileList = new List<string>();
            fileList = GetFiles(sourceDir, false);
            foreach (var luaFile in fileList)
            {
                if (!luaFile.EndsWith(".lua")) continue;

                var md5 = Util.md5file(luaFile);
                var key = luaFile.Substring(luaFile.IndexOf("Assets/"));
                jd[key] = md5;
            }
        }

        return jd;
    }
    
    
    /// <summary>
    /// 创建临时目录
    /// </summary>
    /// <returns></returns>
    public static string CreateTmpDir(string dirName)
    {
        var tmpDir = string.Format(Application.dataPath + "/{0}/", dirName);
        if (Directory.Exists(tmpDir))
        {
            Directory.Delete(tmpDir, true);

        }
        Directory.CreateDirectory(tmpDir);
        return tmpDir;
    }

    /// <summary>
    /// 删除目录
    /// </summary>
    public static void DeleteDir(string targetDir)
    {
        // 删除对应的meta文件
        if (File.Exists(targetDir + ".meta"))
        {
            File.Delete(targetDir + ".meta");
        }
        if (Directory.Exists(targetDir))
        {
            Directory.Delete(targetDir, true);
        }
        AssetDatabase.Refresh();
    }


    /// <summary>
    /// 拷贝Lua到目标目录，并做加密处理
    /// </summary>
    /// <param name="sourceDirs">源目录列表</param>
    /// <param name="luabundleDir">母包目录</param>
    public static void CopyLuaToBundleDir(List<string> luaFiles, string luabundleDir)
    {
        foreach (var luaFile in luaFiles)
        {
            if (luaFile.EndsWith(".meta")) continue;
            var luaFileFullPath = Application.dataPath + "/../" + luaFile;
            // 由于Build AssetBundle不识别.lua文件，所以拷贝一份到临时目录，统一加上.bytes结尾
            var targetFile = luaFile.Replace(AppConst.LuaFileRoot, "");
            targetFile = targetFile.Replace(AppConst.ToLuaFileRoot, "");
            targetFile = luabundleDir + targetFile + ".bytes";
            var targetDir = Path.GetDirectoryName(targetFile);
            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);

            // 做下加密
            byte[] bytes = File.ReadAllBytes(luaFileFullPath);
            byte[] encryptBytes = AESEncrypt.Encrypt(bytes);
            File.WriteAllBytes(targetFile, encryptBytes);
        }
        AssetDatabase.Refresh();
    }


    public void BuildLuaUpdateBundle(List<string> luaFileList)
    {

    }

    /// <summary>
    /// 获取当前平台
    /// </summary>
    public static BuildTarget GetBuildTarget()
    {
#if UNITY_STANDALONE
        return BuildTarget.StandaloneWindows;
#elif UNITY_ANDROID
        return BuildTarget.Android;
#else
        return BuildTarget.iOS;
#endif
    }

    public static BuildTargetGroup GetBuildTargetGroup()
    {
#if UNITY_STANDALONE
        return BuildTargetGroup.Standalone;
#elif UNITY_ANDROID
        return BuildTargetGroup.Android;
#else
        return BuildTargetGroup.iOS;
#endif
    }

    public static string GetNameByPath(string path)
    {
        if (string.IsNullOrEmpty(path)) return string.Empty;
        var name = string.Empty;
        path = path.Replace("\\", "/");
        int lastIndex = path.LastIndexOf("/");
        if (lastIndex < 0) return string.Empty;
        name = path.Remove(0, lastIndex + 1);
        return name;
    }

    /// <summary>
    /// 获取目标平台APP后缀
    /// </summary>
    /// <returns></returns>
    public static string GetTargetPlatfromAppPostfix(bool useAAB = false)
    {

#if UNITY_STANDALONE
        return ".exe";
#elif UNITY_ANDROID
        if(useAAB)
        {
            return ".aab";
        }
        else
        {
            return ".apk";
        }
#else
        return ".ipa";
#endif
    }

    public static string BIN_PATH
    {
        get { return Application.dataPath + "/../Bin/"; }
    }

}
