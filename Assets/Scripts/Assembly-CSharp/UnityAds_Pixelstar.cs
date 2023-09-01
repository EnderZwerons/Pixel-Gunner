using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds_Pixelstar : MonoBehaviour
{
	public string AD_ID;

	public string AD_ID_IOS;

	public int GiveGold;

	public GameObject FREEGOLDOB;

	public GameObject FREEGOLDOB2;

	private void Start()
	{
		//Advertisement.Initialize(AD_ID, false);
		SetUI();
	}

	private void SetUI()
	{
		if (PlayerPrefs.GetInt("VIDEOAD2") == 0)
		{
			FREEGOLDOB.SetActive(true);
		}
		else
		{
			FREEGOLDOB.SetActive(false);
		}
	}

	private void ViewViedeo()
	{
		//if (!Advertisement.IsReady())
		//{
		//	return;
		//}
		//Advertisement.Show(null, new ShowOptions
		//{
		//	resultCallback = delegate(ShowResult result)
		//	{
		//		if (result.ToString() == "Finished")
		//		{
		//			Singleton<DataManager>.Instance.gameData.gold += GiveGold;
		//			Singleton<DataManager>.Instance.SaveData();
		//			FREEGOLDOB.SetActive(false);
		//		}
		//	}
		//});
	}

	private void ViewViedeo2()
	{
		//if (!Advertisement.IsReady())
		//{
		//	return;
		//}
		//Advertisement.Show(null, new ShowOptions
		//{
		//	resultCallback = delegate(ShowResult result)
		//	{
		//		if (result.ToString() == "Finished")
		//		{
		//			Singleton<DataManager>.Instance.gameData.gold += GiveGold;
		//			Singleton<DataManager>.Instance.SaveData();
		//			FREEGOLDOB2.SetActive(false);
		//		}
		//	}
		//});
	}

	private void OnGUI()
	{
	}
}
