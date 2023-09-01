using Prime31;
using UnityEngine;

public class WORLDSCORE : MonoBehaviour
{
	private void Start()
	{
	}

	private void toach()
	{
		if (PlayGameServices.isSignedIn())
		{
			PlayGameServices.showAchievements();
		}
		else
		{
			PlayGameServices.authenticate();
		}
	}

	private void achi()
	{
		if (PlayGameServices.isSignedIn())
		{
			PlayGameServices.showAchievements();
		}
		else
		{
			PlayGameServices.authenticate();
		}
	}

	private void worldscore()
	{
		if (PlayGameServices.isSignedIn())
		{
			PlayGameServices.showLeaderboards();
		}
		else
		{
			PlayGameServices.authenticate();
		}
	}
}
