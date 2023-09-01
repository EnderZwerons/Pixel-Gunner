using UnityEngine;

public class loading_boss : MonoBehaviour
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
			switch (PlayerPrefs.GetInt("boss_stage"))
			{
			case 0:
				Application.LoadLevel("Boss_1");
				break;
			case 1:
				Application.LoadLevel("Boss_1");
				break;
			case 2:
				Application.LoadLevel("Boss_1");
				break;
			}
		}
	}
}
