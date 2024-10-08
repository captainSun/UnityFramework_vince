﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_AnimationEventWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AnimationEvent), typeof(System.Object));
		L.RegFunction("New", _CreateUnityEngine_AnimationEvent);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("stringParameter", get_stringParameter, set_stringParameter);
		L.RegVar("floatParameter", get_floatParameter, set_floatParameter);
		L.RegVar("intParameter", get_intParameter, set_intParameter);
		L.RegVar("objectReferenceParameter", get_objectReferenceParameter, set_objectReferenceParameter);
		L.RegVar("functionName", get_functionName, set_functionName);
		L.RegVar("time", get_time, set_time);
		L.RegVar("messageOptions", get_messageOptions, set_messageOptions);
		L.RegVar("isFiredByLegacy", get_isFiredByLegacy, null);
		L.RegVar("isFiredByAnimator", get_isFiredByAnimator, null);
		L.RegVar("animationState", get_animationState, null);
		L.RegVar("animatorStateInfo", get_animatorStateInfo, null);
		L.RegVar("animatorClipInfo", get_animatorClipInfo, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AnimationEvent(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.AnimationEvent obj = new UnityEngine.AnimationEvent();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.AnimationEvent.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stringParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			string ret = obj.stringParameter;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index stringParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_floatParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			float ret = obj.floatParameter;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index floatParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_intParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			int ret = obj.intParameter;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index intParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_objectReferenceParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			UnityEngine.Object ret = obj.objectReferenceParameter;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index objectReferenceParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_functionName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			string ret = obj.functionName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index functionName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			float ret = obj.time;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index time on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_messageOptions(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			UnityEngine.SendMessageOptions ret = obj.messageOptions;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index messageOptions on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFiredByLegacy(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			bool ret = obj.isFiredByLegacy;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isFiredByLegacy on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFiredByAnimator(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			bool ret = obj.isFiredByAnimator;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isFiredByAnimator on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animationState(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			UnityEngine.AnimationState ret = obj.animationState;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index animationState on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animatorStateInfo(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			UnityEngine.AnimatorStateInfo ret = obj.animatorStateInfo;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index animatorStateInfo on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animatorClipInfo(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			UnityEngine.AnimatorClipInfo ret = obj.animatorClipInfo;
			ToLua.PushValue(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index animatorClipInfo on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stringParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.stringParameter = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index stringParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_floatParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.floatParameter = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index floatParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_intParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.intParameter = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index intParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_objectReferenceParameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.CheckObject<UnityEngine.Object>(L, 2);
			obj.objectReferenceParameter = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index objectReferenceParameter on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_functionName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.functionName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index functionName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.time = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index time on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_messageOptions(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationEvent obj = (UnityEngine.AnimationEvent)o;
			UnityEngine.SendMessageOptions arg0 = (UnityEngine.SendMessageOptions)ToLua.CheckObject(L, 2, typeof(UnityEngine.SendMessageOptions));
			obj.messageOptions = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index messageOptions on a nil value");
		}
	}
}

