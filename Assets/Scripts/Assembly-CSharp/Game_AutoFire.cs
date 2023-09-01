using UnityEngine;

public class Game_AutoFire : MonoBehaviour
{
	public static Game_AutoFire instance;

	public Animation aimani;

	public UISprite auto_sprite;

	private void Start()
	{
		instance = this;
		SetAutoFire();
	}

	private void Update()
	{
	}

	private void SetAutoFire()
	{
		if (PlayerPrefs.GetInt("autofire") == 0)
		{
			auto_sprite.color = Color.white;
		}
		else if (PlayerPrefs.GetInt("autofire") == 1)
		{
			auto_sprite.color = Color.green;
		}
	}

	private void AutoNext()
	{
		if (PlayerPrefs.GetInt("autofire") == 0)
		{
			PlayerPrefs.SetInt("autofire", 1);
			SetAutoFire();
		}
		else if (PlayerPrefs.GetInt("autofire") == 1)
		{
			PlayerPrefs.SetInt("autofire", 0);
			SetAutoFire();
		}
	}
}
