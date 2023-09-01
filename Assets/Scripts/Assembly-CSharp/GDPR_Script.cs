using System.Collections;
using UnityEngine;

public class GDPR_Script : MonoBehaviour
{
	public bool TestMode;

	public string string_policy = "https://pixelstargames.blogspot.kr";

	public string NextScene;

	public GameObject UI_NONE;

	public GameObject UI_EXIST;

	public GameObject UI_GDPR_1;

	public GameObject UI_GDPR_2;

	public bool this_gdpr;

	private string get_Lan = string.Empty;

	private void Start()
	{
		Check_GDPR();
	}

	private void Check_GDPR()
	{
		if (!TestMode)
		{
			if (PlayerPrefs.GetInt("GDPR") == 0)
			{
				get_Lan = Application.systemLanguage.ToString();
				if (get_Lan == "Greek")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Dutch")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Danish")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "German")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Latvian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Romanian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Letzebuergesch")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Lithuanian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Bulgarian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Swedish")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Spanish")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Slovak")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Slovenian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Estonian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Italian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Czech")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "SerboCroatian")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Portuguese")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Polish")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "French")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Finnish")
				{
					this_gdpr = true;
				}
				else if (get_Lan == "Hungarian")
				{
					this_gdpr = true;
				}
				else
				{
					this_gdpr = false;
				}
			}
			else
			{
				this_gdpr = false;
			}
		}
		else
		{
			this_gdpr = true;
		}
		if (this_gdpr)
		{
			UI_NONE.SetActive(false);
			UI_EXIST.SetActive(true);
			UI_GDPR_1.SetActive(true);
			UI_GDPR_2.SetActive(false);
		}
		else
		{
			StartCoroutine("WaitNext_Not");
		}
	}

	private void toaccept()
	{
		UI_GDPR_1.SetActive(false);
		UI_GDPR_2.SetActive(true);
		PlayerPrefs.SetInt("GDPR", 1);
	}

	private void toaccept_end()
	{
		Application.LoadLevel(NextScene);
	}

	private IEnumerator WaitNext_Not()
	{
		UI_NONE.SetActive(true);
		UI_EXIST.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		Application.LoadLevel(NextScene);
	}

	private void topolicy()
	{
		Application.OpenURL(string_policy);
	}

	private void Update()
	{
	}
}
