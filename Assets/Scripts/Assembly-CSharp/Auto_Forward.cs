using UnityEngine;

public class Auto_Forward : MonoBehaviour
{
	public Vector2 posvec2;

	public Camera maincam;

	private void Start()
	{
		posvec2 = new Vector2(Screen.width / 2, Screen.height / 2);
	}

	private void Update()
	{
		Ray ray = maincam.ScreenPointToRay(posvec2);
		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo, 9999f))
		{
			MonoBehaviour.print("ray");
			if (hitInfo.collider.gameObject.tag.Equals("Enemy"))
			{
				MonoBehaviour.print("sdds");
			}
		}
	}
}
