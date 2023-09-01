using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MSPFps : MonoBehaviour
{
	public enum RotateC
	{
		Classic,
		Accelerometer,
		gyroscope
	}

	private enum GUIComponent
	{
		Health,
		Bullet,
		Clip,
		Init
	}

	[Serializable]
	public class WeaponClass
	{
		public bool firearms;

		public float fireRate;

		public int bulletperClip;

		public int WeaponPower;

		public Renderer Muzzle;

		public AudioClip[] shootSound;

		public AudioClip reloadSound;

		public Texture[] WeaponBulletGUI;

		public GameObject pos_fire;

		public GameObject weapon_cam;

		public GameObject footstep;

		public int MaxNbrClip;

		[NonSerialized]
		public float NbClip;

		[NonSerialized]
		public int bulletleft;

		[NonSerialized]
		public float nextFireTime;

		[NonSerialized]
		public float bulletinMagasine;

		[NonSerialized]
		public Vector3 AimPosition = new Vector3
		{
			x = -0.1615f,
			y = -0.044f,
			z = -0.45f
		};

		public float AimAngle = 358.5694f;
	}

	public RotateC RotateControl;

	public float AccelerometerSensibility = 1.5f;

	public float AccelAngleCorrector = 135f;

	public float GyroSmooth = 0.1f;

	[SerializeField]
	public MSP MSPControl = new MSP();

	public GameObject[] Sparkle;

	public Transform AxeArms;

	public Transform PlayerCam;

	public float Sensitivity = 1.5f;

	private Vector3 moveDirection = Vector3.zero;

	public float speed = 10f;

	public float gravity = 8f;

	private CharacterController controller;

	private float rotationY;

	private float rotationX;

	private float sensitivityX = 2000f;

	private float sensitivityY = 900f;

	private float minimumY = -60f;

	private float maximumY = 60f;

	private float originalRotation;

	private Transform myTransform;

	private int Health;

	private int BulletGUI;

	private RaycastHit hit;

	private float AxeXPos;

	private float AxeYPos;

	private float AxeZPos;

	private float AxeYCoef;

	private float ZsmoothVal = 8f;

	private float GUIPosX;

	private float GUIPosXMax;

	private float GUIPosY;

	private float GUIPosYMax;

	private float GUIPosY2;

	private float GUIPosY2Max;

	private float InputX;

	private float InputY;

	private float MaxHealth;

	private float MaxClip;

	public Renderer Weapon1R;

	public Renderer Weapon2R;

	public Renderer Arm1R;

	public Renderer Arm2R;

	private float Inclin;

	public float TimeBeforeHitAgain = 2f;

	private float TBHA;

	private float RotateCoef;

	public WeaponClass CurrentWeapon;

	[SerializeField]
	public WeaponClass[] WeaponList;

	public LayerMask collisionLayers = -1;

	private int muzzleRotate = 45;

	private bool reload;

	private Transform Fakecam;

	public static MSPFps instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		speed = 10f + (float)Singleton<DataManager>.Instance.gameData.Upgrade_Lv[0] * 0.5f;
		if (RotateControl == RotateC.Accelerometer)
		{
			MSPControl.AccelGyroCtrl = MSP.GyroAccel.Accelero;
		}
		else if (RotateControl == RotateC.gyroscope && SystemInfo.supportsGyroscope)
		{
			MSPControl.AccelGyroCtrl = MSP.GyroAccel.Gyro;
			GameObject gameObject = new GameObject("FakeCam4Gyro");
			Fakecam = gameObject.transform;
			Transform parent = Fakecam.parent;
			GameObject gameObject2 = new GameObject("camParent");
			gameObject2.transform.position = Fakecam.position;
			Fakecam.parent = gameObject2.transform;
			GameObject gameObject3 = new GameObject("camGrandParent");
			gameObject3.transform.position = Fakecam.position;
			gameObject2.transform.parent = gameObject3.transform;
			gameObject3.transform.parent = parent;
			gameObject2.transform.eulerAngles = new Vector3(90f, 90f, 0f);
		}
		else
		{
			RotateControl = RotateC.Classic;
		}
		Screen.sleepTimeout = -1;
		MSPControl.InitControl();
		controller = GetComponent<CharacterController>();
		originalRotation = base.transform.rotation.eulerAngles.y;
		myTransform = base.transform;
		CurrentWeapon = WeaponList[0];
		MaxHealth = (Health = MSPControl.LifeCounterGUI.Length);
		CurrentWeapon.NbClip = CurrentWeapon.MaxNbrClip;
		CurrentWeapon.bulletleft = (int)CurrentWeapon.NbClip * CurrentWeapon.bulletperClip;
		GUIPosXMax = 1.5f * MSPControl.ScreenSize.x / 100f;
		GUIPosYMax = 1.2f * MSPControl.ScreenSize.y / 100f;
		GUIPosY2Max = 6.6f * MSPControl.ScreenSize.y / 100f;
		CurrentWeapon.bulletinMagasine = CurrentWeapon.bulletperClip;
		CurrentWeapon.bulletinMagasine = PlayerPrefs.GetInt("ammo");
	}

	public void ChangeCurrentWeapon(int changeweaponnumber)
	{
		CurrentWeapon = WeaponList[changeweaponnumber];
		CurrentWeapon.bulletleft = (int)CurrentWeapon.NbClip * CurrentWeapon.bulletperClip;
	}

	private void Update()
	{
		if (MainGameScript.game_state == 0)
		{
			MSPControl.Command();
			MovePlayer();
			switch (RotateControl)
			{
			case RotateC.Classic:
				RotatePlayer();
				break;
			case RotateC.Accelerometer:
				RotatePlayerbyAccelerometer();
				break;
			case RotateC.gyroscope:
				RotatePlayerbyGyroscope();
				break;
			}
			OthersPlayerControl();
		}
		Sensitivity = MainGameScript.sensity;
		if (MSPControl.Window1InputPad.x != 0f || MSPControl.Window1InputPad.y != 0f)
		{
			CurrentWeapon.footstep.SetActive(true);
		}
		else
		{
			CurrentWeapon.footstep.SetActive(false);
		}
	}

	private void RotatePlayerbyGyroscope()
	{
		Fakecam.localRotation = Quaternion.Slerp(Fakecam.localRotation, MSPControl.GyroCoord, GyroSmooth);
		base.transform.rotation = Quaternion.Euler(0f, Fakecam.eulerAngles.y, 0f);
		PlayerCam.localRotation = Quaternion.Euler(Fakecam.eulerAngles.x, 0f, 0f);
	}

	private void RotatePlayerbyAccelerometer()
	{
		float num = AccelAngleCorrector / 270f;
		InputX = 0f - MSPControl.Acceleration.y;
		InputY = 0f - (num + MSPControl.Acceleration.x);
		rotationX += InputX * RotateCoef * AccelerometerSensibility;
		rotationY += InputY * RotateCoef * AccelerometerSensibility;
		rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.Euler(0f, originalRotation + rotationX, 0f), 0.1f);
		PlayerCam.localRotation = Quaternion.Slerp(PlayerCam.localRotation, Quaternion.Euler(PlayerCam.localRotation.x - rotationY, 0f, 0f), 0.1f);
	}

	private void RotatePlayer()
	{
		if (!PCControls.OnPC)
		{
			InputX = MSPControl.Window2InputSlide.x * (sensitivityX * Sensitivity * 0.01f) / MSPControl.DPI;
			InputY = MSPControl.Window2InputSlide.y * (sensitivityY * Sensitivity * 0.01f) / MSPControl.DPI;
		}
		else if (PCControls.CursorLocked)
		{
			InputX = Input.GetAxis("Mouse X") * (sensitivityX * Sensitivity * 0.0005f);
			InputY = Input.GetAxis("Mouse Y") * (sensitivityY * Sensitivity * 0.0005f);
		}
		rotationX += InputX * RotateCoef;
		rotationY += InputY * RotateCoef;
		rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.Euler(0f, originalRotation + rotationX, 0f), 0.1f);
		PlayerCam.localRotation = Quaternion.Slerp(PlayerCam.localRotation, Quaternion.Euler(PlayerCam.localRotation.x - rotationY, 0f, 0f), 0.1f);
	}

	private void MovePlayer()
	{
		if (!PCControls.OnPC)
		{
			float num = ((MSPControl.Window1InputPad.x == 0f || MSPControl.Window1InputPad.y == 0f) ? 1f : 0.7071f);
			moveDirection = myTransform.TransformDirection(new Vector3(MSPControl.Window1InputPad.x * num, 0f, MSPControl.Window1InputPad.y * num));
		}
		else
		{
			Vector2 move = new Vector2(Input.GetKey("d") ? -1 : Input.GetKey("a") ? 1 : 0, Input.GetKey("w") ? -1 : Input.GetKey("s") ? 1 : 0);
			if (move.magnitude > 1)
			{
				move /= move.magnitude;
			}
			moveDirection = myTransform.TransformDirection(-move.x, 0f, -move.y);
		}
		moveDirection *= speed;
		moveDirection.y -= gravity;
		controller.Move(moveDirection * Time.smoothDeltaTime);
	}

	private void OthersPlayerControl()
	{
		Ray ray = PlayerCam.GetComponent<Camera>().ScreenPointToRay(new Vector3(MSPControl.HalfScreen.x + MSPControl.HUDPosition.x, MSPControl.HalfScreen.y - MSPControl.HUDPosition.y, 0f));
		Physics.Raycast(ray, out hit, 1000f, collisionLayers.value);
		if ((!PCControls.OnPC && MSPControl.WindowFireBtnPressed) || (PCControls.OnPC && Input.GetMouseButton(0)) && CurrentWeapon.bulletinMagasine > 0f)
		{
			Shoot();
		}
		else if ((bool)CurrentWeapon.Muzzle && CurrentWeapon.Muzzle.enabled)
		{
			CurrentWeapon.Muzzle.enabled = false;
			AxeZPos = (GUIPosY2 = (AxeYPos = 0f));
		}
		if (CurrentWeapon.bulletinMagasine == 0f && !reload && CurrentWeapon.firearms && CurrentWeapon.bulletleft > 0)
		{
			MSPControl.AimPos = false;
			StartCoroutine(Reload());
		}
		SlideGUIandArms();
		if (MSPControl.WeaponTouchPurcentDist > 30f && MSPControl.WeaponActionEnded && !reload && !MSPControl.AimPos)
		{
			Inclin = 30f;
			WeaponButtonControl();
			MSPControl.WeaponTouchDiff = 0f;
			MSPControl.WeaponTouchPurcentDist = 0f;
			MSPControl.WeaponActionEnded = false;
		}
		else if ((!PCControls.OnPC && MSPControl.WeaponTouchPurcentDist < 30f && MSPControl.WeaponActionEnded) || (PCControls.OnPC && Input.GetKeyDown(KeyCode.R)) && !reload)
		{
			if (CurrentWeapon.firearms && CurrentWeapon.bulletleft > 0)
			{
				MSPControl.AimPos = false;
				StartCoroutine(Reload());
			}
			MSPControl.WeaponTouchDiff = 0f;
			MSPControl.WeaponTouchPurcentDist = 0f;
			MSPControl.WeaponActionEnded = false;
		}
		else if (MSPControl.WeaponActionEnded)
		{
			MSPControl.WeaponTouchDiff = 0f;
			MSPControl.WeaponTouchPurcentDist = 0f;
			MSPControl.WeaponActionEnded = false;
		}
		if (!CurrentWeapon.firearms && MSPControl.AimPos)
		{
			MSPControl.AimPos = !MSPControl.AimPos;
		}
		if (TBHA > 0f)
		{
			TBHA -= Time.deltaTime;
		}
		else if (TBHA < 0f)
		{
			TBHA = 0f;
		}
		if (AxeArms.localRotation == Quaternion.Euler(30f, 0f, 0f))
		{
			if (CurrentWeapon == WeaponList[0])
			{
				Weapon1R.enabled = true;
				Weapon2R.enabled = false;
				Arm1R.enabled = true;
			}
			else
			{
				Weapon1R.enabled = false;
				Weapon2R.enabled = true;
				Arm1R.enabled = false;
			}
			Inclin = 0f;
		}
	}

	private void OnGUI()
	{
		if (MainGameScript.game_state == 0)
		{
			MSPControl.OnGUIComponents();
		}
	}

	private void Shoot()
	{
		if (!CurrentWeapon.firearms)
		{
			return;
		}
		if (Time.time > CurrentWeapon.nextFireTime + CurrentWeapon.fireRate)
		{
			CurrentWeapon.bulletinMagasine -= 1f;
			ZsmoothVal = 10f;
			AxeYPos = 0.04f;
			GUIPosY2 = GUIPosY2Max;
			AxeZPos = -0.1f;
			int num = Singleton<DataManager>.Instance.gameData.InventoryWeapon[MainGameScript.gunnumber_];
			GetComponent<AudioSource>().PlayOneShot(CurrentWeapon.shootSound[num]);
			Game_AutoFire.instance.aimani.Play("ANI_FIRE", PlayMode.StopAll);
			switch (Weapon_Data_.instance.WCD[num].WEAPON_TYPE)
			{
			case Weapon_Data_.WeaponType_Gun.NORMAL:
				if ((bool)hit.collider)
				{
					hit.collider.SendMessage("Hit", CurrentWeapon.WeaponPower, SendMessageOptions.DontRequireReceiver);
					if (hit.collider.tag == "ground")
					{
						UnityEngine.Object.Instantiate(Game_ObManager.instance.OB_EFFECT[1], hit.point, Quaternion.identity);
					}
					if (hit.collider.tag == "Enemy")
					{
						UnityEngine.Object.Instantiate(Game_ObManager.instance.OB_EFFECT[0], hit.point, Quaternion.identity);
					}
					if (hit.collider.tag == "Enemy_bim")
					{
						UnityEngine.Object.Instantiate(Game_ObManager.instance.OB_EFFECT[1], hit.point, Quaternion.identity);
					}
				}
				break;
			case Weapon_Data_.WeaponType_Gun.BASUKA:
				UnityEngine.Object.Instantiate(Game_ObManager.instance.OB_BULLET[num], CurrentWeapon.pos_fire.transform.position, CurrentWeapon.weapon_cam.transform.rotation);
				break;
			}
			UpdateGUI(GUIComponent.Bullet);
			if ((bool)CurrentWeapon.Muzzle)
			{
				CurrentWeapon.Muzzle.enabled = true;
			}
			muzzleRotate += 90;
			CurrentWeapon.Muzzle.gameObject.transform.localRotation = Quaternion.AngleAxis(muzzleRotate, Vector3.forward);
			CurrentWeapon.nextFireTime = Time.time;
		}
		else
		{
			if ((bool)CurrentWeapon.Muzzle)
			{
				CurrentWeapon.Muzzle.enabled = false;
			}
			GUIPosY2 = (AxeYPos = 0f);
			AxeZPos = 0f;
			ZsmoothVal = 8f;
		}
	}

	private IEnumerator Reload()
	{
		if (reload)
		{
			yield break;
		}
		reload = true;
		Inclin = 7.5f;
		if (CurrentWeapon.bulletinMagasine < (float)CurrentWeapon.bulletperClip)
		{
			GetComponent<AudioSource>().PlayOneShot(CurrentWeapon.reloadSound);
			CurrentWeapon.bulletleft += (int)CurrentWeapon.bulletinMagasine;
			CurrentWeapon.bulletinMagasine = 0f;
			if (CurrentWeapon.bulletleft > CurrentWeapon.bulletperClip)
			{
				yield return new WaitForSeconds(2f);
				CurrentWeapon.bulletinMagasine = CurrentWeapon.bulletperClip;
				CurrentWeapon.bulletleft -= CurrentWeapon.bulletperClip;
			}
			else
			{
				yield return new WaitForSeconds(2f);
				CurrentWeapon.bulletinMagasine = CurrentWeapon.bulletleft;
				CurrentWeapon.bulletleft = 0;
			}
			CurrentWeapon.NbClip = (float)CurrentWeapon.bulletleft / (float)CurrentWeapon.bulletperClip;
			UpdateGUI(GUIComponent.Clip);
		}
		reload = false;
		UpdateGUI(GUIComponent.Bullet);
		Inclin = 0f;
	}

	private void WeaponButtonControl()
	{
		if (CurrentWeapon == WeaponList[0])
		{
			CurrentWeapon = WeaponList[1];
			MSPControl.HideCrossHair = true;
		}
		else if (CurrentWeapon == WeaponList[1])
		{
			CurrentWeapon = WeaponList[0];
			MSPControl.HideCrossHair = false;
			UpdateGUI(GUIComponent.Clip);
		}
	}

	public void Hit(int power)
	{
		if (Health > 1 && TBHA == 0f)
		{
			Health -= power;
			UpdateGUI(GUIComponent.Health);
			TBHA = TimeBeforeHitAgain;
		}
	}

	private void UpdateGUI(GUIComponent GUICpnt)
	{
	}

	private void SlideGUIandArms()
	{
		if (InputX < -1.5f && AxeArms.localPosition.x > -0.02f)
		{
			AxeXPos = -0.02f;
			GUIPosX = 0f - GUIPosXMax;
		}
		else if (InputX > 1.5f && AxeArms.localPosition.x < 0.02f)
		{
			AxeXPos = 0.02f;
			GUIPosX = GUIPosXMax;
		}
		else if (InputX == 0f && (AxeArms.localPosition.x > 0.019f || AxeArms.localPosition.x < -0.019f))
		{
			GUIPosX = (AxeXPos = 0f);
		}
		if (InputY < -1f && AxeArms.localPosition.y > -0.009f)
		{
			AxeYCoef = 0.009f;
			GUIPosY = GUIPosYMax;
		}
		else if (InputY > 1f && AxeArms.localPosition.y < 0.009f)
		{
			AxeYCoef = -0.009f;
			GUIPosY = 0f - GUIPosYMax;
		}
		else if (InputY == 0f && (AxeArms.localPosition.y > 0.008f || AxeArms.localPosition.y < -0.008f))
		{
			GUIPosY = (AxeYCoef = 0f);
		}
		if (!MSPControl.AimPos)
		{
			if (PlayerCam.GetComponent<Camera>().fieldOfView < 42f)
			{
				PlayerCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(PlayerCam.GetComponent<Camera>().fieldOfView, 42f, 0.1f);
			}
			AxeArms.localPosition = Vector3.Lerp(AxeArms.localPosition, new Vector3(AxeXPos, AxeYPos + AxeYCoef, AxeZPos), Time.deltaTime * ZsmoothVal);
			MSPControl.HUDPosition = Vector2.Lerp(MSPControl.HUDPosition, new Vector2(GUIPosX, 0f - GUIPosY2 + GUIPosY), Time.deltaTime * 4f);
			AxeArms.localRotation = Quaternion.Slerp(AxeArms.localRotation, Quaternion.Euler(Inclin, 0f, 0f), 0.1f);
			RotateCoef = 1f;
			if (MSPControl.HideCrossHair && CurrentWeapon.firearms)
			{
				MSPControl.HideCrossHair = !MSPControl.HideCrossHair;
			}
		}
		else if (MSPControl.AimPos && !reload && CurrentWeapon.firearms)
		{
			if (PlayerCam.GetComponent<Camera>().fieldOfView > 34f)
			{
				PlayerCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(PlayerCam.GetComponent<Camera>().fieldOfView, 34f, 0.1f);
			}
			AxeArms.localPosition = Vector3.Lerp(AxeArms.localPosition, new Vector3(CurrentWeapon.AimPosition.x, AxeYPos + CurrentWeapon.AimPosition.y, AxeZPos / 2f + CurrentWeapon.AimPosition.z), Time.deltaTime * ZsmoothVal);
			MSPControl.HUDPosition = Vector2.Lerp(MSPControl.HUDPosition, Vector2.zero, Time.deltaTime * 4f);
			AxeArms.localRotation = Quaternion.Slerp(AxeArms.localRotation, Quaternion.Euler(CurrentWeapon.AimAngle, 0f, 0f), 0.1f);
			RotateCoef = 0.5f;
			if (!MSPControl.HideCrossHair)
			{
				MSPControl.HideCrossHair = !MSPControl.HideCrossHair;
			}
		}
	}

	private void OnTriggerEnter(Collider Obj)
	{
		if (Obj.tag == "HealthUp")
		{
			int num = Health + 10;
			if ((float)num > MaxHealth)
			{
				Health = (int)Mathf.Round(MaxHealth);
			}
			else
			{
				Health = num;
			}
			UpdateGUI(GUIComponent.Health);
			UnityEngine.Object.Destroy(Obj.gameObject);
		}
		else if (Obj.tag == "BulletUp" && Mathf.CeilToInt(CurrentWeapon.NbClip) < CurrentWeapon.MaxNbrClip)
		{
			CurrentWeapon.NbClip += 1f;
			CurrentWeapon.bulletleft += CurrentWeapon.bulletperClip;
			UpdateGUI(GUIComponent.Clip);
		}
	}

	private void shoot_make()
	{
		MSPControl.WindowFireBtnPressed = true;
	}

	private void shoot_out()
	{
		MSPControl.WindowFireBtnPressed = false;
	}
}
