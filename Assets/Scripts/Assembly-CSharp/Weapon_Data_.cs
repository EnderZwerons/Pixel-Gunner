using System;
using UnityEngine;

public class Weapon_Data_ : MonoBehaviour
{
	public enum WeaponType
	{
		NORMAL,
		BUY_GEM,
		BUY_GOLD,
		CRAFT_MAT,
		LOCK
	}

	public enum WeaponType_Gun
	{
		NORMAL,
		BASUKA
	}

	[Serializable]
	public class Weapon_Class_Data
	{
		public WeaponType WY;

		public WeaponType_Gun WEAPON_TYPE;

		public string ITEM_NAME;

		public int Mat1Num;

		public int Mat2Num;

		public int NeedMat1;

		public int NeedMat2;

		public int Price;

		public int Upgrade_Price;
	}

	public Weapon_Class_Data[] WCD;

	public static Weapon_Data_ instance;

	private void Awake()
	{
		instance = this;
	}
}
