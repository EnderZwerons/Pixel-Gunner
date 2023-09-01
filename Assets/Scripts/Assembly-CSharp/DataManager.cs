using System;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
	[Serializable]
	public class GameData
	{
		public int gold;

		public int gem;

		public string playerName;

		public int playerLevel;

		public int[] Weapon_Lv = new int[100];

		public bool[] Weapon_Have = new bool[100];

		public int[] Char_Lv = new int[100];

		public bool[] Char_Have = new bool[100];

		public int[] Upgrade_Lv = new int[50];

		public int[] Material_Have = new int[100];

		public int[] stageClear = new int[500];

		public int[] eventClear = new int[500];

		public int[] InventoryWeapon = new int[3];

		public int ClearStage;
	}

	public string ThisScene;

	private string UserID;

	public GameData gameData = new GameData();

	public bool TestMode;

	private void Awake()
	{
		PlayerPrefsPro2.Init("PIXELSTARG");
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	private void Start()
	{
		if (PlayerPrefsPro2.HasKey("gameData"))
		{
			Debug.Log("Data Load : 기존데이터");
			gameData = PlayerPrefsPro2.GetClass<GameData>("gameData");
		}
		else if (Application.loadedLevelName == ThisScene)
		{
			Debug.Log("FIRST DATA");
			gameData.playerName = CheckID();
			CheckLanguage();
			gameData.gold = 0;
			gameData.gem = 0;
			gameData.InventoryWeapon[0] = 0;
			gameData.InventoryWeapon[1] = 1;
			gameData.InventoryWeapon[2] = 2;
			SaveData();
			FirstRun_Script.instance.GETOLDDATA();
			Debug.Log("NotFound : gameData Key");
			Debug.Log("Data Create : 데이터 생성");
		}
	}

	private void CheckLanguage()
	{
		int num = 0;
		switch (Application.systemLanguage.ToString())
		{
		case "English":
			num = 0;
			break;
		case "Korean":
			num = 1;
			break;
		case "Japanese":
			num = 2;
			break;
		case "Chinese":
			num = 3;
			break;
		case "Thai":
			num = 4;
			break;
		case "Indonesian":
			num = 5;
			break;
		case "Russian":
			num = 6;
			break;
		case "Vietnamese":
			num = 7;
			break;
		default:
			num = 8;
			break;
		}
		PlayerPrefs.SetInt("Language", num);
		Debug.Log(Application.systemLanguage);
	}

	private string CheckID()
	{
		if (PlayerPrefs.GetString("USERID") == string.Empty)
		{
			int num = UnityEngine.Random.Range(0, 1000000);
			UserID = num + "Player";
			PlayerPrefs.SetString("USERID", UserID);
		}
		else
		{
			UserID = PlayerPrefs.GetString("USERID");
		}
		return UserID;
	}

	public void SaveData()
	{
		PlayerPrefsPro2.SetClass("gameData", gameData);
	}

	public void LoadData()
	{
		if (PlayerPrefsPro2.HasKey("gameData"))
		{
			gameData = PlayerPrefsPro2.GetClass<GameData>("gameData");
		}
		else
		{
			Debug.Log("NotFound : gameData Key");
		}
	}

	private void OnGUI()
	{
		if (!TestMode)
		{
			return;
		}
		if (GUI.Button(new Rect(100f, 10f, 100f, 100f), "SaveData"))
		{
			PlayerPrefsPro2.SetClass("gameData", gameData);
		}
		if (GUI.Button(new Rect(210f, 10f, 100f, 100f), "LoadData"))
		{
			if (PlayerPrefsPro2.HasKey("gameData"))
			{
				gameData = PlayerPrefsPro2.GetClass<GameData>("gameData");
			}
			else
			{
				Debug.Log("NotFound : gameData Key");
			}
		}
		if (GUI.Button(new Rect(110f, 210f, 100f, 100f), "Delete"))
		{
			PlayerPrefsPro2.DeleteAll();
		}
	}
}
