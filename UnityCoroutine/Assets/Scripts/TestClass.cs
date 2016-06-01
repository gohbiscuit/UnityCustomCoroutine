using UnityEngine;
using System.Collections;
using MyPackage;


/// <summary>
/// Sample class to test the Task as well as delegate CustomActionManager classes
/// </summary>
public class TestClass : MonoBehaviour 
{
	private CustomCoroutine m_coroutineTest;

	public EventHandler<CustomEventArgs> MyEvent;

	#region Mono

	void OnEnable()
	{
		MyEvent += HandleOnClick; 
	}

	void OnDisable()
	{
		MyEvent -= HandleOnClick; 
	}

	#endregion

 	static void HandleOnClick(object sender, CustomEventArgs args)
	{
		if (args == null || args.Current == null)
			return;

		object[] param = args.Current;

		if (param.Length == 2) 
		{
			string message = param [0] as string + param [1] as string;
			Debug.Log ("::TestClass:: HandleOnClick()" + message);
		} 
		else if(param.Length == 1)
		{
			Debug.Log ("::TestClass:: HandleOnClick()" + (int) param [0]);
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
		yield return this.StartCustomCoroutine (PrintC ()).UntilDone;

		Debug.Log ("D");

		yield return new WaitForSeconds (1);

		Debug.Log ("D Complete");
	}

	private IEnumerator PrintAll()
	{
		m_coroutineTest = this.CreateCustomCoroutine (PrintA ());
		m_coroutineTest.AddCoroutine (PrintB ());
		m_coroutineTest.AddCoroutine (PrintD());

		m_coroutineTest.Start ();

		yield return m_coroutineTest.UntilDone;

		Debug.Log ("::: Wait for 1 second. :::");
		yield return new WaitForSeconds(1);
		Debug.Log ("::: PrintAll() completes its execution :::");
	}

	void TestActionEventHandler()
	{
		MyEvent.RaiseEvent ( new CustomEventArgs("TestEvent ", 1) );
	} 

	void TestCoroutine()
	{
		Debug.Log ("::: Testing Coroutines :::");
		this.StartCustomCoroutine (PrintAll ());

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
		TestActionEventHandler ();
//		TestCoroutine ();
	}

}
