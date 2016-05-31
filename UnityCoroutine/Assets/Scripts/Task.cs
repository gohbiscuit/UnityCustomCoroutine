// ===============================
// AUTHOR: Edwin Goh
// CREATE DATE: 31-05-2016
// PURPOSE: Simple Custom Coroutine class to append task, waiting all task to be completed, enable code readable. Easy to customize and use
// SPECIAL NOTES: If u use it, will appreciate if you can write a comment on my git hub or rate the source code. Thanks!
// ===============================
// Change History:
//
//==================================


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MyPackage
{
	/// <summary>
	/// Task. Custom Courtine class can be used to add all task to a queue
	/// Useful functions:
	/// UntilDone e.g. yield return t.UntilDone	--> will wait until all task completed before moving to the next one
	/// 
	/// </summary>
	public class Task 
	{

		#region Fields
	 	private MonoBehaviour 				m_taskOwner;
		private Coroutine 					m_currentCoroutine;

		private IEnumerator 				m_internalCoroutineFunction;
		private Queue<IEnumerator> 			m_coroutineQueue = new Queue<IEnumerator>();
	 	private bool 						m_isRunning = false;
		#endregion

		#region Constructors
		public Task(MonoBehaviour owner)
		{
			m_taskOwner = owner;
		}

		public Task(MonoBehaviour owner, IEnumerator coroutineFunction)
		{
			m_taskOwner = owner;
			m_internalCoroutineFunction = coroutineFunction;
		}

		public Task()
		{
		}
			
		#endregion

		#region Getter/Setter Methods
		public Coroutine CurrentCoroutine
		{
			get { return m_currentCoroutine; }
		}

		public IEnumerator UntilDone
		{
			get
			{
				while (m_isRunning)
				{
					// wait for a frame
					yield return null;
				}
			}
		}

		public bool IsRunning { get { return m_isRunning; } }
		#endregion

		public void AddTask(IEnumerator coroutine)
		{
			m_coroutineQueue.Enqueue (coroutine);
		}

		/// <summary>
		/// Stop current Coroutine that is running. owner is running
		/// </summary>
		public void Stop()
		{
			m_isRunning = false;
			m_taskOwner.StopCoroutine (m_currentCoroutine);
			m_currentCoroutine = null;
		}

		/// <summary>
		/// Stops all coroutine that is running.
		/// All classes coroutine belong to that owner will be stopped
		/// </summary>
		public void StopAllCoroutine()
		{
			m_isRunning = false;
			m_taskOwner.StopAllCoroutines();	
			m_currentCoroutine = null;
			m_coroutineQueue.Clear ();
		}

		public void StartInternalRoutine(IEnumerator courtineFunction)
		{
			m_isRunning = true;
			m_currentCoroutine = m_taskOwner.StartCoroutine (InternalCoroutine (courtineFunction));
		}

		public void Start()
		{
			m_isRunning = true;
			m_currentCoroutine = m_taskOwner.StartCoroutine (InternalCoroutine (m_internalCoroutineFunction));
		}

		public IEnumerator InternalCoroutine(IEnumerator coroutine)
		{

			while (coroutine.MoveNext ())
			{
				yield return coroutine.Current;
			}
				
			if (m_coroutineQueue.Count == 0)
			{
				m_isRunning = false;
			}
			else
			{
				IEnumerator nextCoroutine = m_coroutineQueue.Dequeue ();
				StartInternalRoutine (nextCoroutine);
			}
		}
	}
}
