using UnityEngine;

public class FontManager : MonoBehaviour
{
	public static FontManager Instance;

	public Font[] Font_UI;

	private void Awake()
	{
		Instance = this;
	}
}
