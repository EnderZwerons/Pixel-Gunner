using Prime31;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public UILabel Label_Level;

	public UILabel Label_Exp;

	private int Int_Lv;

	private int Int_Exp;

	public int[] Int_NeedExp;

	private void Start()
	{
		SetUI();
	}

	private void SetUI()
	{
		CheckLv();
		Label_Level.text = "LV. " + Int_Lv;
		Label_Exp.text = "EXP. " + Int_Exp + "/" + Int_NeedExp[Int_Lv - 1];
	}

	private void CheckLv()
	{
		Int_Exp = PlayerPrefs.GetInt("kill_monster");
		if (Int_Exp < Int_NeedExp[0])
		{
			Int_Lv = 1;
		}
		else if (Int_Exp >= Int_NeedExp[0] && Int_Exp < Int_NeedExp[1])
		{
			Int_Lv = 2;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHA");
			}
		}
		else if (Int_Exp >= Int_NeedExp[1] && Int_Exp < Int_NeedExp[2])
		{
			Int_Lv = 3;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHQ");
			}
		}
		else if (Int_Exp >= Int_NeedExp[2] && Int_Exp < Int_NeedExp[3])
		{
			Int_Lv = 4;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHg");
			}
		}
		else if (Int_Exp >= Int_NeedExp[3] && Int_Exp < Int_NeedExp[4])
		{
			Int_Lv = 5;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHw");
			}
		}
		else if (Int_Exp >= Int_NeedExp[4] && Int_Exp < Int_NeedExp[5])
		{
			Int_Lv = 6;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIA");
			}
		}
		else if (Int_Exp >= Int_NeedExp[5] && Int_Exp < Int_NeedExp[6])
		{
			Int_Lv = 7;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIQ");
			}
		}
		else if (Int_Exp >= Int_NeedExp[6] && Int_Exp < Int_NeedExp[7])
		{
			Int_Lv = 8;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIg");
			}
		}
		else if (Int_Exp >= Int_NeedExp[7] && Int_Exp < Int_NeedExp[8])
		{
			Int_Lv = 9;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIw");
			}
		}
		else if (Int_Exp >= Int_NeedExp[8] && Int_Exp < Int_NeedExp[9])
		{
			Int_Lv = 10;
			if (PlayGameServices.isSignedIn())
			{
				PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQJA");
			}
		}
		else
		{
			Int_Lv = 11;
		}
		PlayerPrefs.SetInt("score_max", Int_Lv);
	}
}
