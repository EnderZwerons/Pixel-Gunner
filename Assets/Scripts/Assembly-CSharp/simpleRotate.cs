using UnityEngine;

public class simpleRotate : MonoBehaviour
{
	private void Update()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 50f);
	}
}
