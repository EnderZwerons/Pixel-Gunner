using UnityEngine;

public class gold_label : MonoBehaviour
{
	public UILabel thislabel;

	private void Update()
	{
		thislabel.text = Singleton<DataManager>.Instance.gameData.gold + string.Empty;
	}
}
