using UnityEngine;

public class DeadLine : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Enemy")
		{
			Game.game_state = 9;
			MonoBehaviour.print("gameover");
		}
	}
}
