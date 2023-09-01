using Prime31;
using UnityEngine;

public class Google_Login : MonoBehaviour
{
	private void Start()
	{
		if (!PlayGameServices.isSignedIn())
		{
			PlayGameServices.attemptSilentAuthentication();
		}
	}
}
