﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class VinceFramework_AppConstWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(VinceFramework.AppConst), typeof(System.Object));
		L.RegFunction("New", _CreateVinceFramework_AppConst);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("DebugMode", get_DebugMode, set_DebugMode);
		L.RegVar("AddBundleBuild", get_AddBundleBuild, set_AddBundleBuild);
		L.RegVar("BundleMode", get_BundleMode, set_BundleMode);
		L.RegVar("AppName", get_AppName, null);
		L.RegVar("LuaDirName", get_LuaDirName, null);
		L.RegVar("ToLuaDirName", get_ToLuaDirName, null);
		L.RegVar("AssetBundleDirName", get_AssetBundleDirName, null);
		L.RegVar("ResDirPath", get_ResDirPath, null);
		L.RegVar("ExtName", get_ExtName, null);
		L.RegVar("FrameworkRoot", get_FrameworkRoot, null);
		L.RegVar("LuaFileRoot", get_LuaFileRoot, null);
		L.RegVar("ToLuaFileRoot", get_ToLuaFileRoot, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateVinceFramework_AppConst(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				VinceFramework.AppConst obj = new VinceFramework.AppConst();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: VinceFramework.AppConst.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DebugMode(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, VinceFramework.AppConst.DebugMode);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AddBundleBuild(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, VinceFramework.AppConst.AddBundleBuild);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BundleMode(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, VinceFramework.AppConst.BundleMode);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.AppName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaDirName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.LuaDirName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ToLuaDirName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.ToLuaDirName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetBundleDirName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.AssetBundleDirName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ResDirPath(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.ResDirPath);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ExtName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.ExtName);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FrameworkRoot(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.FrameworkRoot);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaFileRoot(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.LuaFileRoot);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ToLuaFileRoot(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, VinceFramework.AppConst.ToLuaFileRoot);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DebugMode(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			VinceFramework.AppConst.DebugMode = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AddBundleBuild(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			VinceFramework.AppConst.AddBundleBuild = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BundleMode(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			VinceFramework.AppConst.BundleMode = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

