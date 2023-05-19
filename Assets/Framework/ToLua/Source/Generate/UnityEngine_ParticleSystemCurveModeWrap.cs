﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_ParticleSystemCurveModeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UnityEngine.ParticleSystemCurveMode));
		L.RegVar("Constant", get_Constant, null);
		L.RegVar("Curve", get_Curve, null);
		L.RegVar("TwoCurves", get_TwoCurves, null);
		L.RegVar("TwoConstants", get_TwoConstants, null);
		L.RegFunction("IntToEnum", IntToEnum);
		L.EndEnum();
		TypeTraits<UnityEngine.ParticleSystemCurveMode>.Check = CheckType;
		StackTraits<UnityEngine.ParticleSystemCurveMode>.Push = Push;
	}

	static void Push(IntPtr L, UnityEngine.ParticleSystemCurveMode arg)
	{
		ToLua.Push(L, arg);
	}

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(typeof(UnityEngine.ParticleSystemCurveMode), L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Constant(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.ParticleSystemCurveMode.Constant);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Curve(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.ParticleSystemCurveMode.Curve);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TwoCurves(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.ParticleSystemCurveMode.TwoCurves);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TwoConstants(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.ParticleSystemCurveMode.TwoConstants);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		UnityEngine.ParticleSystemCurveMode o = (UnityEngine.ParticleSystemCurveMode)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}
