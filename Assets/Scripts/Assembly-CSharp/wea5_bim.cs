using UnityEngine;

public class wea5_bim : MonoBehaviour
{
	private float scale_in;

	public float upspeed;

	public float deletetime;

	private void Start()
	{
		scale_in = 0f;
	}

	private void Update()
	{
		if (scale_in <= 4f)
		{
			scale_in += Time.deltaTime * upspeed;
		}
		base.transform.localScale = new Vector3(scale_in, scale_in, scale_in);
		base.transform.Rotate(new Vector3(0f, 4f, 0f));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.gameObject.SendMessage("Hit", MSPFps.instance.CurrentWeapon.WeaponPower);
		}
	}
}
