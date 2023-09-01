using UnityEngine;

public class Language_Core : MonoBehaviour
{
	public static Language_Core instance;

	private void Awake()
	{
		instance = this;
	}

	public string OutText(string CODENUM)
	{
		int @int = PlayerPrefs.GetInt("Language");
		string empty = string.Empty;
		switch (CODENUM)
		{
		case "T001":
			switch (@int)
			{
			case 0:
				return "TEST001";
			case 1:
				return "테스트001";
			case 2:
				return "テスト001";
			case 3:
				return "测试001";
			default:
				return "TEST001";
			}
		case "T002":
			switch (@int)
			{
			case 0:
				return "TEST002";
			case 1:
				return "테스트002";
			case 2:
				return "テスト002";
			case 3:
				return "测试002";
			default:
				return "TEST002";
			}
		default:
			return "Error _001";
		}
	}
}
