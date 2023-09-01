using UnityEngine;

public class _SingleTon_Main : MonoBehaviour
{
	private void Start()
	{
		Object.DontDestroyOnLoad(this);
	}
}
