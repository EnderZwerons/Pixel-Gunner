using System.Collections;
using Prime31;
using UnityEngine;

public class FULLAD_GAME : MonoBehaviour
{
	public string Admob_appId_Android;

	public string Admob_appId_Ios;

	private int randnum1;

	private int randnum2;

	public int AdPersent;

	public int AdPersent_Admob;

	private void Start()
	{
		randnum1 = Random.Range(0, 100);
		randnum2 = Random.Range(0, 100);
		if (randnum1 <= AdPersent)
		{
			AdMobAndroid.requestInterstitial(Admob_appId_Android);
			StartCoroutine("ReceiveAD_Admob");
		}
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
