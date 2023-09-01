using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			Debug.Log("go to Background");
		}
		else
		{
			Debug.Log("go to Foreground");
		}
	}
}
