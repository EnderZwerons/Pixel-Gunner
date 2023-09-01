using System.Collections;
using UnityEngine;

public class Stage_Manager : MonoBehaviour
{
	public GameObject[] stage_monob;

	public GameObject[] start_pos;

	public GameObject playerob;

	private bool stageclear;

	private void MapLoad(string Mapname)
	{
		Object.Instantiate(Resources.Load("Mission_Map/" + Mapname, typeof(GameObject)) as GameObject);
	}

	private void Start()
	{
		stageclear = false;
		Object.Instantiate(stage_monob[PlayerPrefs.GetInt("stage")]);
		switch (PlayerPrefs.GetInt("stage"))
		{
		case 1:
			MainGameScript.missionmon = 5;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 2:
			MainGameScript.missionmon = 7;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 3:
			MainGameScript.missionmon = 9;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 4:
			MainGameScript.missionmon = 10;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 5:
			MainGameScript.missionmon = 10;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 6:
			MainGameScript.missionmon = 10;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 7:
			MainGameScript.missionmon = 12;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 8:
			MainGameScript.missionmon = 12;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 9:
			MainGameScript.missionmon = 14;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 10:
			MainGameScript.missionmon = 15;
			MapLoad("M001");
			playerob.transform.position = start_pos[0].transform.position;
			playerob.transform.rotation = start_pos[0].transform.rotation;
			break;
		case 11:
			MainGameScript.missionmon = 10;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 12:
			MainGameScript.missionmon = 10;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 13:
			MainGameScript.missionmon = 10;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 14:
			MainGameScript.missionmon = 12;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 15:
			MainGameScript.missionmon = 13;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 16:
			MainGameScript.missionmon = 15;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 17:
			MainGameScript.missionmon = 15;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 18:
			MainGameScript.missionmon = 15;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 19:
			MainGameScript.missionmon = 15;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 20:
			MainGameScript.missionmon = 15;
			MapLoad("M002");
			playerob.transform.position = start_pos[1].transform.position;
			playerob.transform.rotation = start_pos[1].transform.rotation;
			break;
		case 21:
			MainGameScript.missionmon = 12;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 22:
			MainGameScript.missionmon = 12;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 23:
			MainGameScript.missionmon = 13;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 24:
			MainGameScript.missionmon = 14;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 25:
			MainGameScript.missionmon = 15;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 26:
			MainGameScript.missionmon = 15;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 27:
			MainGameScript.missionmon = 15;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 28:
			MainGameScript.missionmon = 15;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 29:
			MainGameScript.missionmon = 15;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 30:
			MainGameScript.missionmon = 16;
			MapLoad("M003");
			playerob.transform.position = start_pos[2].transform.position;
			playerob.transform.rotation = start_pos[2].transform.rotation;
			break;
		case 31:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 32:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 33:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 34:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 35:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 36:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 37:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 38:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 39:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 40:
			MainGameScript.missionmon = 15;
			MapLoad("M004");
			playerob.transform.position = start_pos[3].transform.position;
			playerob.transform.rotation = start_pos[3].transform.rotation;
			break;
		case 41:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 15;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 42:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 15;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 43:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 15;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 44:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 15;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 45:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 15;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 46:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 3;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 47:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 6;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 48:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 10;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 49:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 15;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		case 50:
			RenderSettings.fogColor = Color.black;
			MainGameScript.missionmon = 15;
			MapLoad("M005");
			playerob.transform.position = start_pos[4].transform.position;
			playerob.transform.rotation = start_pos[4].transform.rotation;
			break;
		}
	}

	private void Update()
	{
		if (!stageclear && MainGameScript.killedmon >= MainGameScript.missionmon)
		{
			if (PlayerPrefs.GetInt("clear_stage") <= PlayerPrefs.GetInt("stage"))
			{
				PlayerPrefs.SetInt("clear_stage", PlayerPrefs.GetInt("stage"));
				Singleton<DataManager>.Instance.gameData.ClearStage = PlayerPrefs.GetInt("clear_stage");
				Singleton<DataManager>.Instance.SaveData();
			}
			StartCoroutine("GameClear");
			stageclear = true;
		}
	}

	private IEnumerator GameClear()
	{
		yield return new WaitForSeconds(5f);
		MainGameScript.game_state = 8;
	}
}
