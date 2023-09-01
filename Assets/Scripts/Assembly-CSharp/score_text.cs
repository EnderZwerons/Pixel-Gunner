using UnityEngine;

public class score_text : MonoBehaviour
{
	public UILabel scoretext;

	private void Start()
	{
	}

	private void Update()
	{
		scoretext.text = string.Empty + PlayerPrefs.GetInt("score_max");
	}
}
