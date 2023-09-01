using UnityEngine;

public class NoAdsInUnityEditorWarningLogic : MonoBehaviour
{
	public bool displayWarningText;

	private void Awake()
	{
	}

	private void Start()
	{
		if (displayWarningText)
		{
			base.gameObject.GetComponent<GUIText>().color = Color.red;
		}
	}

	private void Update()
	{
	}
}
