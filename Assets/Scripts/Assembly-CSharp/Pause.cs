using UnityEngine;

public class Pause : MonoBehaviour
{
	public MSPFps Msp;

	private void OnGUI()
	{
		if (Msp.MSPControl.PauseStatus && GUI.Button(new Rect(Screen.width / 5, Screen.height / 2 - Screen.height / 20, Screen.width / 5 * 3, Screen.height / 10), "Menu"))
		{
			if (Msp.MSPControl.Gyro != null)
			{
				Msp.MSPControl.Gyro.enabled = false;
			}
			Application.LoadLevel("demoPkg");
		}
	}
}
