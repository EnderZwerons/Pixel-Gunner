using UnityEngine;

public class Btn_ToScene : MonoBehaviour
{
	public string NextScene;

	private void OnClick()
	{
		Time.timeScale = 1f;
		MainGameScript.game_state = 4;
		if (NextScene == "shop")
		{
			PlayerPrefs.SetInt("ShopState", 4);
		}
		Application.LoadLevel(NextScene);
	}
}
