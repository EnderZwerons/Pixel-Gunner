using System.Collections;
using Prime31;
using UnityEngine;

public class FULLAD_Manager : MonoBehaviour
{
	public static FULLAD_Manager instance;

	public string Admob_appId_Android;

	public string Admob_appId_Ios;

	public int AdPersent_Admob;

	public void ShowAds()
	{
		StartCoroutine("ReceiveAD_Admob");
		RequsetAds();
	}

	public void RequsetAds()
	{
		AdMobAndroid.requestInterstitial(Admob_appId_Android);
	}

	private void Start()
	{
		instance = this;
		RequsetAds();
	}

	private IEnumerator ReceiveAD_Admob()
	{
		while (!AdMobAndroid.isInterstitialReady())
		{
			yield return null;
		}
		if (PlayerPrefs.GetInt("ad") == 0)
		{
			AdMobAndroid.displayInterstitial();
		}
	}
}
