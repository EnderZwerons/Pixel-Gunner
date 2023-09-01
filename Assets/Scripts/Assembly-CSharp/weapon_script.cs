using UnityEngine;

public class weapon_script : MonoBehaviour
{
	public GameObject[] weapon;

	public int weaponnum;

	private int gunnum;

	public UILabel damage_ui;

	public UILabel ammo_ui;

	public UILabel range_ui;

	private int damage;

	private int max_damage;

	private int ammo;

	private float at_speed;

	public UISlider damage_bar;

	public UISprite damage_max_bar;

	public UISlider ammo_bar;

	public UISlider range_bar;

	public GameObject lockob;

	public GameObject buyob;

	public GameObject buyob_gem;

	public GameObject upgradeob;

	private bool[] gunhave = new bool[100];

	private int[] gunlv = new int[100];

	private string GunName;

	private int price_gun;

	private int price_upgrade;

	public UILabel price_label;

	public UILabel price_label_gem;

	public UILabel upgrade_label;

	public UILabel upgrade_num;

	public UILabel Name_Gun;

	public AudioClip sfx_buy;

	public AudioClip sfx_error;

	public AudioClip sfx_click;

	public UISprite MAT1;

	public UISprite MAT2;

	public UILabel MAT1_LABEL;

	public UILabel MAT2_LABEL;

	public GameObject craftob;

	private int Weapon_State;

	public GameObject UI_NORMAL;

	public GameObject UI_INVEN;

	public GameObject ARROW2_OB;

	public GameObject ARROW3_OB;

	public UISprite[] Sprite_WeaponIcon = new UISprite[3];

	private void Start()
	{
		Weapon_State = 0;
		gunnum = 0;
		change_gun(gunnum);
		GunArraySet();
		SetUI_GunSprite();
	}

	private void GunArraySet()
	{
		gunhave = Singleton<DataManager>.Instance.gameData.Weapon_Have;
		gunlv = Singleton<DataManager>.Instance.gameData.Weapon_Lv;
	}

	private void toshop()
	{
		PlayerPrefs.SetInt("ShopState", 1);
		Application.LoadLevel("shop");
	}

	private void SETUI()
	{
		switch (Weapon_State)
		{
		case 0:
			UI_NORMAL.SetActive(true);
			UI_INVEN.SetActive(false);
			break;
		case 1:
			UI_NORMAL.SetActive(false);
			UI_INVEN.SetActive(true);
			break;
		}
	}

	private void SETUI_WDATA()
	{
		damage = (int)DataBaseScript.instance.DataGetWeapon(gunnum, Singleton<DataManager>.Instance.gameData.Weapon_Lv[gunnum])[0];
		max_damage = (int)DataBaseScript.instance.DataGetWeapon(gunnum, Singleton<DataManager>.Instance.gameData.Weapon_Lv[gunnum])[1];
		at_speed = DataBaseScript.instance.DataGetWeapon(gunnum, Singleton<DataManager>.Instance.gameData.Weapon_Lv[gunnum])[2];
		ammo = (int)DataBaseScript.instance.DataGetWeapon(gunnum, Singleton<DataManager>.Instance.gameData.Weapon_Lv[gunnum])[3];
		price_gun = Weapon_Data_.instance.WCD[gunnum].Price;
		int upgrade_Price = Weapon_Data_.instance.WCD[gunnum].Upgrade_Price;
		price_upgrade = upgrade_Price + upgrade_Price * gunlv[gunnum];
		GunName = Weapon_Data_.instance.WCD[gunnum].ITEM_NAME;
		int mat1Num = Weapon_Data_.instance.WCD[gunnum].Mat1Num;
		int mat2Num = Weapon_Data_.instance.WCD[gunnum].Mat2Num;
		MAT1.spriteName = "m" + mat1Num;
		MAT2.spriteName = "m" + mat2Num;
		MAT1_LABEL.text = Singleton<DataManager>.Instance.gameData.Material_Have[mat1Num] + "/" + Weapon_Data_.instance.WCD[gunnum].NeedMat1;
		MAT2_LABEL.text = Singleton<DataManager>.Instance.gameData.Material_Have[mat2Num] + "/" + Weapon_Data_.instance.WCD[gunnum].NeedMat2;
		damage_ui.text = string.Empty + damage;
		ammo_ui.text = string.Empty + ammo;
		range_ui.text = string.Empty + (int)(1f / at_speed);
		Name_Gun.text = string.Empty + GunName;
		damage_bar.value = (float)damage * 0.005f;
		damage_max_bar.fillAmount = (float)max_damage * 0.005f;
		ammo_bar.value = (float)ammo * 0.01f;
		range_bar.value = (float)(int)(1f / at_speed) * 0.1f;
		price_label.text = string.Empty + price_gun;
		price_label_gem.text = string.Empty + price_gun;
		upgrade_label.text = string.Empty + price_upgrade;
		upgrade_num.text = "LV. " + gunlv[gunnum] + string.Empty;
		if (gunhave[gunnum])
		{
			lockob.SetActive(false);
			buyob.SetActive(false);
			buyob_gem.SetActive(false);
			craftob.SetActive(false);
			if (gunlv[gunnum] >= 10)
			{
				upgradeob.SetActive(false);
			}
			else
			{
				upgradeob.SetActive(true);
			}
			return;
		}
		lockob.SetActive(true);
		upgradeob.SetActive(false);
		switch (Weapon_Data_.instance.WCD[gunnum].WY)
		{
		case Weapon_Data_.WeaponType.NORMAL:
			buyob.SetActive(false);
			buyob_gem.SetActive(false);
			craftob.SetActive(false);
			break;
		case Weapon_Data_.WeaponType.BUY_GOLD:
			buyob.SetActive(true);
			buyob_gem.SetActive(false);
			craftob.SetActive(false);
			break;
		case Weapon_Data_.WeaponType.BUY_GEM:
			buyob.SetActive(false);
			buyob_gem.SetActive(true);
			craftob.SetActive(false);
			break;
		case Weapon_Data_.WeaponType.CRAFT_MAT:
			buyob.SetActive(false);
			buyob_gem.SetActive(false);
			craftob.SetActive(true);
			break;
		case Weapon_Data_.WeaponType.LOCK:
			buyob.SetActive(false);
			buyob_gem.SetActive(false);
			craftob.SetActive(false);
			break;
		}
	}

