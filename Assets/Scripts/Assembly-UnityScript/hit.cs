using System;
using UnityEngine;

[Serializable]
public class hit : MonoBehaviour
{
	private float time_ExpTime;

	public float particle_time;

	public void Start()
	{
		time_ExpTime = 0f;
	}

	public void Update()
	{
		if (!(time_ExpTime >= particle_time))
		{
			time_ExpTime += Time.deltaTime;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void Main()
	{
	}
}
