// ===============================
// AUTHOR: Edwin Goh
// CREATE DATE: 31-05-2016
// PURPOSE: Create custom frame rate profiling, to display in build (as Unity stats might not be accurate)
// SPECIAL NOTES: If u use it, will appreciate if you can write a comment on my git hub or rate the source code. Thanks!
// ===============================
// Change History:
//
//==================================

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour {

	[SerializeField] Text m_fpsCounter;

	int m_frames = 0; 					// Frames drawn over the interval
	float m_deltaTime;
	float m_updateInterval = 0.25f;		// update interval, 4 updates per sec

	// Use this for initialization
	void Start () 
	{
	}
		
	void Update()
	{
		m_frames++;
		m_deltaTime += Time.deltaTime;

		// 0.25s passed, do an update
		if (m_deltaTime > m_updateInterval) 
		{
			m_fpsCounter.text = "FPS: " + (m_frames/m_deltaTime).ToString("f2");
			m_frames = 0;
			m_deltaTime = 0f;
		}
	}
}
