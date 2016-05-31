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

namespace MyPackage
{
	// See TestClass.cs for more info on how to use it
	/// <summary>
	/// Custom Action. Declares a custom delegate static
	/// Usage:
	/// class A
	/// public static SURFAction OnActionClicked;
	/// 
	/// OnActionClick.InvokeEvent(<params>);
	/// class B
	/// 
	/// void OnEnable()
	///	{
	///		A.OnActionClicked += HandleOnClick;
	///	}
	///
	///	void OnDisable()
	///	{
	///		A.OnActionClicked -= HandleOnClick;
	///	}
	/// 
	/// 
	/// </summary>
	public delegate void CustomAction(object[] param);
}
