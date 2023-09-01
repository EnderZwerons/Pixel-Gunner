using UnityEngine;

public class Boss_Select : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void gamestart(int i)
	{
		PlayerPrefs.SetInt("gamemode", 2);
		PlayerPrefs.SetInt("boss_stage", i);
		Application.LoadLevel("loading_toboss");
	}

	private void tomain()
	{
		Application.LoadLevel("mode_select");
	}
}
