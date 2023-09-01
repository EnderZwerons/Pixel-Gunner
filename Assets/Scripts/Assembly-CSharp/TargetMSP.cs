using UnityEngine;

public class TargetMSP : MonoBehaviour
{
	public int hit;

	private void Update()
	{
		float num = Vector3.Distance(base.transform.position, TargetSocle.target.transform.position);
		if (num < 10f && hit <= 5)
		{
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, Quaternion.Euler(0f, 0f, 0f), 0.3f);
		}
		else if (num >= 10f)
		{
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, Quaternion.Euler(-90f, 0f, 0f), 0.5f);
			hit = 0;
		}
		else if (hit > 5 && num < 10f)
		{
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, Quaternion.Euler(-90f, 0f, 0f), 0.5f);
		}
	}

	public void Hit(int PowerofWeapon)
	{
		hit++;
	}
}
