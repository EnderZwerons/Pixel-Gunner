using UnityEngine;

public class Start_UI : MonoBehaviour
{
	public GameObject UI_START;

	private void Start()
	{
		Object.Instantiate(UI_START);
	}
}
