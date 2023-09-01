using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_New : MonoBehaviour
{
	public UILabel bullet_text;

	public UILabel[] BulletText_Bot = new UILabel[3];

	public GameObject thisob;

	private CharacterController controller;

	public Texture redimg;

	public static int hp;

	private int max_hp;

	public UISlider hpbar;

	public UILabel hp_text;

	private bool redimgtrue;

	public GameObject bomb_ob;

	public GameObject bomb_pos;

	public GameObject cam_rot;

	public AudioClip sfx_gold;

	public AudioClip sfx_throw;

	public AudioClip sfx_hited;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		hp = 100 + Singleton<DataManager>.Instance.gameData.Upgrade_Lv[2] * 20;
		max_hp = hp;
		redimgtrue = false;
	}

	private void Update()
	{
		SETUI();
		if (hp <= 0)
		{
			MainGameScript.game_state = 9;
		}
		if (PCControls.OnPC)
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				bomb();
			}
		}
	}

	private void SETUI()
	{
		MSPFps component = thisob.GetComponent<MSPFps>();
		if (MainGameScript.gunnumber_ != 0)
		{
			bullet_text.text = string.Empty + component.CurrentWeapon.bulletinMagasine + "/" + component.CurrentWeapon.NbClip * (float)component.CurrentWeapon.bulletperClip;
		}
		else
		{
			bullet_text.text = string.Empty + component.CurrentWeapon.bulletinMagasine + string.Empty;
		}
		BulletText_Bot[0].text = "UNLIMIT";
		BulletText_Bot[1].text = string.Empty + component.WeaponList[1].bulletinMagasine + "/" + component.WeaponList[1].NbClip * (float)component.WeaponList[1].bulletperClip;
		BulletText_Bot[2].text = string.Empty + component.WeaponList[2].bulletinMagasine + "/" + component.WeaponList[2].NbClip * (float)component.WeaponList[2].bulletperClip;
		hpbar.value = (float)hp / (float)max_hp;
		hp_text.text = hp + "/" + max_hp;
	}

	private void damaged(int damage)
	{
		hp -= damage;
		GetComponent<AudioSource>().PlayOneShot(sfx_hited);
		StartCoroutine("damage_img");
		GameObject.Find("Cam").GetComponent<Animator>().SetTrigger("HIT");
		if (hp <= 0 && MainGameScript.game_state == 0)
		{
			MainGameScript.game_state = 9;
		}
	}

	private IEnumerator damage_img()
	{
		redimgtrue = true;
		yield return new WaitForSeconds(0.2f);
		redimgtrue = false;
	}

	private void bomb()
	{
		if (MainGameScript.bomb_num > 0)
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_throw);
			Object.Instantiate(bomb_ob, bomb_pos.transform.position, cam_rot.transform.rotation);
			MainGameScript.bomb_num--;
		}
	}

	private void OnGUI()
	{
		if (redimgtrue)
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), redimg);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "gold")
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_gold);
			MainGameScript.gold++;
			Object.Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "diebox")
		{
			damaged(99999);
		}
	}
}
