using System.Collections;
using Prime31;
using UnityEngine;

public class MainGameScript : MonoBehaviour
{
	public static int game_state;

	public static int game_state_2;

	public static int gold;

	public static int bomb_num;

	public static int gunnumber_;

	public static float sensity;

	public static int killedmon;

	public static int missionmon;

	public static int NOWGUNNUM;

	private int bomb_max;

	public GameObject[] gunob;

	public UILabel goldtext;

	public UILabel bombtext;

	public UILabel killedmon_text;

	public UILabel missionmon_text;

	public GameObject[] UI_GUNSELECTGREEN;

	public GameObject UI_GAME;

	public GameObject UI_PAUSE;

	public GameObject UI_GAMEOVER;

	public GameObject UI_GAMECLEAR;

	private bool gameovertrue;

	public AudioClip sfx_gameover;

	public AudioClip sfx_gameclear;

	public int maxstage;

	private string MissionMode_Gpc;

	private string[] SurvivalMode_Gpc;

	public UIScrollBar sensity_scroll;

	public Animation ArmAni;

	private int ModeInt;

	private void Awake()
	{
		NOWGUNNUM = 0;
		SurvivalMode_Gpc = new string[50];
		MissionMode_Gpc = "CgkIt83xmpAeEAIQFA";
		SurvivalMode_Gpc[0] = "CgkIt83xmpAeEAIQBg";
		SurvivalMode_Gpc[1] = "CgkIt83xmpAeEAIQBg";
		SurvivalMode_Gpc[2] = "CgkIt83xmpAeEAIQBw";
		SurvivalMode_Gpc[3] = "CgkIt83xmpAeEAIQCA";
		SurvivalMode_Gpc[4] = "CgkIt83xmpAeEAIQCQ";
		SurvivalMode_Gpc[5] = "CgkIt83xmpAeEAIQCg";
		SurvivalMode_Gpc[6] = "CgkIt83xmpAeEAIQCw";
		SurvivalMode_Gpc[7] = "CgkIt83xmpAeEAIQDA";
		SurvivalMode_Gpc[8] = "CgkIt83xmpAeEAIQDQ";
		SurvivalMode_Gpc[9] = "CgkIt83xmpAeEAIQDg";
		SurvivalMode_Gpc[10] = "CgkIt83xmpAeEAIQDw";
		SurvivalMode_Gpc[11] = "CgkIt83xmpAeEAIQEA";
		SurvivalMode_Gpc[12] = "CgkIt83xmpAeEAIQEQ";
		SurvivalMode_Gpc[13] = "CgkIt83xmpAeEAIQEg";
		SurvivalMode_Gpc[14] = "CgkIt83xmpAeEAIQEw";
		SurvivalMode_Gpc[15] = "CgkIt83xmpAeEAIQFQ";
		SurvivalMode_Gpc[16] = "CgkIt83xmpAeEAIQFg";
		SurvivalMode_Gpc[17] = "CgkIt83xmpAeEAIQFw";
		SurvivalMode_Gpc[18] = "CgkIt83xmpAeEAIQGA";
		SurvivalMode_Gpc[19] = "CgkIt83xmpAeEAIQGQ";
		SurvivalMode_Gpc[20] = "CgkIt83xmpAeEAIQGg";
		SurvivalMode_Gpc[21] = "CgkIt83xmpAeEAIQGw";
		SurvivalMode_Gpc[22] = "CgkIt83xmpAeEAIQJg";
		SurvivalMode_Gpc[23] = "CgkIt83xmpAeEAIQJw";
		AdMobAndroid.hideBanner(true);
		game_state = 0;
		game_state_2 = 0;
		gold = 0;
		ModeInt = PlayerPrefs.GetInt("gamemode");
		if (PlayerPrefs.GetInt("gamemode") == 1)
		{
			bomb_num = 2 + Singleton<DataManager>.Instance.gameData.Upgrade_Lv[1];
		}
		if (PlayerPrefs.GetInt("gamemode") == 0)
		{
			bomb_num = 5 + Singleton<DataManager>.Instance.gameData.Upgrade_Lv[1];
			string text = "SURVIVAL" + PlayerPrefs.GetInt("survival_stage");
		}
		if (PlayerPrefs.GetInt("gamemode") == 2)
		{
			bomb_num = 2 + Singleton<DataManager>.Instance.gameData.Upgrade_Lv[1];
		}
		bomb_max = bomb_num;
		SetGunob(0);
	}

