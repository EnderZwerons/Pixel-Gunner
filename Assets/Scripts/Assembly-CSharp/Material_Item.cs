using UnityEngine;

public class Material_Item : MonoBehaviour
{
	public int itemnum;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Magnet")
		{
			other.SendMessage("Eat", itemnum);
			Object.Destroy(base.gameObject);
		}
	}
}
