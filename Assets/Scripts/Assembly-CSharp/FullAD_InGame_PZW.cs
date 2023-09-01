using System.Collections;
using Prime31;
using UnityEngine;

public class FullAD_InGame_PZW : MonoBehaviour
{
	public static FullAD_InGame_PZW instance;

	public int PersentAds;

	public string InterstitalADMOB;

	public string InterstitalADMOB_ios;

	public bool ActiveAds;

	private void Start()
	{
		instance = this;
		ActiveAds = true;
		AdMobAndroid.hideBanner(true);
		AdMobAndroid.requestInterstitial(InterstitalADMOB);
	}

	public void ShowAds()
	{
		int num = Random.Range(0, 100);
		if (num <= PersentAds)
		{
			StartCoroutine("ReceiveAD");
		}
	}

	private IEnumerator ReceiveAD()
	{
		while (!AdMobAndroid.isInterstitialReady())
		{
			yield return null;
		}
		if (PlayerPrefs.GetInt("ad") == 0 && ActiveAds)
		{
			AdMobAndroid.displayInterstitial();
		}
	}
}
