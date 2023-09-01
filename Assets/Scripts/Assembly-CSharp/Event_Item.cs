using UnityEngine;

public class Event_Item : MonoBehaviour
{
	public GameObject EVENT1;

	private void Start()
	{
		CheckEvent();
	}

	private void CheckEvent()
	{
		if (PlayerPrefs.GetInt("EVENT1") != 0)
		{
			EVENT1.SetActive(false);
		}
	}

	private void Event_Btn(int i)
	{
		switch (i)
		{
		case 0:
			PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 2000);
			PlayerPrefs.SetInt("EVENT1", 1);
			break;
		}
		CheckEvent();
	}
}
