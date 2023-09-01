using UnityEngine;

public class FirstRun_Script : MonoBehaviour
{
	public int[] gunlv;

	public bool[] charhave;

	public bool[] gunhave;

	public int[] mathave;

	public static FirstRun_Script instance;

	private void Awake()
	{
		instance = this;
	}

	public void GETOLDDATA()
	{
		if (PlayerPrefs.GetInt("firstrun") == 0)
		{
			Singleton<DataManager>.Instance.gameData.Weapon_Have[0] = true;
			Singleton<DataManager>.Instance.gameData.Weapon_Have[1] = true;
			Singleton<DataManager>.Instance.gameData.Weapon_Have[2] = true;
			Singleton<DataManager>.Instance.gameData.Char_Have[0] = true;
			Singleton<DataManager>.Instance.gameData.Char_Have[1] = true;
			Singleton<DataManager>.Instance.gameData.InventoryWeapon[0] = 0;
			Singleton<DataManager>.Instance.gameData.InventoryWeapon[1] = 1;
			Singleton<DataManager>.Instance.gameData.InventoryWeapon[2] = 2;
			Singleton<DataManager>.Instance.SaveData();
			PlayerPrefs.SetFloat("sensity", 4.5f);
			PlayerPrefs.SetInt("firstrun", 3);
		}
	}
}
