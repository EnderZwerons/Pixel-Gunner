using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prime31
{
	public class PlayGameServices
	{
		private static AndroidJavaObject _plugin;

		static PlayGameServices()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.prime31.PlayGameServicesPlugin"))
			{
				_plugin = androidJavaClass.CallStatic<AndroidJavaObject>("instance", new object[0]);
			}
		}

		public static string getGamesServerAuthCode(string serverClientId)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return null;
			}
			return _plugin.Call<string>("getGamesServerAuthCode", new object[1] { serverClientId });
		}

		public static void getGamesServerAuthCode2(string serverClientId, string oauthScope = null, bool forceCodeForRefreshToken = false)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("getGamesServerAuthCode2", serverClientId, oauthScope, forceCodeForRefreshToken);
			}
		}

		public static void setMaxSnapshotConflictResolveRetries(int maxRetries)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("setMaxSnapshotConflictResolveRetries", maxRetries);
			}
		}

		public static void enableDebugLog(bool shouldEnable)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("enableDebugLog", shouldEnable);
			}
		}

		public static void setToastSettings(GPGToastPlacement placement)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("setToastSettings", (int)placement);
			}
		}

		public static string getLaunchInvitation()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return null;
			}
			return _plugin.Call<string>("getLaunchInvitation", new object[0]);
		}

		public static void attemptSilentAuthentication()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("attemptSilentAuthentication");
			}
		}

		public static void authenticateInProxyActivity()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("authenticateInProxyActivity");
			}
		}

		public static void authenticate()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("authenticate");
			}
		}

		public static void signOut()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("signOut");
			}
		}

		public static bool isSignedIn()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			return _plugin.Call<bool>("isSignedIn", new object[0]);
		}

		public static GPGPlayerInfo getLocalPlayerInfo()
		{
			GPGPlayerInfo result = new GPGPlayerInfo();
			if (Application.platform != RuntimePlatform.Android)
			{
				return result;
			}
			string json = _plugin.Call<string>("getLocalPlayerInfo", new object[0]);
			return Json.decode<GPGPlayerInfo>(json);
		}

		public static void loadPlayer(string playerId)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadPlayer", playerId);
			}
		}

		public static void loadPlayerStats(bool forceReload = false)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadPlayerStats", forceReload);
			}
		}

		public static void reloadAchievementAndLeaderboardData()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadBasicModelData");
			}
		}

		public static void loadProfileImageForUri(string uri)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadProfileImageForUri", uri);
			}
		}

		public static void showShareDialog(string prefillText = null, string urlToShare = null)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showShareDialog", prefillText, urlToShare);
			}
		}

		public static void showVideoCaptureOverlay()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showVideoCaptureOverlay");
			}
		}

		public static void showAchievements()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showAchievements");
			}
		}

		public static void revealAchievement(string achievementId)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("revealAchievement", achievementId);
			}
		}

		public static void unlockAchievement(string achievementId, bool showsCompletionNotification = true)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("unlockAchievement", achievementId, showsCompletionNotification);
			}
		}

		public static void incrementAchievement(string achievementId, int numSteps)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("incrementAchievement", achievementId, numSteps);
			}
		}

		public static void setAchievementSteps(string achievementId, int numStep)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("setAchievementSteps", achievementId, numStep);
			}
		}

		public static List<GPGAchievementMetadata> getAllAchievementMetadata()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return new List<GPGAchievementMetadata>();
			}
			string json = _plugin.Call<string>("getAllAchievementMetadata", new object[0]);
			return Json.decode<List<GPGAchievementMetadata>>(json);
		}

		public static void showLeaderboard(string leaderboardId)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showLeaderboard", leaderboardId);
			}
		}

		public static void showLeaderboard(string leaderboardId, GPGLeaderboardTimeScope timeScope)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showLeaderboardWithTimeScope", leaderboardId, (int)timeScope);
			}
		}

		public static void showLeaderboards()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showLeaderboards");
			}
		}

		public static void submitScore(string leaderboardId, long score, string scoreTag = "")
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("submitScore", leaderboardId, score, scoreTag);
			}
		}

		public static void loadScoresForLeaderboard(string leaderboardId, GPGLeaderboardTimeScope timeScope, bool isSocial, bool personalWindow)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadScoresForLeaderboard", leaderboardId, (int)timeScope, isSocial, personalWindow);
			}
		}

		public static void loadMoreScoresForLeaderboard(string leaderboardId)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadMoreScoresForLeaderboard", leaderboardId);
			}
		}

		public static void loadCurrentPlayerLeaderboardScore(string leaderboardId, GPGLeaderboardTimeScope timeScope, bool isSocial)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadCurrentPlayerLeaderboardScore", leaderboardId, (int)timeScope, isSocial);
			}
		}

		public static List<GPGLeaderboardMetadata> getAllLeaderboardMetadata()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return new List<GPGLeaderboardMetadata>();
			}
			string json = _plugin.Call<string>("getAllLeaderboardMetadata", new object[0]);
			return Json.decode<List<GPGLeaderboardMetadata>>(json);
		}

		public static void loadAllEvents()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadAllEvents");
			}
		}

		public static void incrementEvent(string eventId, int steps)
		{
			if (Application.platform == RuntimePlatform.Android && steps > 0)
			{
				_plugin.Call("incrementEvent", eventId, steps);
			}
		}

		[Obsolete("Google has deprecated Quests. http://bit.ly/2nPCO8d")]
		public static void showStateChangedPopup(string questId)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showStateChangedPopup", questId);
			}
		}

		[Obsolete("Google has deprecated Quests. http://bit.ly/2nPCO8d")]
		public static void showQuestList()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showQuestList");
			}
		}

		[Obsolete("Google has deprecated Quests. http://bit.ly/2nPCO8d")]
		public static void claimQuestMilestone(string questId, string questMilestoneId)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("claimQuest", questId, questMilestoneId);
			}
		}

		public static void showSnapshotList(int maxSavedGamesToShow, string title, bool allowAddButton, bool allowDelete)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("showSnapshotList", maxSavedGamesToShow, title, allowAddButton, allowDelete);
			}
		}

		public static void saveSnapshot(string snapshotName, bool createIfMissing, byte[] data, string description, GPGSnapshotConflictPolicy conflictPolicy = GPGSnapshotConflictPolicy.MostRecentlyModified, long playedTimeMilliseconds = 0, long progressValue = -1)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("saveSnapshot", snapshotName, createIfMissing, data, description, (int)conflictPolicy, playedTimeMilliseconds, progressValue);
			}
		}

		public static void loadSnapshot(string snapshotName)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("loadSnapshot", snapshotName);
			}
		}

		public static void deleteSnapshot(string snapshotName)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				_plugin.Call("deleteSnapshot", snapshotName);
			}
		}
	}
}
