using UnityEngine;

public class lookatplayer : MonoBehaviour
{
	private void Start()
	{
		base.transform.LookAt(new Vector3(0f, 0f, 0f));
	}

	private void Update()
	{
	}
}
