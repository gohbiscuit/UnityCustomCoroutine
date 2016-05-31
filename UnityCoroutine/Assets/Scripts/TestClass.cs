using UnityEngine;
using System.Collections;
using MyPackage;


/// <summary>
/// Sample class to test the Task as well as delegate CustomActionManager classes
/// </summary>
public class TestClass : MonoBehaviour 
{
	public static CustomAction OnActionClicked;

	private Task m_coroutineTest;

	#region Mono

	void OnEnable()
	{
		TestClass.OnActionClicked += HandleOnClick;
	}

	void OnDisable()
	{
		TestClass.OnActionClicked -= HandleOnClick;
	}

	#endregion

	void HandleOnClick(object[] param)
	{
		if (param.Length == 2) 
		{
			string message = param [0] as string + param [1] as string;
			Debug.Log (message);
		} 
		else if(param.Length == 1)
		{
			Debug.Log ((int) param [0]);
		}
	}

	private IEnumerator PrintA()
	{
		Debug.Log ("A");

		yield return new WaitForSeconds (2);

		Debug.Log ("A Complete");
	}

	private IEnumerator PrintB()
	{
		Debug.Log ("B");

		yield return new WaitForSeconds (1);

		Debug.Log ("B Complete");
	}

	private IEnumerator PrintC()
	{
		Debug.Log ("C");

		yield return new WaitForSeconds (1);

		Debug.Log ("C Complete");
	}

	private IEnumerator PrintD()
	{
		yield return this.StartTask (PrintC ()).UntilDone;

		Debug.Log ("D");

		yield return new WaitForSeconds (1);

		Debug.Log ("D Complete");
	}

	private IEnumerator PrintAll()
	{
		m_coroutineTest = this.CreateTask (PrintA ());
		m_coroutineTest.AddTask (PrintB ());
		m_coroutineTest.AddTask (PrintD());

		m_coroutineTest.Start ();

		yield return m_coroutineTest.UntilDone;

		Debug.Log ("::: Wait for 1 second. :::");
		yield return new WaitForSeconds(1);
		Debug.Log ("::: PrintAll() completes its execution :::");
	}

	void TestActionEventHandler()
	{
		OnActionClicked.InvokeEvent("Rate It ", "10/10");
		OnActionClicked.InvokeEvent(999);
		Debug.Log ("Number of subscribers: " + OnActionClicked.GetInvocationList ().Length);
	}

	void TestCoroutine()
	{
		Debug.Log ("::: Testing Coroutines :::");
		this.StartTask (PrintAll ());

		// output:
		// ::: Testing Coroutines :::
		// A
		// A Complete
		// B
		// B Complete
		// C 
		// C Complete
		// D 
		// D Complete
		// ::: Wait for 1 second. :::
		// ::: PrintAll() completes its execution :::
	}
		
	void Start()
	{
//		TestActionEventHandler ();
		TestCoroutine ();
	}

}
