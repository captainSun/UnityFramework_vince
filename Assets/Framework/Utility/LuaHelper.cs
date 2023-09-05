using UnityEngine;
using VinceFramework;

namespace VinceFramework
{
    public static class LuaHelper
    {
        /// <summary>
        /// 资源管理器
        /// </summary>
        public static ResManager GetResManager() {
            return AppCore.Instance.resMgr;
        }
        
    }
}