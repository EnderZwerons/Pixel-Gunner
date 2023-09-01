using UnityEngine;

public class Logo_Script : MonoBehaviour
{
	public float time_stream;

	private float time_stream_r1;

	private bool ACTIVE_GO;

	private void Start()
	{
		time_stream_r1 = 0f;
		ACTIVE_GO = false;
		PlayerPrefs.SetInt("VIDEOAD1", 0);
		PlayerPrefs.SetInt("VIDEOAD2", 0);
	}

	private void Update()
	{
		time_stream_r1 += Time.deltaTime;
		if (time_stream_r1 > time_stream && !ACTIVE_GO)
		{
			ACTIVE_GO = true;
			Application.LoadLevel("main");
		}
	}
}
