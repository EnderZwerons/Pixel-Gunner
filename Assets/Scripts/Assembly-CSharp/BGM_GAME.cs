using UnityEngine;

public class BGM_GAME : MonoBehaviour
{
	public AudioSource BGM_AUDIO;

	private void Awake()
	{
		if (PlayerPrefs.GetInt("bgm_on") == 0)
		{
			BGM_AUDIO.mute = false;
		}
		else
		{
			BGM_AUDIO.mute = true;
		}
	}
}
