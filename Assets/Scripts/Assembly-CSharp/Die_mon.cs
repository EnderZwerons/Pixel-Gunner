using UnityEngine;

public class Die_mon : MonoBehaviour
{
	public GameObject textui;

	private void Start()
	{
		Object.Instantiate(textui, base.transform.position, base.transform.rotation);
	}

	private void Update()
	{
	}
}
