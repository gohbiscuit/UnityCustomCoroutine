// ===============================
// AUTHOR: Edwin Goh
// CREATE DATE: 31-05-2016
// PURPOSE: Unity custom logger class, to prevent logging if it is not editor mode. This will save alot of CPU resources, to see it on Editor, just change if !UNITY_EDITOR class to if UNITY_EDITOR
// SPECIAL NOTES: If u use it, will appreciate if you can write a comment on my git hub or rate the source code. Thanks!
// ===============================
// Change History:
//
//==================================

#if !UNITY_EDITOR
#define DEBUG_LOG_WRAPPER
#endif

using UnityEngine;
using System;
using System.Collections;

#if DEBUG_LOG_WRAPPER
public static class Debug 
{
	// putting scripting variables to change this value
	// private static bool m_isEnable = UnityEngine.Debug.isDebugBuild;

	// can use scripting variables like #IF_STAGING_SERVER to change the value
	private static bool m_isEnable = false;

	static bool IsEnable ()
	{
		return m_isEnable;
	}

	public static void Break ()
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.Break ();
	}

	public static void Log (object message)
	{
		if( !IsEnable()) 
		{
			return;
		}

		UnityEngine.Debug.Log (message);
	}

	public static void Log (object message, UnityEngine.Object context)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.Log (message, context);
	}

	static public void LogWarning (object message)
	{
		if(IsEnable()) 
		{
			return;
		}

		UnityEngine.Debug.LogWarning (message);
	}

	public static void LogWarning (object message, UnityEngine.Object context)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.LogWarning (message, context);
	}

	public static void LogError (object message)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.LogError (message);
	}

	public static void LogError (object message, UnityEngine.Object context)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.LogError (message, context);
	}

	public static void LogException (Exception exception)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.LogException (exception);
	}

	public static void LogException (Exception exception, UnityEngine.Object context)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.LogException (exception, context);
	}

	public static void DrawLine (Vector3 start, Vector3 end, Color color, float duration, bool depthTest)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest);
	}

	public static void ClearDeveloperConsole()
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.ClearDeveloperConsole();
	}


	public static void DrawRay(Vector3 start, Vector3 dir)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.DrawRay(start, dir);
	}


	public static void DrawRay(Vector3 start, Vector3 dir, Color color)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.DrawRay(start, dir, color);
	}


	public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.DrawRay(start, dir, color, duration);
	}
		
	public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration ,bool depthTest)
	{ 
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.DrawRay(start, dir, color, duration, depthTest);
	}
		
	public static void LogInfo(object message, UnityEngine.Object context)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.Log(message, context);
	}

	public static void LogInfoCat(params object[] args)
	{
		if( !IsEnable() ) 
		{
			return;
		}

		UnityEngine.Debug.Log(string.Concat(args));
	}
		
}
#endif
