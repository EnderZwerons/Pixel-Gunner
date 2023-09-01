using UnityEngine;

public class Weapon_Rotate : MonoBehaviour
{
	public float rot_speed;

	private void Start()
	{
	}

	private void Update()
	{
		base.transform.Rotate(new Vector3(rot_speed, 0f, 0f));
	}
}
