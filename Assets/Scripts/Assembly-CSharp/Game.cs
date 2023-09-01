using UnityEngine;

public class Game : MonoBehaviour
{
	public UILabel ammo2;

	public UILabel killed_mon2;

	public UILabel gold2;

	public UILabel killed_mon_overform;

	public GameObject PasueForm;

	public GameObject OtherForm;

	public GameObject GameOverForm;

	public GameObject GameClearForm;

	public GameObject[] gunob;

	public GameObject[] playerob;

	public Material[] charmat;

	public GameObject redback;

	private bool gameover;

	private bool gameclear;

	public AudioClip sfx_gameover;

	public AudioClip sfx_gameclear;

	public static int damage;

	public static float zoom;

	public static int ammo;

	public static int killed_mon;

	public static int gold;

	public static int game_state;

	public static float cooldowntime;

	public UISprite[] sensity_sprite;

	public GameObject senob;

	private void Awake()
	{
		gold = 0;
		killed_mon = 0;
		game_state = 0;
		gameclear = false;
		gameover = false;
		Time.timeScale = 1f;
		damage = PlayerPrefs.GetInt("damage");
		ammo = PlayerPrefs.GetInt("ammo");
		zoom = PlayerPrefs.GetInt("range");
		cooldowntime = PlayerPrefs.GetFloat("at_speed");
		gunob[PlayerPrefs.GetInt("gunnum")].SetActive(true);
	}

	private void Start()
	{
		switch (PlayerPrefs.GetInt("sensity"))
		{
		case 0:
			sensity(2);
			break;
		case 1:
			sensity(1);
			break;
		case 2:
			sensity(3);
			break;
		case 3:
			sensity(4);
			break;
		case 4:
			sensity(5);
			break;
		}
		for (int i = 0; i < 2; i++)
		{
			playerob[i].GetComponent<Renderer>().material = charmat[PlayerPrefs.GetInt("char")];
		}
	}

	private void Update()
	{
		ammo2.text = ammo + string.Empty;
		killed_mon2.text = killed_mon + string.Empty;
		gold2.text = gold + string.Empty;
		killed_mon_overform.text = killed_mon + string.Empty;
		switch (game_state)
		{
		case 0:
			OtherForm.SetActive(true);
			PasueForm.SetActive(false);
			GameOverForm.SetActive(false);
			break;
		case 1:
			OtherForm.SetActive(false);
			PasueForm.SetActive(true);
			GameOverForm.SetActive(false);
			Time.timeScale = 0f;
			break;
		case 8:
			if (!gameclear)
			{
				GetComponent<AudioSource>().PlayOneShot(sfx_gameclear);
				if (PlayerPrefs.GetInt("clear_stage") < PlayerPrefs.GetInt("stage"))
				{
					PlayerPrefs.SetInt("clear_stage", PlayerPrefs.GetInt("stage"));
				}
				gameclear = true;
			}
			OtherForm.SetActive(false);
			PasueForm.SetActive(false);
			GameClearForm.SetActive(true);
			Time.timeScale = 0f;
			break;
		case 9:
			if (!gameover)
			{
				GetComponent<AudioSource>().PlayOneShot(sfx_gameover);
				gameover = true;
			}
			OtherForm.SetActive(false);
			PasueForm.SetActive(false);
			GameOverForm.SetActive(true);
			redback.SetActive(true);
			Time.timeScale = 0f;
			break;
		}
	}

	private void main_scene()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + gold);
		PlayerPrefs.SetInt("killed_monster", PlayerPrefs.GetInt("killed_monster") + killed_mon);
		if (PlayerPrefs.GetInt("max_score") < killed_mon)
		{
			PlayerPrefs.SetInt("max_score", killed_mon);
		}
		Application.LoadLevel("main");
	}

	private void restart_scene()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + gold);
		PlayerPrefs.SetInt("killed_monster", PlayerPrefs.GetInt("killed_monster") + killed_mon);
		if (PlayerPrefs.GetInt("max_score") < killed_mon)
		{
			PlayerPrefs.SetInt("max_score", killed_mon);
		}
		if (PlayerPrefs.GetInt("mode") == 0)
		{
			Application.LoadLevel("game_survival");
		}
		else if (PlayerPrefs.GetInt("mode") == 1)
		{
			Application.LoadLevel("game_hunting");
		}
	}

	private void resume()
	{
		game_state = 0;
		Time.timeScale = 1f;
	}

	private void pause()
	{
		if (game_state == 0)
		{
			game_state = 1;
		}
	}

	private void restart_hunting()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + gold);
		PlayerPrefs.SetInt("killed_monster", PlayerPrefs.GetInt("killed_monster") + killed_mon);
		Application.LoadLevel("loading");
	}

	private void main_hunting()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + gold);
		PlayerPrefs.SetInt("killed_monster", PlayerPrefs.GetInt("killed_monster") + killed_mon);
		Application.LoadLevel("main");
	}

	private void next_hunting()
	{
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + gold);
		PlayerPrefs.SetInt("killed_monster", PlayerPrefs.GetInt("killed_monster") + killed_mon);
		int value = PlayerPrefs.GetInt("stage") + 1;
		PlayerPrefs.SetInt("stage", value);
		Application.LoadLevel("loading");
	}

	private void sensity(int i)
	{
		switch (i)
		{
		case 1:
			PlayerPrefs.SetInt("sensity", 1);
			sensity_sprite[0].spriteName = "R2";
			sensity_sprite[1].spriteName = "R1";
			sensity_sprite[2].spriteName = "R1";
			sensity_sprite[3].spriteName = "R1";
			sensity_sprite[4].spriteName = "R1";
			senob.SendMessage("receivesensity", 2);
			break;
		case 2:
			PlayerPrefs.SetInt("sensity", 0);
			sensity_sprite[0].spriteName = "R1";
			sensity_sprite[1].spriteName = "R2";
			sensity_sprite[2].spriteName = "R1";
			sensity_sprite[3].spriteName = "R1";
			sensity_sprite[4].spriteName = "R1";
			senob.SendMessage("receivesensity", 3);
			break;
		case 3:
			PlayerPrefs.SetInt("sensity", 2);
			sensity_sprite[0].spriteName = "R1";
			sensity_sprite[1].spriteName = "R1";
			sensity_sprite[2].spriteName = "R2";
			sensity_sprite[3].spriteName = "R1";
			sensity_sprite[4].spriteName = "R1";
			senob.SendMessage("receivesensity", 5);
			break;
		case 4:
			PlayerPrefs.SetInt("sensity", 3);
			sensity_sprite[0].spriteName = "R1";
			sensity_sprite[1].spriteName = "R1";
			sensity_sprite[2].spriteName = "R1";
			sensity_sprite[3].spriteName = "R2";
			sensity_sprite[4].spriteName = "R1";
			senob.SendMessage("receivesensity", 8);
			break;
		case 5:
			PlayerPrefs.SetInt("sensity", 4);
			sensity_sprite[0].spriteName = "R1";
			sensity_sprite[1].spriteName = "R1";
			sensity_sprite[2].spriteName = "R1";
			sensity_sprite[3].spriteName = "R1";
			sensity_sprite[4].spriteName = "R2";
			senob.SendMessage("receivesensity", 13);
			break;
		}
	}
}
