using System;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

namespace VinceFramework
{
    /// <summary>
    /// 主循环
    /// </summary>
    public class Looper : MonoBehaviour
    {
        private const string EVENT_UPDATE = "Event_Update";
        private const string EVENT_LATE_UPDATE = "Event_LateUpdate";
        private const string EVENT_FIXED_UPDATE = "Event_FixedUpdate";
        private const string EVENT_RESIZE = "Event_Resize";
        private const string EVENT_ACTIVATED = "Event_Activated";
        private const string EVENT_DEACTIVATED = "Event_Deactivated";

        // - View/Stage.lua
        private LuaFunction m_dispatchEvent;
        
        // 当前程序是否已激活
        private bool m_activated = true;

        
        void Start()
        {
            m_dispatchEvent = AppCore.Instance.luaMgr.state.GetFunction("Stage._loopHandler");

        }
        
        /// <summary>
        /// 向 lua 层抛出事件
        /// </summary>
        /// <param name="type">Type.</param>
        private void DispatchLuaEvent(string type)
        {
            if (m_dispatchEvent == null) return;
            m_dispatchEvent.BeginPCall();
            m_dispatchEvent.Push(type);
            m_dispatchEvent.Push(TimeUtil.timeSec);
            m_dispatchEvent.PCall();
            m_dispatchEvent.EndPCall();
        }



        void Update()
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPaused) return;
#endif

            TimeUtil.Update();
            Timer.Update();
            // lua Update
            DispatchLuaEvent(EVENT_UPDATE);
        }



        void LateUpdate()
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPaused) return;
#endif

            TimeUtil.Update();
            DispatchLuaEvent(EVENT_LATE_UPDATE);
        }



        void FixedUpdate()
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPaused) return;
#endif

            TimeUtil.Update();
            DispatchLuaEvent(EVENT_FIXED_UPDATE);
        }



        void OnApplicationFocus(bool hasFocus)
        {
            ActivationChanged(hasFocus);
        }

        void OnApplicationPause(bool pauseStatus)
        {
            ActivationChanged(!pauseStatus);
        }

        private void ActivationChanged(bool activated)
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPaused) return;
#endif

            if (activated)
            {
                if (!m_activated)
                {
                    m_activated = true;
                    TimeUtil.Update();
                    DispatchLuaEvent(EVENT_ACTIVATED);
                }
            }
            else
            {
                if (m_activated)
                {
                    m_activated = false;
                    TimeUtil.Update();
                    DispatchLuaEvent(EVENT_DEACTIVATED);
                }
            }
        }
        
    }
}