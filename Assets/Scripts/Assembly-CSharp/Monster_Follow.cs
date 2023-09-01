using UnityEngine;

public class Monster_Follow : MonoBehaviour
{
	private GameObject targetob;

	private GameObject thisob;

	public float speed;

	private float movex;

	private float movey;

	private void Start()
	{
		targetob = GameObject.Find("Monster_TargetPos");
		thisob = base.gameObject;
	}

	private void Update()
	{
		Vector3 normalized = (targetob.transform.position - thisob.transform.position).normalized;
		base.gameObject.GetComponent<Rigidbody>().velocity = normalized * speed * Time.deltaTime;
		base.gameObject.transform.forward = normalized;
	}
}
