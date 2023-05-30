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

        //AssetBundle路径
        private string AbBasePath
        {
            get
            {
                return Util.DataPath + AppConst.AssetBundleDirName + "/";
            }
        }

        //AssetBundle资源初始化
        public void Init()
        {
            bundles = new Dictionary<string, AssetBundle>();
            string manifestFilePath = AbBasePath + AppConst.AssetBundleDirName;
            AssetBundle assetBundle = AssetBundle.LoadFromFile(manifestFilePath);
            manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }

        //加载指定AB包
        public AssetBundle LoadAssetBundle(string abName)
        {
            abName = abName.ToLower();
            //加载指定AB包的依赖项
            foreach (string path in manifest.GetAllDependencies(abName))
            {
                if (!bundles.ContainsKey(path))
                {
                    string fullPath = AbBasePath + path;
                    AssetBundle ab = AssetBundle.LoadFromFile(fullPath);
                    bundles.Add(path, ab);
                }
            }
            
            //若不在缓存里则重新加载
            AssetBundle target;
            if (!bundles.TryGetValue(abName, out target))
            {
                target = AssetBundle.LoadFromFile(AbBasePath + abName);
                bundles.Add(abName, target);
            }
            return target;
        }

        //载入资源
        public T LoadAsset<T>(string assetPath,string abName) where T : UnityEngine.Object
        {
            if (AppConst.BundleMode == false && Application.isEditor)
            {
#if UNITY_EDITOR
                
                return AssetDatabase.LoadAssetAtPath<T>(assetPath);
#else
                return null;
#endif
            }
            else
            {
                AssetBundle ab = LoadAssetBundle(abName);
                return ab.LoadAsset<T>(assetPath);
            }
        }

        //加载prefab资源
        public GameObject LoadPrefab(string assetPath)
        {
            return LoadAsset<GameObject>(assetPath, AppConst.ResPrefabDirName + AppConst.ExtName);
        }

        //加载Sprite资源
        public Sprite LoadSprite(string assetPath)
        {
            return LoadAsset<Sprite>(assetPath, AppConst.ResTexturesDirName + AppConst.ExtName);
        }
        
        //加载Texture资源
        public Texture LoadTexture(string assetPath)
        {
            return LoadAsset<Texture>(assetPath, AppConst.ResTexturesDirName + AppConst.ExtName);
        }

    }
}