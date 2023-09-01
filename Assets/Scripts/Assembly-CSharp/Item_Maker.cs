using UnityEngine;

public class Item_Maker : MonoBehaviour
{
	public float regen_time;

	private float regen_time_r1;

	public GameObject item_bullet;

	public GameObject[] pos_bullet;

	private void Start()
	{
		regen_time_r1 = 0f;
	}

	private void Update()
	{
		if (Game.game_state == 0)
		{
			regen_time_r1 += Time.deltaTime;
			if (regen_time <= regen_time_r1)
			{
				Object.Instantiate(item_bullet, pos_bullet[Random.Range(0, 3)].transform.position, base.transform.rotation);
				regen_time_r1 = 0f;
			}
		}
	}
}
