using UnityEngine;

public class UI_MOVE : MonoBehaviour
{
	public AnimationClip Animation_Move;

	private string Animation_Name;

	public float Animation_Speed;

	private void OnEnable()
	{
		if (Animation_Speed == 0f)
		{
			Animation_Speed = 1f;
		}
		Animation_Name = Animation_Move.name;
		GetComponent<Animation>()[Animation_Name].speed = Animation_Speed;
		GetComponent<Animation>().Play(Animation_Name, PlayMode.StopAll);
	}
}
