using UnityEngine;

public class loading_sur : MonoBehaviour
{
	private float streamtime;

	public int Time_Next;

	public string NextScene;

	private void Start()
	{
		Time.timeScale = 1f;
		streamtime = 0f;
	}

	private void Update()
	{
		streamtime += Time.deltaTime;
		if (streamtime >= (float)Time_Next)
		{
			switch (PlayerPrefs.GetInt("survival_stage"))
			{
			case 0:
				Application.LoadLevel("game_survival");
				break;
			case 1:
				Application.LoadLevel("game_survival");
				break;
			case 2:
				Application.LoadLevel("survival_2");
				break;
			case 3:
				Application.LoadLevel("survival_3");
				break;
			case 4:
				Application.LoadLevel("survival_4");
				break;
			case 5:
				Application.LoadLevel("survival_5");
				break;
			case 6:
				Application.LoadLevel("survival_6");
				break;
			case 7:
				Application.LoadLevel("survival_7");
				break;
			case 8:
				Application.LoadLevel("survival_8");
				break;
			case 9:
				Application.LoadLevel("survival_9");
				break;
			case 10:
				Application.LoadLevel("survival_10");
				break;
			case 11:
				Application.LoadLevel("survival_11");
				break;
			case 12:
				Application.LoadLevel("survival_12");
				break;
			case 13:
				Application.LoadLevel("survival_13");
				break;
			case 14:
				Application.LoadLevel("survival_14");
				break;
			case 15:
				Application.LoadLevel("survival_15");
				break;
			case 16:
				Application.LoadLevel("survival_16");
				break;
			case 17:
				Application.LoadLevel("survival_17");
				break;
			case 18:
				Application.LoadLevel("survival_18");
				break;
			case 19:
				Application.LoadLevel("survival_19");
				break;
			case 20:
				Application.LoadLevel("survival_20");
				break;
			case 21:
				Application.LoadLevel("survival_21");
				break;
			case 22:
				Application.LoadLevel("survival_22");
				break;
			case 23:
				Application.LoadLevel("survival_23");
				break;
			}
		}
	}
}
