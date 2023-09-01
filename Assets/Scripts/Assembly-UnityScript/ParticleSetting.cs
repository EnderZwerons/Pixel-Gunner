using System;
using UnityEngine;

[Serializable]
public class ParticleSetting : MonoBehaviour
{
	public float LightIntensityMult;

	public float LifeTime;

	public bool RandomRotation;

	public Vector3 PositionOffset;

	public GameObject SpawnEnd;

	private float timetemp;

	public ParticleSetting()
	{
		LightIntensityMult = -0.5f;
		LifeTime = 1f;
	}

	public void Start()
	{
		timetemp = Time.time;
		gameObject.transform.position = gameObject.transform.position + PositionOffset;
		if (RandomRotation)
		{
			float x = UnityEngine.Random.rotation.x;
			Quaternion rotation = gameObject.transform.rotation;
			float num = (rotation.x = x);
			Quaternion quaternion2 = (gameObject.transform.rotation = rotation);
			float y = UnityEngine.Random.rotation.y;
			Quaternion rotation2 = gameObject.transform.rotation;
			float num2 = (rotation2.y = y);
			Quaternion quaternion4 = (gameObject.transform.rotation = rotation2);
			float z = UnityEngine.Random.rotation.z;
			Quaternion rotation3 = gameObject.transform.rotation;
			float num3 = (rotation3.z = z);
			Quaternion quaternion6 = (gameObject.transform.rotation = rotation3);
		}
	}

	public void Update()
	{
		if (!(Time.time <= timetemp + LifeTime))
		{
			if ((bool)SpawnEnd)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(SpawnEnd, transform.position, transform.rotation);
			}
			UnityEngine.Object.Destroy(this.gameObject);
		}
		if ((bool)this.gameObject.GetComponent<Light>())
		{
			GetComponent<Light>().intensity = GetComponent<Light>().intensity + LightIntensityMult * Time.deltaTime;
		}
	}

	public void Main()
	{
	}
}
