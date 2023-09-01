using System.Collections;
using Prime31;
using UnityEngine;

public class TestAD : MonoBehaviour
{
	private void Start()
	{
		int num = Random.Range(0, 100);
		AdMobAndroid.requestInterstitial("ca-app-pub-4455549067982542/4869332514");
		if (num >= 50 && PlayerPrefs.GetInt("ad") == 0)
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
		AdMobAndroid.displayInterstitial();
	}
}
