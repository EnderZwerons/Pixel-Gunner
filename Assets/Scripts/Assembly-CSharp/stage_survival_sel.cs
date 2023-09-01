using UnityEngine;

public class stage_survival_sel : MonoBehaviour
{
	public GameObject[] stage;

	public UILabel Label_StageNum;

	private int stage_num;

	private int stage_max_num;

	public AudioClip click;

	public AudioClip click_error;

	private void Start()
	{
		stage_num = 0;
		stage_max_num = stage.Length;
		SetUI();
	}

	private void Update()
	{
	}

	private void gamestart(int i)
	{
		PlayerPrefs.SetInt("gamemode", 0);
		PlayerPrefs.SetInt("survival_stage", i);
		Application.LoadLevel("loading_tosurvival");
	}

	private void tomain()
	{
		Application.LoadLevel("mode_select");
	}

	private void toright()
	{
		if (stage_num < stage.Length - 1)
		{
			stage_num++;
			SetUI();
			GetComponent<AudioSource>().PlayOneShot(click);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(click_error);
		}
	}

	private void toleft()
	{
		if (stage_num > 0)
		{
			stage_num--;
			SetUI();
			GetComponent<AudioSource>().PlayOneShot(click);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(click_error);
		}
	}

	private void SetUI()
	{
		Label_StageNum.text = "(" + (stage_num + 1) + "/" + stage_max_num + ")";
		for (int i = 0; i < stage.Length; i++)
		{
			stage[i].SetActive(false);
		}
		stage[stage_num].SetActive(true);
	}
}
