using UnityEngine;

public class mag : MonoBehaviour
{
	private float timer;

	private bool magnet;

	public GameObject playerob;

	public Vector3 pos = new Vector3(0f, 0f, 0f);

	public bool EVERY_MAG;

	private void Start()
	{
		playerob = GameObject.Find("Player");
		if (!EVERY_MAG)
		{
			magnet = false;
		}
		else
		{
			magnet = true;
		}
	}

	private void Update()
	{
		if (magnet)
		{
			pos = playerob.transform.position;
			timer += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.gameObject.transform.position, pos, 0.1f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Mag")
		{
			magnet = true;
		}
	}
}
