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

/// <summary>
/// Unity extensions class
/// </summary>
public static class UnityExtensions
{
	/// <summary>
	/// Invokes the event.
	/// </summary>
	/// <param name="myAction">My action.</param>
	/// <param name="args">Arguments.</param>
	public static void InvokeEvent(this CustomAction myAction, params object[] args)
	{
		if (myAction != null) 
		{
			// call the delegate function
			myAction.Invoke ( args );
		}
	}

	/// <summary>
	/// Creates the task and start it immediately
	/// Usage:
	/// Task t = this.StartTask( CoroutineA() )
	/// yield return t.untilDone;		// will wait until all task is done
	/// </summary>
	/// <returns>The task.</returns>
	/// <param name="taskOwner">Task owner.</param>
	/// <param name="coroutine">Coroutine.</param>
	public static Task StartTask(this MonoBehaviour taskOwner, IEnumerator coroutine)
	{
		Task coroutineObject = new Task (taskOwner);
		coroutineObject.StartInternalRoutine (coroutine);
		return coroutineObject;
	}
		

	/// <summary>
	/// Creates the task. But not yet started
	/// Usage: 
	/// Task t = this.CreateTask( CoroutineA() );
	/// t.AddTask( CoroutineB() );
	/// t.Start();			
	/// </summary>
	/// <returns>The task.</returns>
	/// <param name="taskOwner">Task owner.</param>
	/// <param name="coroutine">Coroutine.</param>
	public static Task CreateTask(this MonoBehaviour taskOwner, IEnumerator coroutine)
	{
		Task coroutineObject = new Task (taskOwner, coroutine);
		return coroutineObject;
	}

}