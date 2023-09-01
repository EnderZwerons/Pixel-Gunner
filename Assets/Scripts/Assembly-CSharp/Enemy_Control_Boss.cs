using System;
using System.Collections;
using UnityEngine;

public class Enemy_Control_Boss : MonoBehaviour
{
	public enum STATE_MON
	{
		SEARCH,
		ATTACK,
		DEATH,
		IDLE,
		WAIT
	}

	public enum STATE_PHASE
	{
		P0,
		P1,
		P2
	}

	[Serializable]
	public class PhaseAbilty
	{
		public float p_speed;

		public float p_at_interval;

		public float p_at_waittime;

		public float p_activedist;

		public float p_attackdist;

		public GameObject p_bim;
	}

	public Animator playerani;

	public float speed;

	public int hp;

	private int max_hp;

	public float at_interval;

	public float at_waittime;

	public float at_aftertime;

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

	public STATE_PHASE phase;

	public PhaseAbilty[] Phase_Ability;

	private Transform target;

	private float dist;

	private UnityEngine.AI.NavMeshAgent navMeshAgent;

	private Collider col;

	public GameObject rgbob;

	public GameObject[] rgbob_New;

	public AudioClip sfx_die;

	public GameObject Item_ob;

	public int Item_Persent;

	public bool ATTACKING;

	public GameObject HPBAR;

	public GameObject HPBAR_IN;

	private void OnGUI()
	{
	}

	private void SETHPBAR()
	{
		int num = hp * 100 / max_hp;
		HPBAR_IN.transform.localScale = new Vector3((float)num * 0.01f, 1f, 1f);
	}

	private void Start()
	{
		at_interval_pre = 0f;
		max_hp = hp;
		SETHPBAR();
		target = GameObject.Find("PlayerTarget").transform;
		col = base.gameObject.GetComponent<Collider>();
		navMeshAgent = base.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
		navMeshAgent.speed = speed;
		ATTACKING = false;
		StartCoroutine("STARTBOSS");
	}

	private IEnumerator STARTBOSS()
	{
		yield return new WaitForSeconds(5f);
		activedist = 100f;
	}

	private void Check_Phase()
	{
		float num = (float)hp / (float)max_hp;
		if (num <= 0.6f && num > 0.3f && phase == STATE_PHASE.P0)
		{
			phase = STATE_PHASE.P1;
			playerani.speed = 1.5f;
			SetAbilityChange();
		}
		else if (num <= 0.3f && num > 0f && phase == STATE_PHASE.P1)
		{
			phase = STATE_PHASE.P2;
			playerani.speed = 2.2f;
			SetAbilityChange();
		}
	}

	private void SetAbilityChange()
	{
		switch (phase)
		{
		case STATE_PHASE.P1:
			speed = Phase_Ability[0].p_speed;
			navMeshAgent.speed = speed;
			at_interval = Phase_Ability[0].p_at_interval;
			at_waittime = Phase_Ability[0].p_at_waittime;
			activedist = Phase_Ability[0].p_activedist;
			attackdist = Phase_Ability[0].p_attackdist;
			bim = Phase_Ability[0].p_bim;
			break;
		case STATE_PHASE.P2:
			speed = Phase_Ability[1].p_speed;
			navMeshAgent.speed = speed;
			at_interval = Phase_Ability[1].p_at_interval;
			at_waittime = Phase_Ability[1].p_at_waittime;
			activedist = Phase_Ability[1].p_activedist;
			attackdist = Phase_Ability[1].p_attackdist;
			bim = Phase_Ability[1].p_bim;
			break;
		}
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
		case STATE_MON.WAIT:
			break;
		}
	}

	private IEnumerator attack()
	{
		if (at_interval_pre >= at_interval && !ATTACKING)
		{
			ATTACKING = true;
			navMeshAgent.destination = base.gameObject.transform.position;
			base.transform.LookAt(new Vector3(target.transform.position.x, base.transform.position.y, target.position.z), Vector3.up);
			playerani.SetBool("attack", true);
			yield return new WaitForSeconds(at_waittime);
			if (state != STATE_MON.DEATH)
			{
				UnityEngine.Object.Instantiate(bim, bim_pos.transform.position, bim_pos.transform.rotation);
				playerani.SetBool("attack", false);
				state = STATE_MON.WAIT;
				playerani.SetBool("idle", true);
				playerani.SetBool("run", false);
			}
			yield return new WaitForSeconds(at_aftertime);
			at_interval_pre = 0f;
			ATTACKING = false;
			if (state != STATE_MON.DEATH)
			{
				state = STATE_MON.IDLE;
			}
		}
	}

	private void idle()
	{
		if (dist <= activedist)
		{
			playerani.SetBool("idle", true);
			playerani.SetBool("run", false);
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
			playerani.SetBool("idle", false);
			playerani.SetBool("run", true);
			navMeshAgent.destination = target.position;
		}
		else
		{
			state = STATE_MON.ATTACK;
			navMeshAgent.destination = base.gameObject.transform.position;
		}
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
		SETHPBAR();
		Check_Phase();
		if (hp <= 0)
		{
			StartCoroutine("ENDBOSSMODE");
			int num = UnityEngine.Random.Range(0, 100);
			if (Item_Persent > num)
			{
				UnityEngine.Object.Instantiate(Item_ob, base.gameObject.transform.position, base.transform.rotation);
			}
			base.gameObject.SendMessage("Die_Shader");
			if (state != STATE_MON.DEATH)
			{
				for (int i = 0; i < goldnum; i++)
				{
					UnityEngine.Object.Instantiate(goldob, base.gameObject.transform.position, base.transform.rotation);
				}
				for (int j = 0; j < 10; j++)
				{
					UnityEngine.Object.Instantiate(bloodob, base.gameObject.transform.position, base.transform.rotation);
				}
				MainGameScript.killedmon++;
				GetComponent<AudioSource>().PlayOneShot(sfx_die);
				UnityEngine.Object.Destroy(col);
			}
			state = STATE_MON.DEATH;
		}
		StartCoroutine("Damaged_RGB");
	}

	private IEnumerator ENDBOSSMODE()
	{
		MainGameScript.game_state_2 = 1;
		yield return new WaitForSeconds(20f);
		Game.game_state = 9;
	}

	private IEnumerator Damaged_RGB()
	{
		rgbob.GetComponent<Renderer>().material.color = Color.red;
		for (int j = 0; j < rgbob_New.Length; j++)
		{
			rgbob_New[j].GetComponent<Renderer>().material.color = Color.red;
		}
		yield return new WaitForSeconds(0.2f);
		rgbob.GetComponent<Renderer>().material.color = Color.white;
		for (int i = 0; i < rgbob_New.Length; i++)
		{
			rgbob_New[i].GetComponent<Renderer>().material.color = Color.white;
		}
	}
}