	private void Start()
	{
		PlayerPrefs.SetInt("bgm", 1);
		gameovertrue = false;
		sensity = PlayerPrefs.GetFloat("sensity");
		sensity_scroll.value = (PlayerPrefs.GetFloat("sensity") - 1f) / 7f;
		killedmon = 0;
		GetDataWeapon();
		ChanageGun(0);
	}

	private void GetDataWeapon()
	{
		int num = Singleton<DataManager>.Instance.gameData.InventoryWeapon[0];
		int num2 = Singleton<DataManager>.Instance.gameData.InventoryWeapon[1];
		int num3 = Singleton<DataManager>.Instance.gameData.InventoryWeapon[2];
		int gunLv = Singleton<DataManager>.Instance.gameData.Weapon_Lv[num];
		int gunLv2 = Singleton<DataManager>.Instance.gameData.Weapon_Lv[num2];
		int gunLv3 = Singleton<DataManager>.Instance.gameData.Weapon_Lv[num3];
		float[] array = DataBaseScript.instance.DataGetWeapon(num, gunLv);
		float[] array2 = DataBaseScript.instance.DataGetWeapon(num2, gunLv2);
		float[] array3 = DataBaseScript.instance.DataGetWeapon(num3, gunLv3);
		MSPFps.instance.WeaponList[0].WeaponPower = (int)array[0];
		MSPFps.instance.WeaponList[0].fireRate = array[2];
		MSPFps.instance.WeaponList[0].bulletperClip = (int)array[3];
		MSPFps.instance.WeaponList[0].NbClip = MSPFps.instance.WeaponList[0].MaxNbrClip;
		MSPFps.instance.WeaponList[0].bulletinMagasine = (int)array[3];
		MSPFps.instance.WeaponList[1].WeaponPower = (int)array2[0];
		MSPFps.instance.WeaponList[1].fireRate = array2[2];
		MSPFps.instance.WeaponList[1].bulletperClip = (int)array2[3];
		MSPFps.instance.WeaponList[1].NbClip = MSPFps.instance.WeaponList[1].MaxNbrClip;
		MSPFps.instance.WeaponList[1].bulletinMagasine = (int)array2[3];
		MSPFps.instance.WeaponList[2].WeaponPower = (int)array3[0];
		MSPFps.instance.WeaponList[2].fireRate = array3[2];
		MSPFps.instance.WeaponList[2].bulletperClip = (int)array3[3];
		MSPFps.instance.WeaponList[2].NbClip = MSPFps.instance.WeaponList[2].MaxNbrClip;
		MSPFps.instance.WeaponList[2].bulletinMagasine = (int)array3[3];
	}

	private void SetGunob(int GunNumber_int)
	{
		for (int i = 0; i < gunob.Length; i++)
		{
			gunob[i].SetActive(false);
		}
		gunob[GunNumber_int].SetActive(true);
		NOWGUNNUM = GunNumber_int;
	}

	private void ChanageGun(int Gunnumber)
	{
		if (Gunnumber != gunnumber_)
		{
			gunnumber_ = Gunnumber;
			MSPFps.instance.ChangeCurrentWeapon(Gunnumber);
			ArmAni.Play("Arm_ChanageGun", PlayMode.StopAll);
			StartCoroutine("ChanageGun_Cor", Singleton<DataManager>.Instance.gameData.InventoryWeapon[Gunnumber]);
			for (int i = 0; i < 3; i++)
			{
				UI_GUNSELECTGREEN[i].SetActive(false);
			}
			UI_GUNSELECTGREEN[Gunnumber].SetActive(true);
		}
	}

	private IEnumerator ChanageGun_Cor(int getgunnum)
	{
		yield return new WaitForSeconds(0.4f);
		SetGunob(getgunnum);
	}

