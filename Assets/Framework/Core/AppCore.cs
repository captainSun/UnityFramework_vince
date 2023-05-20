using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinceFramework
{
    public class AppCore 
    {
        private static AppCore _instance;
        public static AppCore Instance
        {
            get{
                if (_instance == null) {
                    _instance = new AppCore();
                }
                return _instance;
            }
        }
        public AppCore()
        {
        }
        
        static GameObject m_GameManager; //管理者gameObject
        static Dictionary<string, object> m_Managers = new Dictionary<string, object>(); //管理器容器

        public GameObject AppGameManager
        {
            get
            {
                if (m_GameManager == null)
                {
                    m_GameManager = GameObject.Find("GameManager");
                    if(m_GameManager == null)
                    {
                        m_GameManager = new GameObject("GameManager");
                    }
                }
                return m_GameManager;
            }
        }
        
        /// <summary>
        /// 添加管理器
        /// </summary>
        public T AddManager<T>(string typeName) where T : Component {
            object result = null;
            m_Managers.TryGetValue(typeName, out result);
            if (result != null) {
                Debug.Log("Manager已经存在 " + typeName);
                return (T)result;
            }
            Component c = AppGameManager.AddComponent<T>();
            m_Managers.Add(typeName, c);
            return (T)c;
        }

        /// <summary>
        /// 获取管理器
        /// </summary>
        public T GetManager<T>(string typeName) where T : class {
            if (!m_Managers.ContainsKey(typeName)) {
                return default(T);
            }
            object manager = null;
            m_Managers.TryGetValue(typeName, out manager);
            return (T)manager;
        }

        /// <summary>
        /// 删除管理器
        /// </summary>
        public void RemoveManager(string typeName) {
            if (!m_Managers.ContainsKey(typeName)) {
                return;
            }
            object manager = null;
            m_Managers.TryGetValue(typeName, out manager);
            Type type = manager.GetType();
            if (type.IsSubclassOf(typeof(MonoBehaviour))) {
                GameObject.Destroy((Component)manager);
            }
            m_Managers.Remove(typeName);
        }
        
        /// <summary>
        /// 启动框架
        /// </summary>
        public void StartUp()
        {
            LuaManager luaMgr = AddManager<LuaManager>(ManagerName.Lua);
            luaMgr.StartMain();
        }
        
    }
}

