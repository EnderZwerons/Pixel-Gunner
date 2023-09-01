using System.Collections;
using UnityEngine;

public class Enemy_Control : MonoBehaviour
{
	public enum STATE_MON
	{
		SEARCH,
		ATTACK,
		DEATH,
		IDLE
	}

	public Animator playerani;

	public float speed;

	public int hp;

	public float at_interval;

	private float at_interval_pre;

	public GameObject OB;

	public float activedist;

	public float attackdist;

	public GameObject bim;

	public GameObject bim_pos;

	public int goldnum;

	public GameObject goldob;

	public GameObject bloodob;

	public STATE_MON state;

	private Transform target;

	private float dist;

	private UnityEngine.AI.NavMeshAgent navMeshAgent;

	public Collider col;

	public GameObject rgbob;

	public AudioClip sfx_die;

	public GameObject Item_ob;

	public int Item_Persent;

	private void Start()
	{
		at_interval_pre = 0f;
		target = GameObject.Find("PlayerTarget").transform;
		navMeshAgent = base.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	private void Update()
	{
		dist = Vector3.Distance(base.transform.position, target.position);
		at_interval_pre += Time.deltaTime;
		switch (state)
		{
		case STATE_MON.IDLE:
			idle();
			break;
		case STATE_MON.SEARCH:
			search();
			break;
		case STATE_MON.ATTACK:
			if (MainGameScript.game_state == 0)
			{
				StartCoroutine("attack");
			}
			break;
		case STATE_MON.DEATH:
			death();
			break;
		}
	}

	private IEnumerator attack()
	{
		if (at_interval_pre >= at_interval)
		{
			navMeshAgent.destination = base.gameObject.transform.position;
			base.transform.LookAt(new Vector3(target.transform.position.x, base.transform.position.y, target.position.z), Vector3.up);
			at_interval_pre = 0f;
			playerani.SetBool("attack", true);
			yield return new WaitForSeconds(0.6f);
			if (state != STATE_MON.DEATH)
			{
				base.transform.LookAt(new Vector3(base.transform.position.x, base.transform.position.y, target.position.z), Vector3.up);
				Object.Instantiate(bim, bim_pos.transform.position, bim_pos.transform.rotation);
				playerani.SetBool("attack", false);
				state = STATE_MON.SEARCH;
			}
		}
		else
		{
			base.transform.LookAt(new Vector3(target.transform.position.x, base.transform.position.y, target.position.z), Vector3.up);
		}
	}

	private void idle()
	{
		if (dist <= activedist)
		{
			playerani.SetBool("idle", false);
			playerani.SetBool("run", true);
			state = STATE_MON.SEARCH;
		}
		else
		{
			playerani.SetBool("idle", true);
			playerani.SetBool("run", false);
		}
	}

	private void search()
	{
		if (dist >= attackdist)
		{
			navMeshAgent.destination = target.position;
			return;
		}
		state = STATE_MON.ATTACK;
		navMeshAgent.destination = base.gameObject.transform.position;
	}

	private void death()
	{
		playerani.SetBool("death", true);
		navMeshAgent.destination = base.gameObject.transform.position;
	}

	private void Hit(int damage)
	{
		if (state == STATE_MON.IDLE)
		{
			playerani.SetBool("idle", false);
			playerani.SetBool("run", true);
			state = STATE_MON.SEARCH;
		}
		hp -= damage;
		if (hp <= 0)
		{
			Object.Destroy(base.gameObject, 6f);
			int num = Random.Range(0, 100);
			if (Item_Persent + 3 > num)
			{
				Object.Instantiate(Item_ob, base.gameObject.transform.position, base.transform.rotation);
			}
			base.gameObject.SendMessage("Die_Shader");
			if (state != STATE_MON.DEATH)
			{
				for (int i = 0; i < goldnum; i++)
				{
					Object.Instantiate(goldob, base.gameObject.transform.position, base.transform.rotation);
				}
				for (int j = 0; j < 7; j++)
				{
					Object.Instantiate(bloodob, base.gameObject.transform.position, base.transform.rotation);
				}
				MainGameScript.killedmon++;
				GetComponent<AudioSource>().PlayOneShot(sfx_die);
				Object.Destroy(col);
			}
			state = STATE_MON.DEATH;
		}
		StartCoroutine("Damaged_RGB");
	}

	private IEnumerator Damaged_RGB()
	{
		rgbob.GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.2f);
		rgbob.GetComponent<Renderer>().material.color = Color.white;
	}
}
