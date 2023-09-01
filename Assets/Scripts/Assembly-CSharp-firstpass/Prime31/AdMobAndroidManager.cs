using System;
using UnityEngine;

namespace Prime31
{
	public class AdMobAndroidManager : AbstractManager
	{
		public static event Action receivedAdEvent;

		public static event Action<string> failedToReceiveAdEvent;

		public static event Action<AdMobAdType> dismissingScreenEvent;

		public static event Action leavingApplicationEvent;

		public static event Action presentingScreenEvent;

		public static event Action interstitialReceivedAdEvent;

		public static event Action<string> interstitialFailedToReceiveAdEvent;

		[Obsolete("Use the dismissingScreenEvent")]
		public static event Action interstitialDismissingScreenEvent;

		public static event Action interstitialLeavingApplicationEvent;

		public static event Action interstitialPresentingScreenEvent;

		public static event Action rewardBasedAdReceivedEvent;

		public static event Action<string> rewardBasedAdFailedEvent;

		public static event Action<string, float> rewardBasedAdRewardedUserEvent;

		static AdMobAndroidManager()
		{
			AbstractManager.initialize(typeof(AdMobAndroidManager));
		}

		private void dismissingScreen(string adType)
		{
			if (AdMobAndroidManager.dismissingScreenEvent != null)
			{
				AdMobAndroidManager.dismissingScreenEvent((AdMobAdType)int.Parse(adType));
			}
		}

		private void failedToReceiveAd(string error)
		{
			if (AdMobAndroidManager.failedToReceiveAdEvent != null)
			{
				AdMobAndroidManager.failedToReceiveAdEvent(error);
			}
		}

		private void leavingApplication(string empty)
		{
			if (AdMobAndroidManager.leavingApplicationEvent != null)
			{
				AdMobAndroidManager.leavingApplicationEvent();
			}
		}

		private void presentingScreen(string empty)
		{
			if (AdMobAndroidManager.presentingScreenEvent != null)
			{
				AdMobAndroidManager.presentingScreenEvent();
			}
		}

		private void receivedAd(string empty)
		{
			if (AdMobAndroidManager.receivedAdEvent != null)
			{
				AdMobAndroidManager.receivedAdEvent();
			}
		}

		private void interstitialDismissingScreen(string empty)
		{
			if (AdMobAndroidManager.interstitialDismissingScreenEvent != null)
			{
				AdMobAndroidManager.interstitialDismissingScreenEvent();
			}
		}

		private void interstitialFailedToReceiveAd(string error)
		{
			if (AdMobAndroidManager.interstitialFailedToReceiveAdEvent != null)
			{
				AdMobAndroidManager.interstitialFailedToReceiveAdEvent(error);
			}
		}

		private void interstitialLeavingApplication(string empty)
		{
			if (AdMobAndroidManager.interstitialLeavingApplicationEvent != null)
			{
				AdMobAndroidManager.interstitialLeavingApplicationEvent();
			}
		}

		private void interstitialPresentingScreen(string empty)
		{
			if (AdMobAndroidManager.interstitialPresentingScreenEvent != null)
			{
				AdMobAndroidManager.interstitialPresentingScreenEvent();
			}
		}

		private void interstitialReceivedAd(string empty)
		{
			if (AdMobAndroidManager.interstitialReceivedAdEvent != null)
			{
				AdMobAndroidManager.interstitialReceivedAdEvent();
			}
		}

		private void rewardBasedAdDidReceiveAd(string empty)
		{
			if (AdMobAndroidManager.rewardBasedAdReceivedEvent != null)
			{
				AdMobAndroidManager.rewardBasedAdReceivedEvent();
			}
		}

		private void rewardBasedAdFailedToReceiveAd(string error)
		{
			if (AdMobAndroidManager.rewardBasedAdFailedEvent != null)
			{
				AdMobAndroidManager.rewardBasedAdFailedEvent(error);
			}
		}

		private void rewardBasedAdRewardedUser(string data)
		{
			if (AdMobAndroidManager.rewardBasedAdRewardedUserEvent != null)
			{
				string[] array = data.Split('|');
				if (array.Length == 2)
				{
					AdMobAndroidManager.rewardBasedAdRewardedUserEvent(array[0], float.Parse(array[1]));
				}
				else
				{
					Debug.LogError("invalid data from reward received: " + data);
				}
			}
		}
	}
}
