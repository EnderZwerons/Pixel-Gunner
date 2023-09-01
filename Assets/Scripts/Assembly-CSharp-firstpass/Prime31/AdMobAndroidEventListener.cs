using UnityEngine;

namespace Prime31
{
	public class AdMobAndroidEventListener : MonoBehaviour
	{
		public GameObject SendOb;

		private void OnEnable()
		{
			AdMobAndroidManager.failedToReceiveAdEvent += failedToReceiveAdEvent;
			AdMobAndroidManager.leavingApplicationEvent += leavingApplicationEvent;
			AdMobAndroidManager.presentingScreenEvent += presentingScreenEvent;
			AdMobAndroidManager.receivedAdEvent += receivedAdEvent;
			AdMobAndroidManager.interstitialFailedToReceiveAdEvent += interstitialFailedToReceiveAdEvent;
			AdMobAndroidManager.interstitialLeavingApplicationEvent += interstitialLeavingApplicationEvent;
			AdMobAndroidManager.interstitialPresentingScreenEvent += interstitialPresentingScreenEvent;
			AdMobAndroidManager.interstitialReceivedAdEvent += interstitialReceivedAdEvent;
			AdMobAndroidManager.rewardBasedAdReceivedEvent += rewardBasedAdReceivedEvent;
			AdMobAndroidManager.rewardBasedAdFailedEvent += rewardBasedAdFailedEvent;
			AdMobAndroidManager.rewardBasedAdRewardedUserEvent += rewardBasedAdRewardedUserEvent;
			AdMobAndroidManager.dismissingScreenEvent += dismissingScreenEvent;
		}

		private void OnDisable()
		{
			AdMobAndroidManager.failedToReceiveAdEvent -= failedToReceiveAdEvent;
			AdMobAndroidManager.leavingApplicationEvent -= leavingApplicationEvent;
			AdMobAndroidManager.presentingScreenEvent -= presentingScreenEvent;
			AdMobAndroidManager.receivedAdEvent -= receivedAdEvent;
			AdMobAndroidManager.interstitialFailedToReceiveAdEvent -= interstitialFailedToReceiveAdEvent;
			AdMobAndroidManager.interstitialLeavingApplicationEvent -= interstitialLeavingApplicationEvent;
			AdMobAndroidManager.interstitialPresentingScreenEvent -= interstitialPresentingScreenEvent;
			AdMobAndroidManager.interstitialReceivedAdEvent -= interstitialReceivedAdEvent;
			AdMobAndroidManager.rewardBasedAdReceivedEvent -= rewardBasedAdReceivedEvent;
			AdMobAndroidManager.rewardBasedAdReceivedEvent -= rewardBasedAdReceivedEvent;
			AdMobAndroidManager.rewardBasedAdRewardedUserEvent -= rewardBasedAdRewardedUserEvent;
			AdMobAndroidManager.dismissingScreenEvent -= dismissingScreenEvent;
		}

		private void failedToReceiveAdEvent(string error)
		{
			Debug.Log("failedToReceiveAdEvent: " + error);
		}

		private void leavingApplicationEvent()
		{
			Debug.Log("leavingApplicationEvent");
		}

		private void presentingScreenEvent()
		{
			Debug.Log("presentingScreenEvent");
		}

		private void receivedAdEvent()
		{
			Debug.Log("receivedAdEvent");
		}

		private void interstitialFailedToReceiveAdEvent(string error)
		{
			Debug.Log("interstitialFailedToReceiveAdEvent: " + error);
		}

		private void interstitialLeavingApplicationEvent()
		{
			Debug.Log("interstitialLeavingApplicationEvent");
		}

		private void interstitialPresentingScreenEvent()
		{
			Debug.Log("interstitialPresentingScreenEvent");
		}

		private void interstitialReceivedAdEvent()
		{
			Debug.Log("interstitialReceivedAdEvent");
		}

		private void rewardBasedAdReceivedEvent()
		{
			Debug.Log("rewardBasedAdReceivedEvent");
		}

		private void rewardBasedAdFailedEvent(string error)
		{
			Debug.Log("rewardBasedAdFailedEvent: " + error);
		}

		private void rewardBasedAdRewardedUserEvent(string type, float amount)
		{
			int @int = PlayerPrefs.GetInt("ADMOB_REWARD_TYPE");
			SendOb.SendMessage("Video_End_Admob", @int, SendMessageOptions.DontRequireReceiver);
			Debug.Log("rewardBasedAdRewardedUserEvent. type: " + type + ", amount: " + amount);
		}

		private void dismissingScreenEvent(AdMobAdType adType)
		{
			Debug.Log("dismissingScreenEvent: " + adType);
		}
	}
}
