using UnityEngine;
using LuaInterface;
using System;

namespace VinceFramework
{
    public class LuaManager : MonoBehaviour
    {
        public LuaState state { get; private set; }
        private LuaLooper m_looper;
        
        void Awake()
        {
            state = new LuaState();
            OpenLibs();
            state.LuaSetTop(0);

            LuaBinder.Bind(state);
            DelegateFactory.Init();
            LuaCoroutine.Register(state, this);
        }

        /// <summary>
        /// 启动lua虚拟机 执行Main文件
        /// </summary>
        public void StartMain()
        {  
            // state.AddSearchPath(AppConst.LuaFileRoot);
            state.Start();
            DoFile("Main.lua");
            // StartLooper();
        }
        
        /// <summary>
        /// 初始化加载第三方库
        /// </summary>
        void OpenLibs()
        {
            state.OpenLibs(LuaDLL.luaopen_pb);
            state.OpenLibs(LuaDLL.luaopen_lpeg);
#if LUA_VERSION_5_3
            lua.OpenLibs(LuaDLL.luaopen_bit32);
#else
            state.OpenLibs(LuaDLL.luaopen_bit);
#endif
            state.OpenLibs(LuaDLL.luaopen_socket_core);

            // cjson 比较特殊，只new了一个table，没有注册库，这里注册一下
            state.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
            state.OpenLibs(LuaDLL.luaopen_cjson);
            state.LuaSetField(-2, "cjson");
            state.OpenLibs(LuaDLL.luaopen_cjson_safe);
            state.LuaSetField(-2, "cjson.safe");
        }
        
        /// <summary>
        /// 启动LuaLooper
        /// </summary>
        void StartLooper()
        {
            m_looper = AppCore.Instance.AppGameManager.AddComponent<LuaLooper>();
            m_looper.luaState = state;
        }
        
        public void DoFile(string filename)
        {
            state.DoFile(filename);
        }
        
        public void LuaGC()
        {
            state.LuaGC(LuaGCOptions.LUA_GCCOLLECT);
        }


        /// <summary>
        /// 销毁
        /// </summary>
        public void Destroy()
        {
            m_looper.Destroy();
            Destroy(m_looper);
            m_looper = null;

            state.Dispose();
            state = null;

            Destroy(this);
        }

    }
}