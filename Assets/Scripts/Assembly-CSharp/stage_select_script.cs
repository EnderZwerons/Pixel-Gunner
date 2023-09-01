using UnityEngine;

public class stage_select_script : MonoBehaviour
{
	private int chapter;

	public GameObject[] stageob;

	private void Start()
	{
		chapter = 0;
		checkob();
		Time.timeScale = 1f;
	}

	private void checkob()
	{
		for (int i = 0; i < stageob.Length; i++)
		{
			stageob[i].SetActive(false);
		}
		stageob[chapter].SetActive(true);
	}

	private void tomainsc()
	{
		Application.LoadLevel("mode_select");
	}

	private void gamestart(int i)
	{
		PlayerPrefs.SetInt("stage", i);
		Application.LoadLevel("loading");
	}

	private void btn_right()
	{
		if (chapter < stageob.Length - 1)
		{
			chapter++;
			checkob();
		}
	}

	private void btn_left()
	{
		if (0 < chapter)
		{
			chapter--;
			checkob();
		}
	}
}
