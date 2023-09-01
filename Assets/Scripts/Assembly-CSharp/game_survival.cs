using UnityEngine;

public class game_survival : MonoBehaviour
{
	public GameObject[] regenpos;

	public static int monisexist;

	public int max_monexist;

	private int nowmon;

	public GameObject[] mon;

	public float maketime;

	private float maketime_s;

	private int nowmonnum;

	public float upregen;

	private float stream;

	private void Start()
	{
		monisexist = 0;
		maketime_s = 0f;
		stream = 0f;
		nowmonnum = 0;
	}

	private void Update()
	{
		nowmon = monisexist - MainGameScript.killedmon;
		if (MainGameScript.game_state == 0)
		{
			maketime_s += Time.deltaTime;
			stream += Time.deltaTime;
		}
		if (stream >= upregen && nowmonnum < mon.Length - 1)
		{
			nowmonnum++;
			stream = 0f;
		}
		if (maketime_s >= maketime && nowmon < max_monexist && MainGameScript.game_state_2 == 0)
		{
			makemon();
			maketime_s = 0f;
		}
	}

	private void makemon()
	{
		int num = Random.Range(0, regenpos.Length);
		switch (Random.Range(0, 4))
		{
		case 0:
			Object.Instantiate(mon[Random.Range(0, 3)], regenpos[num].transform.position, base.transform.rotation);
			break;
		case 1:
			Object.Instantiate(mon[0], regenpos[num].transform.position, base.transform.rotation);
			break;
		case 2:
			Object.Instantiate(mon[nowmonnum], regenpos[num].transform.position, base.transform.rotation);
			break;
		case 3:
			Object.Instantiate(mon[nowmonnum], regenpos[num].transform.position, base.transform.rotation);
			break;
		}
		monisexist++;
	}
}
