using UnityEngine;

public class char_Script : MonoBehaviour
{
	public AudioClip sfx_buy;

	public AudioClip sfx_error;

	public Material[] playerskin;

	public GameObject[] playerob;

	public UILabel needgold;

	private int playernum;

	public GameObject lockob;

	public GameObject buyob;

	private bool[] charhave = new bool[100];

	private int Int_Price;

	private void Start()
	{
		Int_Price = 0;
		playernum = PlayerPrefs.GetInt("char");
		skinchange();
		charhave = Singleton<DataManager>.Instance.gameData.Char_Have;
	}

	private void Update()
	{
		SetUI();
	}

	private void SetUI()
	{
		Int_Price = DataBaseScript.instance.DataGetSkinPrice(playernum);
		needgold.text = Int_Price + string.Empty;
		if (!charhave[playernum])
		{
			lockob.SetActive(true);
			buyob.SetActive(true);
		}
		else
		{
			lockob.SetActive(false);
			buyob.SetActive(false);
		}
	}

	private void skinchange()
	{
		for (int i = 0; i < 6; i++)
		{
			playerob[i].GetComponent<Renderer>().material = playerskin[playernum];
		}
	}

	private void rightbtn()
	{
		if (playernum < playerskin.Length - 1)
		{
			playernum++;
			skinchange();
		}
	}

	private void leftbtn()
	{
		if (playernum > 0)
		{
			playernum--;
			skinchange();
		}
	}

	private void tomainbtn()
	{
		if (charhave[playernum])
		{
			select_char();
			Application.LoadLevel("main");
		}
		else
		{
			playernum = 0;
			skinchange();
		}
	}

	private void select_char()
	{
		PlayerPrefs.SetInt("char", playernum);
	}

	private void buychar()
	{
		if (Singleton<DataManager>.Instance.gameData.gold >= Int_Price)
		{
			charhave[playernum] = true;
			Singleton<DataManager>.Instance.gameData.gold -= Int_Price;
			Singleton<DataManager>.Instance.gameData.Char_Have[playernum] = true;
			Singleton<DataManager>.Instance.SaveData();
			GetComponent<AudioSource>().PlayOneShot(sfx_buy);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
	}
}
