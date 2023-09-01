using System.Collections;
using UnityEngine;

public class shop_script : MonoBehaviour
{
	public int shop_state;

	public GameObject UI_GOLDSHOP;

	public GameObject UI_MATERIAL;

	public GameObject UI_INVEN;

	public GameObject UI_ETC;

	public GameObject UI_GETMAT1;

	public GameObject UI_FREEGOLD;

	public GameObject UI_GEM;

	public AudioClip SFX_BUY;

	public AudioClip SFX_ERROR;

	public UISprite[] SPRITE_COLOR;

	private void Start()
	{
		shop_state = PlayerPrefs.GetInt("ShopState");
		string text = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA81ufZ9YEDJdn5CJc3ge3F84agNovupHMGB474or6lIalAxalNjhAEyHC6INAJl4h3fV2mZ0HTDEYb+kHMuIDPvM8KfPNwHzmCe+Gg0KftCSv6ci7TlYTftJH+iQH4SKKOro1PCzHNKsNxB687paMGY1UKkb/fa9ng+2jMCWaFH8cLi5n2XSqrlnVa3OUJeOVrB23zbi8z14UeH7CxfFVcLDq8Eeo2si2WxKCNaAxop2XCAHdB6UNL2nbuFUB/vSGj4tQWUvywa/sG6/+n3rqJsGzX33fca0x5YOWQa/sfRpGnOwQPwkrLxrkhA/oLBTA1gP6EAL3HWJPSDHJaswmjwIDAQAB";
		string[] array = new string[6] { "com.pixelstar.pixelgunner.1000g", "com.pixelstar.pixelgunner.5000g", "com.pixelstar.pixelgunner.10000g", "com.pixelstar.pixelgunner.20000g", "com.pixelstar.pixelgunner.100gem", "com.pixelstar.pixelgunner.1000gem" };
	}

	private void Update()
	{
		SetUI();
	}

	private void SetUI()
	{
		switch (shop_state)
		{
		case 0:
			UI_GOLDSHOP.SetActive(true);
			UI_MATERIAL.SetActive(false);
			UI_INVEN.SetActive(false);
			UI_ETC.SetActive(true);
			UI_FREEGOLD.SetActive(false);
			UI_GEM.SetActive(false);
			SPRITE_COLOR[0].color = Color.green;
			SPRITE_COLOR[1].color = Color.white;
			SPRITE_COLOR[2].color = Color.white;
			SPRITE_COLOR[3].color = Color.white;
			SPRITE_COLOR[4].color = Color.white;
			break;
		case 1:
			UI_GOLDSHOP.SetActive(false);
			UI_MATERIAL.SetActive(true);
			UI_INVEN.SetActive(false);
			UI_ETC.SetActive(true);
			UI_FREEGOLD.SetActive(false);
			UI_GEM.SetActive(false);
			SPRITE_COLOR[0].color = Color.white;
			SPRITE_COLOR[1].color = Color.green;
			SPRITE_COLOR[2].color = Color.white;
			SPRITE_COLOR[3].color = Color.white;
			SPRITE_COLOR[4].color = Color.white;
			break;
		case 9:
			UI_GOLDSHOP.SetActive(false);
			UI_MATERIAL.SetActive(false);
			UI_INVEN.SetActive(false);
			UI_ETC.SetActive(false);
			UI_FREEGOLD.SetActive(false);
			UI_GEM.SetActive(false);
			break;
		case 3:
			UI_GOLDSHOP.SetActive(false);
			UI_MATERIAL.SetActive(false);
			UI_INVEN.SetActive(true);
			UI_ETC.SetActive(true);
			UI_FREEGOLD.SetActive(false);
			UI_GEM.SetActive(false);
			SPRITE_COLOR[0].color = Color.white;
			SPRITE_COLOR[1].color = Color.white;
			SPRITE_COLOR[2].color = Color.green;
			SPRITE_COLOR[3].color = Color.white;
			SPRITE_COLOR[4].color = Color.white;
			break;
		case 4:
			UI_GOLDSHOP.SetActive(false);
			UI_MATERIAL.SetActive(false);
			UI_INVEN.SetActive(false);
			UI_ETC.SetActive(true);
			UI_FREEGOLD.SetActive(true);
			UI_GEM.SetActive(false);
			SPRITE_COLOR[0].color = Color.white;
			SPRITE_COLOR[1].color = Color.white;
			SPRITE_COLOR[2].color = Color.white;
			SPRITE_COLOR[3].color = Color.green;
			SPRITE_COLOR[4].color = Color.white;
			break;
		case 5:
			UI_GOLDSHOP.SetActive(false);
			UI_MATERIAL.SetActive(false);
			UI_INVEN.SetActive(false);
			UI_ETC.SetActive(true);
			UI_FREEGOLD.SetActive(false);
			UI_GEM.SetActive(true);
			SPRITE_COLOR[0].color = Color.white;
			SPRITE_COLOR[1].color = Color.white;
			SPRITE_COLOR[2].color = Color.white;
			SPRITE_COLOR[3].color = Color.white;
			SPRITE_COLOR[4].color = Color.green;
			break;
		case 2:
		case 6:
		case 7:
		case 8:
			break;
		}
	}

