using UnityEngine;

public class Jump_Player : MonoBehaviour
{
	private bool jumping;

	public float jump_height;

	private float jump_add;

	private CharacterController controller;

	public AudioClip sfx_jump;

	private void Start()
	{
		jump_height = 0.5f;
		controller = GetComponent<CharacterController>();
		jumping = false;
	}

	private void Update()
	{
		if (PCControls.OnPC)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
		}
	}

	private void FixedUpdate()
	{
		if (jumping)
		{
			jump_add -= Time.deltaTime;
			if (jump_add >= 0f)
			{
				controller.Move(new Vector3(0f, jump_add, 0f));
			}
			else
			{
				jumping = false;
			}
		}
	}

	private void Jump()
	{
		if (controller.isGrounded)
		{
			GetComponent<AudioSource>().PlayOneShot(sfx_jump);
			jumping = true;
			jump_add = jump_height;
		}
	}
}
