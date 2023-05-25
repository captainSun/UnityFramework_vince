using System.IO;
using UnityEngine;
using UnityEditor;
using VinceFramework;

public class BuildAssetBundle
{
    public static void Build()
    {
        string streamingPath = Application.streamingAssetsPath;
        if (AppConst.AddBundleBuild != true && Directory.Exists(streamingPath)) {
            Directory.Delete(streamingPath, true);
        }
        if (Directory.Exists(Util.DataPath)) {
            Directory.Delete(Util.DataPath, true);
        }
        Directory.CreateDirectory(streamingPath);
        AssetDatabase.Refresh();
        
        string targetPath = Application.streamingAssetsPath + "/res";
        BuildUtils.BuildLuaBundle(targetPath);
        BuildUtils.BuildSceneBundle(targetPath);
        BuildUtils.BuildResBundle(targetPath);
        GameLogger.LogGreen("BuildAssetBundle Done");
    }
}
