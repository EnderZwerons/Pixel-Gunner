using Prime31;
using UnityEngine;

public class PlayerInfor : MonoBehaviour
{
	public bool SaveLv;

	public UILabel PlayerLv;

	public UILabel PlayerExp;

	public void SetUI_INFOR()
	{
		double exp = PlayerPrefs.GetInt("kill_monster") * 15;
		int num = LV_Manager.instance.lv_Cal(exp);
		if (num < 30)
		{
			double num2 = LV_Manager.instance.now_max_exp_cal(num);
			double num3 = LV_Manager.instance.now_exp_cal(exp, num);
			PlayerExp.text = "EXP. " + num3 + "/" + num2;
		}
		else
		{
			PlayerExp.text = "MAX LV";
		}
		PlayerLv.text = "LV. " + num;
		Singleton<DataManager>.Instance.gameData.playerLevel = num;
		if (SaveLv)
		{
			Singleton<DataManager>.Instance.SaveData();
			PlayerPrefs.SetInt("score_max", num);
		}
		if (num >= 2 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHA");
		}
		if (num >= 3 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHQ");
		}
		if (num >= 4 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHg");
		}
		if (num >= 5 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQHw");
		}
		if (num >= 6 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIA");
		}
		if (num >= 7 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIQ");
		}
		if (num >= 8 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIg");
		}
		if (num >= 9 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQIw");
		}
		if (num >= 10 && PlayGameServices.isSignedIn())
		{
			PlayGameServices.unlockAchievement("CgkIt83xmpAeEAIQJA");
		}
	}

	private void OnEnable()
	{
		SetUI_INFOR();
	}
}
