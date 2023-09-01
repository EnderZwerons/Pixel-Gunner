using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PauseJS : MonoBehaviour
{
	public MSPFps_JS Msp;

	public void OnGUI()
	{
		if (Msp.MSPControl.PauseStatus && GUI.Button(new Rect(Screen.width / 5, Screen.height / 2 - Screen.height / 20, Screen.width / 5 * 3, Screen.height / 10), "Menu"))
		{
			if (!RuntimeServices.EqualityOperator(Msp.MSPControl.Gyro, null))
			{
				Msp.MSPControl.Gyro.enabled = false;
			}
			Application.LoadLevel("demoPkg");
		}
	}

	public void Main()
	{
	}
}
