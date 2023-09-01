using UnityEngine;

public class DataBaseScript : MonoBehaviour
{
	public static DataBaseScript instance;

	private void Start()
	{
		Object.DontDestroyOnLoad(this);
		instance = this;
	}

	public int DataGetUpgradePrice(int upgradenum)
	{
		int result = 0;
		switch (upgradenum)
		{
		case 0:
			result = 200 + 100 * upgradenum * upgradenum;
			break;
		case 1:
			result = 200 + 100 * upgradenum * upgradenum;
			break;
		case 2:
			result = 200 + 100 * upgradenum * upgradenum;
			break;
		case 3:
			result = 200 + 100 * upgradenum * upgradenum;
			break;
		case 4:
			result = 200 + 100 * upgradenum * upgradenum;
			break;
		case 5:
			result = 200 + 100 * upgradenum * upgradenum;
			break;
		}
		return result;
	}

	public int DataGetSkinPrice(int SkinNumb)
	{
		int result = 0;
		switch (SkinNumb)
		{
		case 0:
			result = 0;
			break;
		case 1:
			result = 0;
			break;
		case 2:
			result = 200;
			break;
		case 3:
			result = 300;
			break;
		case 4:
			result = 250;
			break;
		case 5:
			result = 500;
			break;
		case 6:
			result = 600;
			break;
		case 7:
			result = 800;
			break;
		case 8:
			result = 400;
			break;
		case 9:
			result = 800;
			break;
		case 10:
			result = 400;
			break;
		case 11:
			result = 1000;
			break;
		case 12:
			result = 800;
			break;
		case 13:
			result = 500;
			break;
		case 14:
			result = 1200;
			break;
		case 15:
			result = 2200;
			break;
		case 16:
			result = 1200;
			break;
		case 17:
			result = 1200;
			break;
		case 18:
			result = 1000;
			break;
		case 19:
			result = 900;
			break;
		case 20:
			result = 2500;
			break;
		}
		return result;
	}

	public float[] DataGetWeapon(int Gunnum, int GunLv)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		switch (Gunnum)
		{
		case 0:
			num = 15 + GunLv * 1;
			num2 = 20f;
			num3 = 0.5f;
			num4 = 12f;
			break;
		case 1:
			num = 7 + GunLv * 1;
			num2 = 17f;
			num3 = 0.13f;
			num4 = 25f;
			break;
		case 2:
			num = 35 + GunLv * 3;
			num2 = 65f;
			num3 = 0.5f;
			num4 = 15f;
			break;
		case 3:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 4:
			num = 12 + GunLv * 1;
			num2 = 22f;
			num3 = 0.125f;
			num4 = 40f;
			break;
		case 5:
			num = 70 + GunLv * 7;
			num2 = 140f;
			num3 = 1f;
			num4 = 5f;
			break;
		case 6:
			num = 22 + GunLv * 2;
			num2 = 42f;
			num3 = 0.3f;
			num4 = 15f;
			break;
		case 7:
			num = 9 + GunLv * 1;
			num2 = 19f;
			num3 = 0.1f;
			num4 = 30f;
			break;
		case 8:
			num = 13 + GunLv * 1;
			num2 = 23f;
			num3 = 0.13f;
			num4 = 50f;
			break;
		case 9:
			num = 84 + GunLv * 8;
			num2 = 164f;
			num3 = 0.7f;
			num4 = 10f;
			break;
		case 10:
			num = 20 + GunLv * 2;
			num2 = 40f;
			num3 = 0.125f;
			num4 = 100f;
			break;
		case 11:
			num = 80 + GunLv * 8;
			num2 = 160f;
			num3 = 1f;
			num4 = 10f;
			break;
		case 12:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.125f;
			num4 = 25f;
			break;
		case 13:
			num = 35 + GunLv * 3;
			num2 = 65f;
			num3 = 0.15f;
			num4 = 4f;
			break;
		case 14:
			num = 60 + GunLv * 6;
			num2 = 120f;
			num3 = 1.5f;
			num4 = 50f;
			break;
		case 15:
			num = 9 + GunLv * 1;
			num2 = 19f;
			num3 = 0.13f;
			num4 = 35f;
			break;
		case 16:
			num = 70 + GunLv * 7;
			num2 = 140f;
			num3 = 1f;
			num4 = 15f;
			break;
		case 17:
			num = 25 + GunLv * 2;
			num2 = 45f;
			num3 = 0.2f;
			num4 = 45f;
			break;
		case 18:
			num = 120 + GunLv * 12;
			num2 = 240f;
			num3 = 1f;
			num4 = 10f;
			break;
		case 19:
			num = 40 + GunLv * 4;
			num2 = 80f;
			num3 = 0.3f;
			num4 = 20f;
			break;
		case 20:
			num = 20 + GunLv * 2;
			num2 = 40f;
			num3 = 0.15f;
			num4 = 25f;
			break;
		case 21:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 22:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 23:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 24:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 25:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 26:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 27:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 28:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 29:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 30:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 31:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 32:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 33:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 34:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		case 35:
			num = 10 + GunLv * 1;
			num2 = 20f;
			num3 = 0.14f;
			num4 = 25f;
			break;
		}
		return new float[4] { num, num2, num3, num4 };
	}
}
