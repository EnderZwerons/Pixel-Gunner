using UnityEngine;

public class Blood : MonoBehaviour
{
	private void Start()
	{
		Object.Destroy(base.gameObject, 5f);
	}

	private void Update()
	{
	}
}
