using UnityEngine;

public class Language_Set : MonoBehaviour
{
	public string ENG;

	public string KOR;

	public string JAP;

	public string CHA;

	public string THI;

	public string IND;

	public string RUA;

	public string VIT;

	private void Start()
	{
		if (KOR == string.Empty)
		{
			KOR = ENG;
		}
		if (JAP == string.Empty)
		{
			JAP = ENG;
		}
		if (CHA == string.Empty)
		{
			CHA = ENG;
		}
		if (KOR == string.Empty)
		{
			KOR = ENG;
		}
		if (THI == string.Empty)
		{
			THI = ENG;
		}
		if (IND == string.Empty)
		{
			IND = ENG;
		}
		if (RUA == string.Empty)
		{
			RUA = ENG;
		}
		if (VIT == string.Empty)
		{
			VIT = ENG;
		}
		switch (PlayerPrefs.GetInt("Language"))
		{
		case 0:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[0];
			GetComponent<UILabel>().text = string.Empty + ENG;
			break;
		case 1:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[1];
			GetComponent<UILabel>().text = string.Empty + KOR;
			break;
		case 2:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[2];
			GetComponent<UILabel>().text = string.Empty + JAP;
			break;
		case 3:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[3];
			GetComponent<UILabel>().text = string.Empty + CHA;
			break;
		case 4:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[4];
			GetComponent<UILabel>().text = string.Empty + THI;
			break;
		case 5:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[5];
			GetComponent<UILabel>().text = string.Empty + IND;
			break;
		case 6:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[6];
			GetComponent<UILabel>().text = string.Empty + RUA;
			break;
		case 7:
			GetComponent<UILabel>().trueTypeFont = FontManager.Instance.Font_UI[7];
			GetComponent<UILabel>().text = string.Empty + VIT;
			break;
		}
	}
}
