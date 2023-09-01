using UnityEngine;

public class Btn_Back_Key : MonoBehaviour
{
	public string backscene;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PlayerPrefs.SetInt("ShopState", 0);
			Application.LoadLevel(backscene);
		}
	}
}
