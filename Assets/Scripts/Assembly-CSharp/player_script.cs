using UnityEngine;

public class player_script : MonoBehaviour
{
	public AudioClip sfx_ammoget;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "item_bullet")
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_ammoget);
			Game.ammo += 4;
			Object.Destroy(other.gameObject);
		}
		if (other.tag == "Enemy")
		{
			Game.game_state = 9;
		}
	}
}
