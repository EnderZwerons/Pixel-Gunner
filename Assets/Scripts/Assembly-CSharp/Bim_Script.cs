using UnityEngine;

public class Bim_Script : MonoBehaviour
{
	private Transform target;

	public float speed;

	public int damage;

	public float lifetime;

	private void Start()
	{
		target = GameObject.Find("HITPOS").transform;
		base.transform.LookAt(new Vector3(target.position.x, target.transform.position.y, target.position.z), Vector3.up);
		GetComponent<Rigidbody>().AddForce(base.transform.forward * speed);
		Object.Destroy(base.gameObject, lifetime);
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.SendMessage("damaged", damage);
			Object.Destroy(base.gameObject);
		}
		if (other.tag == "ground")
		{
			Object.Destroy(base.gameObject, 0.1f);
		}
	}
}
