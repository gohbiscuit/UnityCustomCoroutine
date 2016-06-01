// ===============================
// AUTHOR: Edwin Goh
// CREATE DATE: 31-05-2016
// PURPOSE: Easy to use delegate class to handle event callbacks, useful for functions like Coroutine which does not have a return value
// SPECIAL NOTES: If u use it, will appreciate if you can write a comment on my git hub or rate the source code. Thanks!
// ===============================
// Change History:
//
//==================================

using UnityEngine;
using System.Collections;
using System;

namespace MyPackage
{
	// See TestClass.cs and Profile Utility.cs for more info on how to use it
	public delegate void EventHandler<CustomEventArgs>(object sender, CustomEventArgs e) where CustomEventArgs : EventArgs;

	public class EventManager
	{
		private static EventManager m_instance = null;
		public static EventManager Instance
		{
			get 
			{ 
				if (m_instance == null) 
				{
					m_instance = new EventManager ();
				}

				return m_instance;
			}
		}
			
	}


}