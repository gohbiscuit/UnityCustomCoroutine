// ===============================
// AUTHOR: Edwin Goh
// CREATE DATE: 31-05-2016
// PURPOSE: Custom extensions, to make code easier to write, with lesser arguments
// SPECIAL NOTES: If u use it, will appreciate if you can write a comment on my git hub or rate the source code. Thanks!
// ===============================
// Change History:
//
//==================================

using UnityEngine;
using System.Collections;
using MyPackage;
using System;

/// <summary>
/// Unity extensions class
/// </summary>
public static class UnityExtensions
{
	/// <summary>
	/// Raises the event.
	/// </summary>
	/// <param name="myAction">My action.</param>
	/// <param name="args">Arguments.</param>
	public static void RaiseEvent(this MyPackage.EventHandler<CustomEventArgs> myEvent, CustomEventArgs args)
	{
		if (myEvent != null) 
		{
			myEvent.Invoke (myEvent, args);
		}
	}

	/// <summary>
	/// Creates the coroutine and start it immediately
	/// Usage:
	/// Task t = this.StartCustomCoroutine( CoroutineA() )
	/// yield return t.untilDone;		// will wait until all coroutine is done
	/// </summary>
	/// <returns>The task.</returns>
	/// <param name="taskOwner">Task owner.</param>
	/// <param name="coroutine">Coroutine.</param>
	public static CustomCoroutine StartCustomCoroutine(this MonoBehaviour taskOwner, IEnumerator coroutine)
	{
		CustomCoroutine coroutineObject = new CustomCoroutine (taskOwner);
		coroutineObject.StartInternalRoutine (coroutine);
		return coroutineObject;
	}
		

	/// <summary>
	/// Creates the coroutine. But not yet started
	/// Usage: 
	/// CustomCoroutine t = this.CreateCustomCoroutine( CoroutineA() );
	/// t.AddTask( CoroutineB() );
	/// t.Start();			
	/// </summary>
	/// <returns>The task.</returns>
	/// <param name="taskOwner">Task owner.</param>
	/// <param name="coroutine">Coroutine.</param>
	public static CustomCoroutine CreateCustomCoroutine(this MonoBehaviour taskOwner, IEnumerator coroutine)
	{
		CustomCoroutine coroutineObject = new CustomCoroutine (taskOwner, coroutine);
		return coroutineObject;
	}

}