using System;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
	public static DebugManager instance;

	public bool TestMode;

	public string[] DebugText = new string[5];

	private void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		instance = this;
	}

	private void OnGUI()
	{
		if (TestMode)
		{
			GUI.Label(new Rect(0f, 0f, Screen.width, 20f), DebugText[0]);
			GUI.Label(new Rect(0f, 20f, Screen.width, 20f), DebugText[1]);
			GUI.Label(new Rect(0f, 40f, Screen.width, 20f), DebugText[2]);
			GUI.Label(new Rect(0f, 60f, Screen.width, 20f), DebugText[3]);
			GUI.Label(new Rect(0f, 80f, Screen.width, 20f), DebugText[4]);
		}
	}

	public void GetData(string Datastring)
	{
		DebugText[4] = DebugText[3];
		DebugText[3] = DebugText[2];
		DebugText[2] = DebugText[1];
		DebugText[1] = DebugText[0];
		DebugText[0] = string.Concat("(", DateTime.Now, ") ", Datastring);
	}
}
