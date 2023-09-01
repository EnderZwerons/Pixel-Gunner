using UnityEngine;

public class bgm : MonoBehaviour
{
	public AudioSource thisaudio;

	private void Start()
	{
		Object.DontDestroyOnLoad(this);
	}

	private void Update()
	{
		switch (PlayerPrefs.GetInt("bgm"))
		{
		case 0:
			if (PlayerPrefs.GetInt("bgm_on") == 0)
			{
				thisaudio.mute = false;
			}
			else
			{
				thisaudio.mute = true;
			}
			break;
		case 1:
			thisaudio.mute = true;
			break;
		}
	}
}
