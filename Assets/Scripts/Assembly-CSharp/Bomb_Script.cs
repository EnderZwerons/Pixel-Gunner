using System.Collections;
using UnityEngine;

public class Bomb_Script : MonoBehaviour
{
	public float speed;

	public GameObject ef_explore;

	private void Start()
	{
		GetComponent<Rigidbody>().AddForce(base.transform.forward * speed);
		StartCoroutine("bombscript");
	}

	private void Update()
	{
	}

	private IEnumerator bombscript()
	{
		yield return new WaitForSeconds(2f);
		Object.Instantiate(ef_explore, base.transform.position, base.transform.rotation);
		Object.Destroy(base.gameObject, 0.2f);
	}
}
public class bomb_script : MonoBehaviour
{
	public UILabel label_movespeed;

	public UILabel label_bomb;

	public UILabel label_health;

	public UILabel label_movespeed_gold;

	public UILabel label_bomb_gold;

	public UILabel label_health_gold;

	public GameObject ob_buybtn1;

	public GameObject ob_buybtn2;

	public GameObject ob_buybtn3;

	public GameObject ob_end1;

	public GameObject ob_end2;

	public GameObject ob_end3;

	private int price_0;

	private int price_1;

	private int price_2;

	private int U1;

	private int U2;

	private int U3;

	public AudioClip click;

	public AudioClip click_error;

	public AudioClip click_buy;

	private void Start()
	{
		SetLabel();
	}

	private void SetLabel()
	{
		price_0 = DataBaseScript.instance.DataGetUpgradePrice(0);
		price_1 = DataBaseScript.instance.DataGetUpgradePrice(1);
		price_2 = DataBaseScript.instance.DataGetUpgradePrice(2);
		U1 = Singleton<DataManager>.Instance.gameData.Upgrade_Lv[0];
		U2 = Singleton<DataManager>.Instance.gameData.Upgrade_Lv[1];
		U3 = Singleton<DataManager>.Instance.gameData.Upgrade_Lv[2];
		label_movespeed.text = "LV." + U1;
		label_bomb.text = "LV." + U2;
		label_health.text = "LV." + U3;
		label_movespeed_gold.text = string.Empty + price_0;
		label_bomb_gold.text = string.Empty + price_1;
		label_health_gold.text = string.Empty + price_2;
		if (U1 <= 9)
		{
			ob_buybtn1.SetActive(true);
			ob_end1.SetActive(false);
		}
		else
		{
			ob_buybtn1.SetActive(false);
			ob_end1.SetActive(true);
		}
		if (U2 <= 9)
		{
			ob_buybtn2.SetActive(true);
			ob_end2.SetActive(false);
		}
		else
		{
			ob_buybtn2.SetActive(false);
			ob_end2.SetActive(true);
		}
		if (U3 <= 9)
		{
			ob_buybtn3.SetActive(true);
			ob_end3.SetActive(false);
		}
		else
		{
			ob_buybtn3.SetActive(false);
			ob_end3.SetActive(true);
		}
	}

	private void tomain()
	{
		Application.LoadLevel("main");
	}

	private void upgrade(int i)
	{
		switch (i)
		{
		case 0:
			MonoBehaviour.print("가격" + price_0);
			if (Singleton<DataManager>.Instance.gameData.gold >= price_0 && U1 <= 9)
			{
				Singleton<DataManager>.Instance.gameData.gold -= price_0;
				Singleton<DataManager>.Instance.gameData.Upgrade_Lv[0]++;
				GetComponent<AudioSource>().PlayOneShot(click_buy);
				Singleton<DataManager>.Instance.SaveData();
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(click_error);
			}
			break;
		case 1:
			MonoBehaviour.print("가격" + price_1);
			if (Singleton<DataManager>.Instance.gameData.gold >= price_1 && U2 <= 9)
			{
				Singleton<DataManager>.Instance.gameData.gold -= price_1;
				Singleton<DataManager>.Instance.gameData.Upgrade_Lv[1]++;
				GetComponent<AudioSource>().PlayOneShot(click_buy);
				Singleton<DataManager>.Instance.SaveData();
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(click_error);
			}
			break;
		case 2:
			MonoBehaviour.print("가격" + price_2);
			if (Singleton<DataManager>.Instance.gameData.gold >= price_2 && U3 <= 9)
			{
				Singleton<DataManager>.Instance.gameData.gold -= price_2;
				Singleton<DataManager>.Instance.gameData.Upgrade_Lv[2]++;
				GetComponent<AudioSource>().PlayOneShot(click_buy);
				Singleton<DataManager>.Instance.SaveData();
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(click_error);
			}
			break;
		}
		SetLabel();
	}
}
