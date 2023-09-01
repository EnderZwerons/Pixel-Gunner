using Prime31;
using UnityEngine;

public class Main_Script : MonoBehaviour
{
	public GameObject[] gunob;

	private bool exitbool;

	public GameObject UI_NORMAL;

	public GameObject UI_EXIT;

	public GameObject UI_OPTION;

	public GameObject UI_GPC;

	private int Main_State;

	public UISprite Sprite_Sound;

	public string URL_Naver;

	private void Start()
	{
		Time.timeScale = 1f;
		Main_State = 0;
		SetGunob();
		PlayerPrefs.SetInt("bgm", 0);
		exitbool = false;
		Check_Sound();
	}

	private void SetGunob()
	{
		for (int i = 0; i < gunob.Length; i++)
		{
			gunob[i].SetActive(false);
		}
		int num = Singleton<DataManager>.Instance.gameData.InventoryWeapon[1];
		gunob[num].SetActive(true);
	}

	private void OnGUI()
	{
	}

	private void SetUI()
	{
		switch (Main_State)
		{
		case 0:
			UI_NORMAL.SetActive(true);
			UI_EXIT.SetActive(false);
			UI_OPTION.SetActive(false);
			UI_GPC.SetActive(false);
			break;
		case 1:
			UI_NORMAL.SetActive(false);
			UI_EXIT.SetActive(true);
			UI_OPTION.SetActive(false);
			UI_GPC.SetActive(false);
			break;
		case 2:
			UI_NORMAL.SetActive(false);
			UI_EXIT.SetActive(false);
			UI_OPTION.SetActive(true);
			UI_GPC.SetActive(false);
			break;
		case 3:
			UI_NORMAL.SetActive(false);
			UI_EXIT.SetActive(false);
			UI_OPTION.SetActive(false);
			UI_GPC.SetActive(true);
			break;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			switch (Main_State)
			{
			case 0:
				if (PlayerPrefs.GetInt("ad") == 0)
				{
					AdMobAndroid.hideBanner(false);
				}
				Main_State = 1;
				break;
			case 1:
				Main_State = 0;
				AdMobAndroid.hideBanner(true);
				break;
			case 2:
				Main_State = 0;
				AdMobAndroid.hideBanner(true);
				break;
			case 3:
				Main_State = 0;
				AdMobAndroid.hideBanner(true);
				break;
			}
		}
		SetUI();
	}

	private void Game_Start()
	{
		PlayerPrefs.SetInt("mode", 0);
		Application.LoadLevel("game_survival");
	}

	private void weapon_scene()
	{
		Application.LoadLevel("weapon");
	}

	private void char_scene()
	{
		Application.LoadLevel("char");
	}

	private void tomissionmode()
	{
		PlayerPrefs.SetInt("gamemode", 1);
		Application.LoadLevel("stage_select");
	}

	private void tosurvivalmode()
	{
		Application.LoadLevel("Stage_Survival");
	}

	private void toupgrade()
	{
		Application.LoadLevel("upgrade");
	}

	private void exityes()
	{
		Application.Quit();
	}

	private void tooption()
	{
		Main_State = 2;
	}

	private void togpc()
	{
		Main_State = 3;
	}

	private void exitno()
	{
		Main_State = 0;
		AdMobAndroid.hideBanner(true);
	}

	private void togameplay()
	{
		Application.LoadLevel("mode_select");
	}

	private void tofacebook()
	{
		Application.OpenURL("https://www.facebook.com/pages/PixelStar/484703091659206");
	}

	private void tocomu()
	{
		if (PlayerPrefs.GetInt("Language") == 1)
		{
			Application.OpenURL(URL_Naver);
		}
		else
		{
			Application.OpenURL("https://game.nanoo.so/PixelGunner");
		}
	}

	private void tosound()
	{
		if (PlayerPrefs.GetInt("bgm_on") == 0)
		{
			PlayerPrefs.SetInt("bgm_on", 1);
		}
		else
		{
			PlayerPrefs.SetInt("bgm_on", 0);
		}
		Check_Sound();
	}

	private void Check_Sound()
	{
		if (PlayerPrefs.GetInt("bgm_on") == 0)
		{
			Sprite_Sound.spriteName = "audio_button_on";
		}
		else
		{
			Sprite_Sound.spriteName = "audio_button_off";
		}
	}

	private void toshop_free()
	{
		PlayerPrefs.SetInt("ShopState", 0);
		Application.LoadLevel("shop");
	}

	private void tomore()
	{
		Application.OpenURL("https://play.google.com/store/apps/developer?id=PixelStar");
	}

	private void tolanguagechange(int langunum)
	{
		PlayerPrefs.SetInt("Language", langunum);
		Application.LoadLevel("main");
	}
}
