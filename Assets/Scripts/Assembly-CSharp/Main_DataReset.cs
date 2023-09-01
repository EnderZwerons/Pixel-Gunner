using UnityEngine;

public class Main_DataReset : MonoBehaviour
{
	private void Start()
	{
		PlayerPrefs.SetInt("UNITYADS", 0);
		Invoke("CheckArray", 3f);
	}

	private void CheckArray()
	{
	}
}
