using UnityEngine;

public class Player_Mat : MonoBehaviour
{
	public AudioClip sfx_mateat;

	private void Eat(int matnum)
	{
		GetComponent<AudioSource>().PlayOneShot(sfx_mateat);
		Singleton<DataManager>.Instance.gameData.Material_Have[matnum]++;
		Singleton<DataManager>.Instance.SaveData();
	}
}