	private void tomat()
	{
		shop_state = 1;
	}

	private void togold()
	{
		shop_state = 0;
	}

	private void togem()
	{
		shop_state = 5;
	}

	private void toinven()
	{
		shop_state = 3;
	}

	private void tofree()
	{
		shop_state = 4;
	}

	private void purchase_material(int i)
	{
		switch (i)
		{
		case 0:
			if (Singleton<DataManager>.Instance.gameData.gold >= 350)
			{
				GetComponent<AudioSource>().PlayOneShot(SFX_BUY);
				Singleton<DataManager>.Instance.gameData.gold -= 350;
				Debug.Log("BuyGold");
				StartCoroutine("GetMaterial");
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(SFX_ERROR);
				Debug.Log("NotEnoughMoney");
			}
			break;
		}
		Singleton<DataManager>.Instance.SaveData();
	}

	private IEnumerator GetMaterial()
	{
		shop_state = 9;
		Debug.Log("go2");
		Object.Instantiate(UI_GETMAT1);
		yield return new WaitForSeconds(2f);
		shop_state = 1;
	}

	private void purchase_inapp(int i)
	{
	}

	private void BUYGOLD_GEM(int indexnum)
	{
		switch (indexnum)
		{
		case 0:
			if (Singleton<DataManager>.Instance.gameData.gem >= 30)
			{
				Singleton<DataManager>.Instance.gameData.gem -= 30;
				Singleton<DataManager>.Instance.gameData.gold += 500;
				Singleton<DataManager>.Instance.SaveData();
				GetComponent<AudioSource>().PlayOneShot(SFX_BUY);
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(SFX_ERROR);
			}
			break;
		case 1:
			if (Singleton<DataManager>.Instance.gameData.gem >= 300)
			{
				Singleton<DataManager>.Instance.gameData.gem -= 300;
				Singleton<DataManager>.Instance.gameData.gold += 5000;
				Singleton<DataManager>.Instance.SaveData();
				GetComponent<AudioSource>().PlayOneShot(SFX_BUY);
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(SFX_ERROR);
			}
			break;
		}
	}

	private void GETGOLD(int inappnum)
	{
		switch (inappnum)
		{
		case 0:
			Singleton<DataManager>.Instance.gameData.gold += 2000;
			break;
		case 1:
			Singleton<DataManager>.Instance.gameData.gold += 10000;
			break;
		case 2:
			Singleton<DataManager>.Instance.gameData.gold += 20000;
			break;
		case 3:
			Singleton<DataManager>.Instance.gameData.gold += 40000;
			break;
		case 4:
			Singleton<DataManager>.Instance.gameData.gem += 100;
			break;
		case 5:
			Singleton<DataManager>.Instance.gameData.gem += 1000;
			break;
		}
		Singleton<DataManager>.Instance.SaveData();
	}

	private void tomain()
	{
		PlayerPrefs.SetInt("ShopState", 0);
		Application.LoadLevel("main");
	}

	private void Video_End()
	{
		Singleton<DataManager>.Instance.gameData.gold += 250;
		Singleton<DataManager>.Instance.SaveData();
	}
}
