using UnityEngine;

public class WaterAnimSpeed : MonoBehaviour
{
	public float speedMultiplier = 1f;

	private string animState;

	private void Start()
	{
		animState = GetComponent<Animation>().clip.name;
	}

	private void Update()
	{
		GetComponent<Animation>()[animState].speed = speedMultiplier;
	}
}
