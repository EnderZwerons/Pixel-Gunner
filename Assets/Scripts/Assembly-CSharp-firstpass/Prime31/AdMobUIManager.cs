using UnityEngine;

namespace Prime31
{
	public class AdMobUIManager : MonoBehaviourGUI
	{
		private void OnGUI()
		{
			beginColumn();
			if (GUILayout.Button("Set Test Devices"))
			{
				AdMobAndroid.setTestDevices(new string[1] { "A8D2BB83FCEC8B318E50ACF12E296C97" });
			}
			if (GUILayout.Button("My Banner"))
			{
				AdMobAndroid.createBanner("ca-app-pub-4455549067982542/5597191909", AdMobAndroidAd.phone320x50, AdMobAdPlacement.BottomCenter);
			}
			if (GUILayout.Button("Create 320x50 banner"))
			{
				AdMobAndroid.createBanner("ca-app-pub-3940256099942544/6300978111", AdMobAndroidAd.phone320x50, AdMobAdPlacement.TopCenter);
			}
			if (GUILayout.Button("Create Native banner"))
			{
				AdMobAndroid.createNativeBanner("ca-app-pub-8386987260001674/9054000747", 0, 80, AdMobAdPlacement.BottomCenter);
			}
			if (GUILayout.Button("Refresh Banner"))
			{
				AdMobAndroid.refreshAd();
			}
			if (GUILayout.Button("Hide Banner"))
			{
				AdMobAndroid.hideBanner(true);
			}
			if (GUILayout.Button("Show Banner"))
			{
				AdMobAndroid.hideBanner(false);
			}
			if (GUILayout.Button("Destroy Banner"))
			{
				AdMobAndroid.destroyBanner();
			}
			endColumn(true);
			GUILayout.Label("Interstitial Ads");
			if (GUILayout.Button("Request Interstitial"))
			{
				AdMobAndroid.requestInterstitial("ca-app-pub-8386987260001674/9875638345");
			}
			if (GUILayout.Button("Is Interstitial Ready?"))
			{
				bool flag = AdMobAndroid.isInterstitialReady();
				Debug.Log("is interstitial ready? " + flag);
			}
			if (GUILayout.Button("Display Interstitial"))
			{
				AdMobAndroid.displayInterstitial();
			}
			GUILayout.Label("Reward Based Ads");
			if (GUILayout.Button("Request Reward Based Ad"))
			{
				AdMobAndroid.requestRewardBasedAd("ca-app-pub-8386987260001674/8737488741");
			}
			if (GUILayout.Button("Is Reward Based Ad Ready?"))
			{
				bool flag2 = AdMobAndroid.isRewardBasedAdReady();
				Debug.Log("is reward based ad ready? " + flag2);
			}
			if (GUILayout.Button("Show Reward Based Ad"))
			{
				AdMobAndroid.showRewardBasedAd();
			}
			endColumn();
		}
	}
}
