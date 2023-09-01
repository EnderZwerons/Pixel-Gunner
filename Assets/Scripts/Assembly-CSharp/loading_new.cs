using UnityEngine;

public class loading_new : MonoBehaviour
{
	private float streamtime;

	public int Time_Next;

	public string NextScene;

	private bool boolscene;

	public UISlider persent_bar;

	private void Start()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("bgm", 0);
		streamtime = 0f;
		boolscene = true;
	}

	private void Update()
	{
		streamtime += Time.deltaTime;
		if (streamtime >= (float)Time_Next && boolscene)
		{
			Application.LoadLevel(NextScene);
			boolscene = false;
		}
		persent_bar.value = streamtime / (float)Time_Next;
	}
}
