using Prime31;
using UnityEngine;

public class admob_ui : MonoBehaviour
{
	private void Start()
	{
		if (PlayerPrefs.GetInt("ad") == 0)
		{
			AdMobAndroid.createBanner("ca-app-pub-4455549067982542/3392599312", AdMobAndroidAd.smartBanner, AdMobAdPlacement.BottomCenter);
		}
	}
}
