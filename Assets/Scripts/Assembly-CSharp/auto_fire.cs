using UnityEngine;

public class auto_fire : MonoBehaviour
{
	public GameObject playerob;

	private bool attacking;

	public UISprite AIM_IMG;

	public Vector2 posvec2;

	public Camera maincam;

	private void Start()
	{
		attacking = false;
		posvec2 = new Vector2(Screen.width / 2, Screen.height / 2);
	}

	private void Update()
	{
		if (Game.game_state == 0 && PlayerPrefs.GetInt("autofire") == 1)
		{
			if (attacking)
			{
				playerob.SendMessage("shoot_make");
			}
			AutoFire_Function();
		}
	}

	private void AutoFire_Function()
	{
		Ray ray = maincam.ScreenPointToRay(posvec2);
		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo, 9999f))
		{
			if (hitInfo.collider.gameObject.tag.Equals("Enemy") || hitInfo.collider.gameObject.tag.Equals("Enemy_bim"))
			{
				AIM_IMG.color = Color.red;
				attacking = true;
			}
			else
			{
				AIM_IMG.color = Color.white;
				attacking = false;
				playerob.SendMessage("shoot_out");
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy")
		{
			AIM_IMG.color = Color.red;
			attacking = true;
		}
		else
		{
			AIM_IMG.color = Color.white;
			attacking = false;
			playerob.SendMessage("shoot_out");
		}
	}
}
