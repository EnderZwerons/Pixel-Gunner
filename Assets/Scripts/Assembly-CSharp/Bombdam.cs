using UnityEngine;

public class Bombdam : MonoBehaviour
{
	public int damage;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.gameObject.SendMessage("Hit", damage);
		}
	}
}
