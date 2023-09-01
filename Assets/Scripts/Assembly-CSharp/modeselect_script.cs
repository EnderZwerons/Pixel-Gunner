using UnityEngine;

public class modeselect_script : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void tosurvival()
	{
		PlayerPrefs.SetInt("gamemode", 0);
		Application.LoadLevel("Stage_Survival");
	}

	private void tomission()
	{
		PlayerPrefs.SetInt("gamemode", 1);
		Application.LoadLevel("stage_select");
	}

	private void toboss()
	{
		PlayerPrefs.SetInt("gamemode", 2);
		Application.LoadLevel("boss_select");
	}

	private void tomain()
	{
		Application.LoadLevel("main");
	}
}
