using System;
using System.Collections;
using UnityEngine;

public class GDriver : MonoBehaviour
{
	[Serializable]
	public class EventClass
	{
		public string APP_ID_ = "NULL";

		public string EVENT1 = "NULL";

		public string EVENT2 = "NULL";

		public string EVENT3 = "NULL";

		public string ACTIVE = "TRUE";
	}

	public bool Portrait;

	public string APPID;

	public string URL_GSHEET;

	public string URL_GSHEET_IOS;

	public GameObject AD_OB;

	public GoSheets sheets;

	public UITexture Img_Texture;

	public string NextScene;

	[HideInInspector]
	public string[] APP_ID = new string[5];

	[HideInInspector]
	public string[] URL_IMG_P = new string[5];

	[HideInInspector]
	public string[] URL_IMG_L = new string[5];

	[HideInInspector]
	public string[] URL_STORE = new string[5];

	[HideInInspector]
	public EventClass[] EVENT = new EventClass[100];

	private int randnum;

	private int MoveNumber = 20;

	private void Update()
	{
		if (sheets.ERROR_BOOL)
		{
			AD_OB.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ToX();
		}
	}

	private void Start()
	{
		MoveNumber = 20;
		sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 2, 3, OnCheck);
		StartCoroutine("NextGo", 7f);
	}

	private void SelectAds()
	{
		randnum = UnityEngine.Random.Range(0, 5);
		if (APP_ID[randnum] == APPID && MoveNumber > 0)
		{
			MoveNumber--;
			SelectAds();
		}
		else if (APP_ID[randnum] == APPID && MoveNumber <= 0)
		{
			Debug.Log("ERROR NOT HAVE ADS");
			StartCoroutine("NextGo", 2.5f);
		}
		else if (APP_ID[randnum] != APPID)
		{
			Debug.Log("SHOW ADS");
			if (Portrait)
			{
				StartCoroutine(LoadTexture(URL_IMG_P[randnum]));
			}
			else
			{
				StartCoroutine(LoadTexture(URL_IMG_L[randnum]));
			}
		}
	}

	private void OnCheck(string url = "", int column = 0, int row = 0, string value = "")
	{
		if (column == 2 && row == 3)
		{
			APP_ID[0] = value;
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 2, 4, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 2, 5, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 2, 6, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 2, 7, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 3, 3, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 3, 4, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 3, 5, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 3, 6, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 3, 7, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 4, 3, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 4, 4, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 4, 5, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 4, 6, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 4, 7, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 5, 3, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 5, 4, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 5, 5, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 5, 6, OnCheck);
			sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", 5, 7, OnCheck);
			for (int i = 0; i < 100; i++)
			{
				for (int j = 2; j < 7; j++)
				{
					sheets.GetCell("https://docs.google.com/spreadsheets/u/0/d/" + URL_GSHEET + "/export?format=tsv&id=" + URL_GSHEET + "&gid=0", j, i + 9, OnCheck);
				}
			}
		}
		else if (column == 2 && row == 4)
		{
			APP_ID[1] = value;
		}
		else if (column == 2 && row == 5)
		{
			APP_ID[2] = value;
		}
		else if (column == 2 && row == 6)
		{
			APP_ID[3] = value;
		}
		else if (column == 2 && row == 7)
		{
			APP_ID[4] = value;
		}
		if (column == 3 && row == 3)
		{
			URL_IMG_P[0] = value;
		}
		else if (column == 3 && row == 4)
		{
			URL_IMG_P[1] = value;
		}
		else if (column == 3 && row == 5)
		{
			URL_IMG_P[2] = value;
		}
		else if (column == 3 && row == 6)
		{
			URL_IMG_P[3] = value;
		}
		else if (column == 3 && row == 7)
		{
			URL_IMG_P[4] = value;
		}
		if (column == 4 && row == 3)
		{
			URL_IMG_L[0] = value;
		}
		else if (column == 4 && row == 4)
		{
			URL_IMG_L[1] = value;
		}
		else if (column == 4 && row == 5)
		{
			URL_IMG_L[2] = value;
		}
		else if (column == 4 && row == 6)
		{
			URL_IMG_L[3] = value;
		}
		else if (column == 4 && row == 7)
		{
			URL_IMG_L[4] = value;
		}
		if (column == 5 && row == 3)
		{
			URL_STORE[0] = value;
		}
		else if (column == 5 && row == 4)
		{
			URL_STORE[1] = value;
		}
		else if (column == 5 && row == 5)
		{
			URL_STORE[2] = value;
		}
		else if (column == 5 && row == 6)
		{
			URL_STORE[3] = value;
		}
		else if (column == 5 && row == 7)
		{
			URL_STORE[4] = value;
			SelectAds();
		}
		if (row >= 9)
		{
			switch (column)
			{
			case 2:
				EVENT[row - 9].APP_ID_ = value;
				break;
			case 3:
				EVENT[row - 9].EVENT1 = value;
				break;
			case 4:
				EVENT[row - 9].EVENT2 = value;
				break;
			case 5:
				EVENT[row - 9].EVENT3 = value;
				break;
			case 6:
				EVENT[row - 9].ACTIVE = value;
				break;
			}
			if (column == 6 && row == 108)
			{
				CheckEvent();
			}
		}
	}

	private IEnumerator LoadTexture(string value)
	{
		WWW www = new WWW(value);
		yield return www;
		Img_Texture.mainTexture = www.texture;
		Debug.Log("SHOW ADS_IMG");
	}

	private IEnumerator NextGo(float NextTime)
	{
		yield return new WaitForSeconds(NextTime);
		StartCoroutine("NextSceneGo");
	}

	private IEnumerator NextSceneGo()
	{
		CheckEvent();
		yield return new WaitForSeconds(1f);
		Application.LoadLevel(NextScene);
	}

	private void ToX()
	{
		AD_OB.SetActive(false);
		StartCoroutine("NextSceneGo");
	}

	private void OpenURL_()
	{
		Application.OpenURL(URL_STORE[randnum]);
	}

	private void CheckEvent()
	{
		bool flag = false;
		int num = 0;
		for (int i = 0; i < 100; i++)
		{
			if (EVENT[i].APP_ID_ == APPID)
			{
				num = i;
				flag = true;
			}
		}
		if (flag)
		{
			int num2 = int.Parse(EVENT[num].EVENT1.Substring(1));
			int num3 = int.Parse(EVENT[num].EVENT2.Substring(1));
			int num4 = int.Parse(EVENT[num].EVENT3.Substring(1));
			string aCTIVE = EVENT[num].ACTIVE;
			PlayerPrefs.SetInt("EVENT1", num2);
			PlayerPrefs.SetInt("EVENT2", num3);
			PlayerPrefs.SetInt("EVENT3", num4);
			PlayerPrefs.SetString("NOTICE1", aCTIVE);
			Debug.Log("EVENT 1,2,3 : " + num2 + "/" + num3 + "/" + num4);
			if (EVENT[num].ACTIVE == "FALSE")
			{
				Debug.Log("end game");
				Application.Quit();
			}
		}
		else
		{
			Debug.Log("EVENT ERROR 1,2,3 : 0,0,0");
			PlayerPrefs.SetInt("EVENT1", 0);
			PlayerPrefs.SetInt("EVENT2", 0);
			PlayerPrefs.SetInt("EVENT3", 0);
			PlayerPrefs.SetString("NOTICE1", string.Empty);
			Debug.Log("Internet Error");
		}
	}
}