	private void Update()
	{
		SETUI();
		SETUI_WDATA();
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Weapon_State == 0)
			{
				Application.LoadLevel("main");
			}
			else if (Weapon_State == 1)
			{
				Weapon_State = 0;
			}
		}
	}

	private void change_gun(int numb)
	{
		gunnum = numb;
		for (int i = 0; i < weaponnum; i++)
		{
			weapon[i].SetActive(false);
		}
		weapon[numb].SetActive(true);
		UI_ARROWSET();
	}

	private void UI_ARROWSET()
	{
		if (gunhave[gunnum])
		{
			if (gunnum == 0)
			{
				ARROW2_OB.SetActive(false);
				ARROW3_OB.SetActive(false);
				return;
			}
			if (Singleton<DataManager>.Instance.gameData.InventoryWeapon[1] == gunnum)
			{
				ARROW2_OB.SetActive(false);
			}
			else
			{
				ARROW2_OB.SetActive(true);
			}
			if (Singleton<DataManager>.Instance.gameData.InventoryWeapon[2] == gunnum)
			{
				ARROW3_OB.SetActive(false);
			}
			else
			{
				ARROW3_OB.SetActive(true);
			}
		}
		else
		{
			ARROW2_OB.SetActive(false);
			ARROW3_OB.SetActive(false);
		}
	}

	private void btn_right()
	{
		if (gunnum < weaponnum - 1)
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_click);
			gunnum++;
			change_gun(gunnum);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
	}

	private void btn_left()
	{
		if (gunnum > 0)
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_click);
			gunnum--;
			change_gun(gunnum);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
	}

	private void tomain()
	{
		Application.LoadLevel("main");
	}

	private void craftgun()
	{
		int mat1Num = Weapon_Data_.instance.WCD[gunnum].Mat1Num;
		int mat2Num = Weapon_Data_.instance.WCD[gunnum].Mat2Num;
		if (Singleton<DataManager>.Instance.gameData.Material_Have[mat1Num] >= Weapon_Data_.instance.WCD[gunnum].NeedMat1 && Singleton<DataManager>.Instance.gameData.Material_Have[mat2Num] >= Weapon_Data_.instance.WCD[gunnum].NeedMat2)
		{
			Singleton<DataManager>.Instance.gameData.Material_Have[mat1Num] -= Weapon_Data_.instance.WCD[gunnum].NeedMat1;
			Singleton<DataManager>.Instance.gameData.Material_Have[mat2Num] -= Weapon_Data_.instance.WCD[gunnum].NeedMat2;
			Singleton<DataManager>.Instance.gameData.Weapon_Have[gunnum] = true;
			CraftEnd();
			GetComponent<AudioSource>().PlayOneShot(sfx_buy);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
	}

	private void CraftEnd()
	{
		GetComponent<AudioSource>().PlayOneShot(sfx_buy);
		GunArraySet();
		UI_ARROWSET();
	}

	private void buygun()
	{
		if (Singleton<DataManager>.Instance.gameData.gold >= price_gun)
		{
			Singleton<DataManager>.Instance.gameData.Weapon_Have[gunnum] = true;
			Singleton<DataManager>.Instance.gameData.gold -= price_gun;
			GetComponent<AudioSource>().PlayOneShot(sfx_buy);
			Singleton<DataManager>.Instance.SaveData();
			GunArraySet();
			UI_ARROWSET();
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
	}

	private void buygun_gem()
	{
		if (Singleton<DataManager>.Instance.gameData.gem >= price_gun)
		{
			Singleton<DataManager>.Instance.gameData.Weapon_Have[gunnum] = true;
			Singleton<DataManager>.Instance.gameData.gem -= price_gun;
			GetComponent<AudioSource>().PlayOneShot(sfx_buy);
			Singleton<DataManager>.Instance.SaveData();
			GunArraySet();
			UI_ARROWSET();
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
	}

	private void upgradegun()
	{
		if (Singleton<DataManager>.Instance.gameData.gold >= price_upgrade)
		{
			Singleton<DataManager>.Instance.gameData.Weapon_Lv[gunnum]++;
			GetComponent<AudioSource>().PlayOneShot(sfx_buy);
			Singleton<DataManager>.Instance.gameData.gold -= price_upgrade;
			Singleton<DataManager>.Instance.SaveData();
			GunArraySet();
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
	}

	private void SetUI_GunSprite()
	{
		Sprite_WeaponIcon[0].spriteName = "G" + Singleton<DataManager>.Instance.gameData.InventoryWeapon[0];
		Sprite_WeaponIcon[1].spriteName = "G" + Singleton<DataManager>.Instance.gameData.InventoryWeapon[1];
		Sprite_WeaponIcon[2].spriteName = "G" + Singleton<DataManager>.Instance.gameData.InventoryWeapon[2];
		UI_ARROWSET();
	}

	private void ChangeGun(int InvenNum)
	{
		if (gunhave[gunnum] && gunnum != 0)
		{
			switch (InvenNum)
			{
			case 1:
				if (gunnum != Singleton<DataManager>.Instance.gameData.InventoryWeapon[1])
				{
					if (Singleton<DataManager>.Instance.gameData.InventoryWeapon[2] == gunnum)
					{
						Singleton<DataManager>.Instance.gameData.InventoryWeapon[2] = Singleton<DataManager>.Instance.gameData.InventoryWeapon[1];
						Singleton<DataManager>.Instance.gameData.InventoryWeapon[1] = gunnum;
					}
					else
					{
						Singleton<DataManager>.Instance.gameData.InventoryWeapon[1] = gunnum;
					}
					GetComponent<AudioSource>().PlayOneShot(sfx_click);
				}
				else
				{
					GetComponent<AudioSource>().PlayOneShot(sfx_error);
				}
				break;
			case 2:
				if (gunnum != Singleton<DataManager>.Instance.gameData.InventoryWeapon[2])
				{
					if (Singleton<DataManager>.Instance.gameData.InventoryWeapon[1] == gunnum)
					{
						Singleton<DataManager>.Instance.gameData.InventoryWeapon[1] = Singleton<DataManager>.Instance.gameData.InventoryWeapon[2];
						Singleton<DataManager>.Instance.gameData.InventoryWeapon[2] = gunnum;
					}
					else
					{
						Singleton<DataManager>.Instance.gameData.InventoryWeapon[2] = gunnum;
					}
					GetComponent<AudioSource>().PlayOneShot(sfx_click);
				}
				else
				{
					GetComponent<AudioSource>().PlayOneShot(sfx_error);
				}
				break;
			}
			Singleton<DataManager>.Instance.SaveData();
			GunArraySet();
			SetUI_GunSprite();
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_error);
		}
		Debug.Log("ENDGUNNUM = " + gunnum);
	}

	private void tonormal()
	{
		Weapon_State = 0;
	}

	private void toinven()
	{
		Weapon_State = 1;
	}

	private void tofree()
	{
		PlayerPrefs.SetInt("ShopState", 4);
		Application.LoadLevel("shop");
	}
}
