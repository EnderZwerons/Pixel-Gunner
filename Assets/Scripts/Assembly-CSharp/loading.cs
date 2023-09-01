using UnityEngine;

public class loading : MonoBehaviour
{
	private float streamtime;

	public int Time_Next;

	public string NextScene;

	private void Start()
	{
		Time.timeScale = 1f;
		streamtime = 0f;
	}

	private void Update()
	{
		streamtime += Time.deltaTime;
		if (streamtime >= (float)Time_Next)
		{
			Application.LoadLevel(NextScene);
		}
	}
}
