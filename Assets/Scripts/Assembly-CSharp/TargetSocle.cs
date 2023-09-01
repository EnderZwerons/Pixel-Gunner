using UnityEngine;

public class TargetSocle : MonoBehaviour
{
	public static GameObject target;

	private int hit;

	private void Start()
	{
		target = GameObject.FindWithTag("Player");
	}

	private void Update()
	{
		base.transform.LookAt(target.transform);
		base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
	}
}
