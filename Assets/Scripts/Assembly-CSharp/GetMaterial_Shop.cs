using UnityEngine;

public class GetMaterial_Shop : MonoBehaviour
{
	public UILabel Label_Number;

	public UISprite Sprite_Block;

	private int getnum;

	private int blocknum;

	public int trash_persent;

	private void Start()
	{
		if (trash_persent < Random.Range(0, 100))
		{
			blocknum = Random.Range(1, 13);
		}
		else
		{
			blocknum = 0;
		}
		getnum = Random.Range(1, 11);
		SetUI();
		Singleton<DataManager>.Instance.gameData.Material_Have[blocknum] += getnum;
		Singleton<DataManager>.Instance.SaveData();
	}

	private void SetUI()
	{
		Sprite_Block.spriteName = "m" + blocknum;
		Label_Number.text = "+" + getnum;
	}
}
