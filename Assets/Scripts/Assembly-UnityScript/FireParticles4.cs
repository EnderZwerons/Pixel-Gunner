using System;
using UnityEngine;

[Serializable]
public class FireParticles4 : MonoBehaviour
{
	public GameObject ParticleA;

	public void Update()
	{
		RaycastHit hitInfo = default(RaycastHit);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hitInfo, 200f))
		{
			GameObject obj = (GameObject)UnityEngine.Object.Instantiate(ParticleA, hitInfo.point, Quaternion.identity);
			UnityEngine.Object.Destroy(obj, 12f);
		}
	}

	public void Main()
	{
	}
}
