using UnityEngine;

public class Monmaker : MonoBehaviour
{
	public GameObject[] pos_monmake;

	public GameObject[] monster;

	public int pos_num;

	public float regen_time;

	private float regen_time_r1;

	public float stream_time;

	private float stream_time_r1;

	private int monnum;

	public int monnumber;

	private void Start()
	{
		regen_time_r1 = 0f;
		monnum = 0;
	}

	private void Update()
	{
		if (Game.game_state != 0)
		{
			return;
		}
		regen_time_r1 += Time.deltaTime;
		stream_time_r1 += Time.deltaTime;
		if (stream_time_r1 >= stream_time)
		{
			if (monnumber - 1 > monnum)
			{
				monnum++;
			}
			stream_time_r1 = 0f;
		}
		if (!(regen_time_r1 > regen_time))
		{
			return;
		}
		int num = Random.Range(0, 100);
		if (num > 0 && num < 50)
		{
			Object.Instantiate(monster[monnum], pos_monmake[Random.Range(0, pos_num)].transform.position + new Vector3(Random.Range(-4, 5), 0f, 0f), base.transform.rotation);
		}
		else if (num >= 50 && num < 60)
		{
			Object.Instantiate(monster[Random.Range(0, 6)], pos_monmake[Random.Range(0, pos_num)].transform.position + new Vector3(Random.Range(-4, 5), 0f, 0f), base.transform.rotation);
		}
		else if (num >= 60 && num < 100)
		{
			int num2 = Random.Range(0, 5);
			if (monnum - num2 >= 0)
			{
				Object.Instantiate(monster[monnum - num2], pos_monmake[Random.Range(0, pos_num)].transform.position + new Vector3(Random.Range(-4, 5), 0f, 0f), base.transform.rotation);
			}
			else
			{
				Object.Instantiate(monster[0], pos_monmake[Random.Range(0, pos_num)].transform.position + new Vector3(Random.Range(-4, 5), 0f, 0f), base.transform.rotation);
			}
		}
		regen_time_r1 = 0f;
	}
}
