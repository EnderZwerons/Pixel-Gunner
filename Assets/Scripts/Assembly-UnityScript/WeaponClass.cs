using System;
using UnityEngine;

[Serializable]
public class WeaponClass
{
	public bool firearms;

	public float fireRate;

	public int bulletperClip;

	public int WeaponPower;

	public Renderer Muzzle;

	public AudioClip shootSound;

	public Texture[] WeaponBulletGUI;

	public int MaxNbrClip;

	public float NbClip;

	public int bulletleft;

	public float nextFireTime;

	public float bulletinMagasine;

	public Vector3 AimPosition;

	public float AimAngle;

	public WeaponClass()
	{
		AimPosition = new Vector3(-0.1615f, -0.044f, -0.45f);
		AimAngle = 358.5694f;
	}
}
