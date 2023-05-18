using UnityEngine;
using LuaInterface;
using System;

namespace LuaFramework
{
    public class LuaManager
    {
        private static LuaManager _instance;
        public static LuaManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LuaManager();
                }

                return _instance;   
            }
        }

        public LuaState state { get; private set; }
        private LuaLooper m_looper;
        private LuaManager()
        {
            
            state = new LuaState();
            OpenLibs();
            state.LuaSetTop(0);

            LuaBinder.Bind(state);
            DelegateFactory.Init();
            // LuaCoroutine.Register(state, this);
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
        
    }
}