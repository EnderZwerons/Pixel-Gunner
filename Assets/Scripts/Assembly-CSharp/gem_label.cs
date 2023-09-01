using UnityEngine;

public class gem_label : MonoBehaviour
{
	public UILabel thislabel;

	private void Update()
	{
		thislabel.text = Singleton<DataManager>.Instance.gameData.gem + string.Empty;
	}
}
