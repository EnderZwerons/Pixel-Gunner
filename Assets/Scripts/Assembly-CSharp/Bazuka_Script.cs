using UnityEngine;

public class Bazuka_Script : MonoBehaviour
{
	public float speed;

	public GameObject ef_explore;

	public int Type_this;

	private void Start()
	{
		GetComponent<Rigidbody>().AddForce(base.transform.forward * speed);
		Object.Destroy(base.gameObject, 7f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ground" && Type_this == 0)
		{
			Object.Instantiate(ef_explore, base.transform.position, base.transform.rotation);
			Object.Destroy(base.gameObject, 0.2f);
		}
		if (other.tag == "Enemy")
		{
			if (Type_this == 0)
			{
				Object.Instantiate(ef_explore, base.transform.position, base.transform.rotation);
				Object.Destroy(base.gameObject, 0.2f);
			}
			else if (Type_this == 1)
			{
				other.gameObject.SendMessage("Hit", MSPFps.instance.CurrentWeapon.WeaponPower);
			}
		}
	}
}
