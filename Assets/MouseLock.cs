using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
	void Update()
	{
		if (PCControls.OnPC)
		{
			if (Input.GetKeyDown(KeyCode.F1))
			{
				PCControls.CursorLocked = !PCControls.CursorLocked;
			}
		}
	}
}
