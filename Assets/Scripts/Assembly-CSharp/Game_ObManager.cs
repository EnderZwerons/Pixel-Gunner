using UnityEngine;

public class Game_ObManager : MonoBehaviour
{
	public static Game_ObManager instance;

	public GameObject[] OB_BULLET;

	public GameObject[] OB_EFFECT;

	private void Start()
	{
		instance = this;
	}
}
