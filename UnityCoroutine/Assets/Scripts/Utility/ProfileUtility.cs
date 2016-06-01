// ===============================
// AUTHOR: Edwin Goh
// CREATE DATE: 31-05-2016
// PURPOSE: Create memory usage profiling, to track memory leaks or issue at any point of time
// SPECIAL NOTES: If u use it, will appreciate if you can write a comment on my git hub or rate the source code. Thanks!
// ===============================
// Change History:
//
//==================================


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MyPackage;

public class ProfileUtility : MonoBehaviour 
{
	[SerializeField] bool m_isDebug;
	[SerializeField] Text m_profilerText;

	float m_deltaTime;
	float m_updateInterval = 0.25f;		// update interval, 4 updates per sec

	#region Mono

	void OnEnable()
	{
		GetComponent<TestClass> ().MyEvent += OnEvent;
	}

	void OnDisable()
	{
		GetComponent<TestClass> ().MyEvent -= OnEvent;
	}

	#endregion

	void OnEvent(object sender, CustomEventArgs args)
	{
		Debug.Log ("ProfileUtility:: OnEvent() " + args.Current.Length);
	}

	void Start()
	{
		if (!m_isDebug) 
		{
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_deltaTime += Time.deltaTime;
		if (m_deltaTime > m_updateInterval) 
		{
			float heapMB = (float) Profiler.GetMonoHeapSize () / (1024 * 1024);
			float usedMB = (float)Profiler.GetMonoUsedSize () / (1024 * 1024);
		
			string heapOutput = "Mem: " + heapMB.ToString ("f2") + "MB"; 
			string usedOutput = "Used: " + usedMB.ToString ("f2") + "MB";

			m_profilerText.text = heapOutput + "\n" + usedOutput;

			m_deltaTime = 0f;
		}
	}
}