	private void CheckClear()
	{
		int @int = PlayerPrefs.GetInt("stage");
		if (PlayGameServices.isSignedIn())
		{
			switch (@int)
			{
			case 1:
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQAQ");
				break;
			case 10:
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQAg");
				break;
			case 20:
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQAw");
				break;
			case 30:
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQBA");
				break;
			case 40:
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQBQ");
				break;
			case 50:
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQJQ");
				break;
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			topause();
		}
		goldtext.text = string.Empty + gold;
		bombtext.text = string.Empty + bomb_num + string.Empty;
		if (ModeInt == 1)
		{
			killedmon_text.text = string.Empty + killedmon + "/" + missionmon;
		}
		else
		{
			killedmon_text.text = string.Empty + killedmon;
		}
		if (PCControls.OnPC)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				ChanageGun(0);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				ChanageGun(1);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				ChanageGun(2);
			}
		}
		switch (game_state)
		{
		case 0:
			break;
		case 1:
			AdMobAndroid.hideBanner(false);
			break;
		case 2:
			break;
		case 3:
			break;
		case 8:
			AdMobAndroid.hideBanner(false);
			if (!gameovertrue)
			{
				CheckClear();
				PlayerPrefs.SetInt("kill_monster", PlayerPrefs.GetInt("kill_monster") + killedmon);
				if (gold < 2000)
				{
					Singleton<DataManager>.Instance.gameData.gold += gold;
				}
				GetComponent<AudioSource>().PlayOneShot(sfx_gameclear);
				if (PlayGameServices.isSignedIn())
				{
					PlayGameServices.submitScore(MissionMode_Gpc, PlayerPrefs.GetInt("stage"), string.Empty);
				}
				Singleton<DataManager>.Instance.SaveData();
				gameovertrue = true;
			}
			UI_GAME.SetActive(false);
			UI_GAMECLEAR.SetActive(true);
			break;
		case 9:
			AdMobAndroid.hideBanner(false);
			if (!gameovertrue)
			{
				PlayerPrefs.SetInt("kill_monster", PlayerPrefs.GetInt("kill_monster") + killedmon);
				GameObject.Find("Cam").GetComponent<Animator>().SetBool("DEATH", true);
				if (gold < 5000)
				{
					Singleton<DataManager>.Instance.gameData.gold += gold;
				}
				if (PlayerPrefs.GetInt("gamemode") == 0)
				{
					if (killedmon >= PlayerPrefs.GetInt("score_max"))
					{
						PlayerPrefs.SetInt("score_max", killedmon);
					}
					if (PlayGameServices.isSignedIn())
					{
						PlayGameServices.submitScore(SurvivalMode_Gpc[PlayerPrefs.GetInt("survival_stage")], killedmon, string.Empty);
					}
				}
				GetComponent<AudioSource>().PlayOneShot(sfx_gameover);
				Singleton<DataManager>.Instance.SaveData();
				gameovertrue = true;
			}
			UI_GAME.SetActive(false);
			UI_GAMEOVER.SetActive(true);
			break;
		case 4:
		case 5:
		case 6:
		case 7:
			break;
		}
	}

	private void tomain()
	{
		game_state = 4;
		Time.timeScale = 1f;
		FULLAD_Manager.instance.ShowAds();
		Application.LoadLevel("loading_tomain");
	}

	private void toresume()
	{
		UI_GAME.SetActive(true);
		UI_PAUSE.SetActive(false);
		Time.timeScale = 1f;
		AdMobAndroid.hideBanner(true);
		game_state = 0;
		sensity = sensity_scroll.value * 7f + 1f;
		PlayerPrefs.SetFloat("sensity", sensity);
	}

	private void topause()
	{
		if (game_state == 0)
		{
			UI_GAME.SetActive(false);
			UI_PAUSE.SetActive(true);
			game_state = 1;
			Time.timeScale = 0f;
		}
		else if (game_state == 1)
		{
			UI_GAME.SetActive(true);
			UI_PAUSE.SetActive(false);
			game_state = 0;
			Time.timeScale = 1f;
			AdMobAndroid.hideBanner(true);
		}
	}

	private void torestart()
	{
		game_state = 4;
		Time.timeScale = 1f;
		FULLAD_Manager.instance.ShowAds();
		if (PlayerPrefs.GetInt("gamemode") == 1)
		{
			Application.LoadLevel("loading");
		}
		if (PlayerPrefs.GetInt("gamemode") == 0)
		{
			Application.LoadLevel("loading_tosurvival");
		}
		if (PlayerPrefs.GetInt("gamemode") == 2)
		{
			Application.LoadLevel("loading_toboss");
		}
	}

	private void tonext()
	{
		game_state = 4;
		Time.timeScale = 1f;
		FULLAD_Manager.instance.ShowAds();
		if (PlayerPrefs.GetInt("stage") + 1 < maxstage)
		{
			PlayerPrefs.SetInt("stage", PlayerPrefs.GetInt("stage") + 1);
			Application.LoadLevel("loading");
		}
		else
		{
			Application.LoadLevel("loading_tomain");
		}
	}
}
