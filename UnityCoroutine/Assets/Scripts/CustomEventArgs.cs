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
	public class CustomEventArgs : EventArgs
	{
		object[] m_args;
		public CustomEventArgs(params object[] args)
		{
			m_args = args;
		}

		public object[] Current { get { return m_args; } }
	}


}