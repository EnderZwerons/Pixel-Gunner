using UnityEngine;

public class SetSkin_Player : MonoBehaviour
{
	public Material[] PlayerMaterial;

	private int playernum;

	private void Start()
	{
		playernum = PlayerPrefs.GetInt("char");
		skinchange();
	}

	private void skinchange()
	{
		base.gameObject.GetComponent<Renderer>().material = PlayerMaterial[playernum];
	}
}
