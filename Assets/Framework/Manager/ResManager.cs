using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


namespace VinceFramework
{
    public class ResManager : MonoBehaviour
    {
        //AssetBundle清单
        private AssetBundleManifest manifest;
        //缓存加载过的的bundle
        private Dictionary<string, AssetBundle> bundles;

        //AssetBundle资源初始化
        public void Init()
        {
            bundles = new Dictionary<string, AssetBundle>();
            string manifestFilePath = "";
            AssetBundle assetBundle = AssetBundle.LoadFromFile(manifestFilePath);
            manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }
        
        //载入资源
        public T LoadAsset<T>(string assetPath) where T : UnityEngine.Object
        {
#if UNITY_EDITOR
            return AssetDatabase.LoadAssetAtPath<T>(Application.dataPath + "/" + AppConst.ResDirPath + assetPath);
#else
            return Application.streamingAssetsPath
#endif
        }
        
    }
}