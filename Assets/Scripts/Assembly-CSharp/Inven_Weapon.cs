using UnityEngine;

public class Inven_Weapon : MonoBehaviour
{
	public UILabel[] invenmat;

	public int maxinven;

	private void Start()
	{
	}

	private void OnEnable()
	{
		invencheck();
	}

	private void invencheck()
	{
		for (int i = 0; i < invenmat.Length; i++)
		{
			invenmat[i].text = string.Empty + Singleton<DataManager>.Instance.gameData.Material_Have[i];
		}
	}
}
