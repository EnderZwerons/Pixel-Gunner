using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class MSPFps_JS : MonoBehaviour
{
	public RotateC RotateControl;

	public float AccelerometerSensibility;

	public float AccelAngleCorrector;

	public float GyroSmooth;

	[SerializeField]
	public MSP MSPControl;

	public GameObject Sparkle;

	public Transform AxeArms;

	public Transform PlayerCam;

	public float Sensitivity;

	private Vector3 moveDirection;

	public float speed;

	public float gravity;

	private CharacterController controller;

	private float rotationY;

	private float rotationX;

	private float sensitivityX;

	private float sensitivityY;

	private float minimumY;

	private float maximumY;

	private float originalRotation;

	private Transform myTransform;

	private int Health;

	private int BulletGUI;

	private RaycastHit hit;

	private float AxeXPos;

	private float AxeYPos;

	private float AxeZPos;

	private float AxeYCoef;

	private float ZsmoothVal;

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

	public float TimeBeforeHitAgain;

	private float TBHA;

	private float RotateCoef;

	private WeaponClass CurrentWeapon;

	[SerializeField]
	public WeaponClass[] WeaponList;

	public LayerMask collisionLayers;

	private int muzzleRotate;

	private bool reload;

	public Transform Fakecam;

	public MSPFps_JS()
	{
		RotateControl = RotateC.Classic;
		AccelerometerSensibility = 1.5f;
		AccelAngleCorrector = 135f;
		GyroSmooth = 0.1f;
		MSPControl = new MSP();
		Sensitivity = 1.5f;
		moveDirection = Vector3.zero;
		speed = 10f;
		gravity = 8f;
		sensitivityX = 2000f;
		sensitivityY = 900f;
		minimumY = -60f;
		maximumY = 60f;
		ZsmoothVal = 8f;
		TimeBeforeHitAgain = 2f;
		collisionLayers = -1;
		muzzleRotate = 45;
	}

	public void Start()
	{
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
		controller = (CharacterController)GetComponent(typeof(CharacterController));
		originalRotation = transform.rotation.eulerAngles.y;
		myTransform = transform;
		CurrentWeapon = WeaponList[0];
		MaxHealth = (Health = MSPControl.LifeCounterGUI.Length);
		CurrentWeapon.NbClip = (CurrentWeapon.MaxNbrClip = CurrentWeapon.WeaponBulletGUI.Length - 1);
		CurrentWeapon.bulletleft = (int)(CurrentWeapon.NbClip * (float)CurrentWeapon.bulletperClip);
		GUIPosXMax = 1.5f * MSPControl.ScreenSize.x / 100f;
		GUIPosYMax = 1.2f * MSPControl.ScreenSize.y / 100f;
		GUIPosY2Max = 6.6f * MSPControl.ScreenSize.y / 100f;
		CurrentWeapon.bulletinMagasine = CurrentWeapon.bulletperClip;
		UpdateGUI(GUIComponent.Init);
	}

	public void Update()
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

	private void RotatePlayerbyGyroscope()
	{
		Fakecam.localRotation = Quaternion.Slerp(Fakecam.localRotation, MSPControl.GyroCoord, GyroSmooth);
		transform.rotation = Quaternion.Euler(0f, Fakecam.eulerAngles.y, 0f);
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
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, originalRotation + rotationX, 0f), 0.1f);
		PlayerCam.localRotation = Quaternion.Slerp(PlayerCam.localRotation, Quaternion.Euler(PlayerCam.localRotation.x - rotationY, 0f, 0f), 0.1f);
	}

	private void RotatePlayer()
	{
		InputX = MSPControl.Window2InputSlide.x * (sensitivityX * Sensitivity * 0.01f) / MSPControl.DPI;
		InputY = MSPControl.Window2InputSlide.y * (sensitivityY * Sensitivity * 0.01f) / MSPControl.DPI;
		rotationX += InputX * RotateCoef;
		rotationY += InputY * RotateCoef;
		rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, originalRotation + rotationX, 0f), 0.1f);
		PlayerCam.localRotation = Quaternion.Slerp(PlayerCam.localRotation, Quaternion.Euler(PlayerCam.localRotation.x - rotationY, 0f, 0f), 0.1f);
	}

	private void MovePlayer()
	{
		float num = ((MSPControl.Window1InputPad.x == 0f || MSPControl.Window1InputPad.y == 0f) ? 1f : 0.7071f);
		moveDirection = myTransform.TransformDirection(new Vector3(MSPControl.Window1InputPad.x * num, 0f, MSPControl.Window1InputPad.y * num));
		moveDirection *= speed;
		moveDirection.y -= gravity;
		controller.Move(moveDirection * Time.smoothDeltaTime);
	}

	private void OthersPlayerControl()
	{
		Ray ray = PlayerCam.GetComponent<Camera>().ScreenPointToRay(new Vector3(MSPControl.HalfScreen.x + MSPControl.HUDPosition.x, MSPControl.HalfScreen.y - MSPControl.HUDPosition.y, 0f));
		Physics.Raycast(ray, out hit, 1000f, collisionLayers.value);
		if (MSPControl.WindowFireBtnPressed && !(CurrentWeapon.bulletinMagasine <= 0f))
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
		if (!(MSPControl.WeaponTouchPurcentDist <= 30f) && MSPControl.WeaponActionEnded && !reload && !MSPControl.AimPos)
		{
			Inclin = 30f;
			WeaponButtonControl();
			MSPControl.WeaponTouchDiff = 0f;
			MSPControl.WeaponTouchPurcentDist = 0f;
			MSPControl.WeaponActionEnded = false;
		}
		else if (!(MSPControl.WeaponTouchPurcentDist >= 30f) && MSPControl.WeaponActionEnded && !reload)
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
		if (!(TBHA <= 0f))
		{
			TBHA -= Time.deltaTime;
		}
		else if (!(TBHA >= 0f))
		{
			TBHA = 0f;
		}
		if (AxeArms.localRotation == Quaternion.Euler(30f, 0f, 0f))
		{
			if (RuntimeServices.EqualityOperator(CurrentWeapon, WeaponList[0]))
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

	public void OnGUI()
	{
		MSPControl.OnGUIComponents();
	}

	private void Shoot()
	{
		if (!CurrentWeapon.firearms)
		{
			return;
		}
		if (!(Time.time <= CurrentWeapon.nextFireTime + CurrentWeapon.fireRate))
		{
			CurrentWeapon.bulletinMagasine -= 1f;
			ZsmoothVal = 10f;
			AxeYPos = 0.04f;
			GUIPosY2 = GUIPosY2Max;
			AxeZPos = -0.1f;
			if ((bool)hit.collider)
			{
				hit.collider.SendMessage("Hit", CurrentWeapon.WeaponPower, SendMessageOptions.DontRequireReceiver);
				UnityEngine.Object.Instantiate(Sparkle, hit.point, Quaternion.identity);
			}
			UpdateGUI(GUIComponent.Bullet);
			if ((bool)CurrentWeapon.Muzzle)
			{
				CurrentWeapon.Muzzle.enabled = true;
			}
			GetComponent<AudioSource>().PlayOneShot(CurrentWeapon.shootSound);
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

	public IEnumerator Reload()
	{
		yield break;
	}

	public void WeaponButtonControl()
	{
		if (RuntimeServices.EqualityOperator(CurrentWeapon, WeaponList[0]))
		{
			CurrentWeapon = WeaponList[1];
			MSPControl.HideCrossHair = true;
			MSPControl.GUIObject.WeaponGUI = CurrentWeapon.WeaponBulletGUI.GetValue(0) as Texture;
		}
		else if (RuntimeServices.EqualityOperator(CurrentWeapon, WeaponList[1]))
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
		switch (GUICpnt)
		{
		case GUIComponent.Init:
			MSPControl.GUIObject.LifeGUI = MSPControl.LifeCounterGUI.GetValue(Health - 1) as Texture;
			MSPControl.GUIObject.CrossHairGui = MSPControl.CrossHairGUI.GetValue(10) as Texture;
			MSPControl.GUIObject.WeaponGUI = CurrentWeapon.WeaponBulletGUI.GetValue(Mathf.CeilToInt(CurrentWeapon.NbClip)) as Texture;
			break;
		case GUIComponent.Health:
			MSPControl.GUIObject.LifeGUI = MSPControl.LifeCounterGUI.GetValue(Health - 1) as Texture;
			break;
		case GUIComponent.Bullet:
			MSPControl.GUIObject.CrossHairGui = MSPControl.CrossHairGUI.GetValue(Mathf.CeilToInt(CurrentWeapon.bulletinMagasine * 10f / (float)CurrentWeapon.bulletperClip)) as Texture;
			break;
		case GUIComponent.Clip:
			if (!(CurrentWeapon.NbClip > 0f))
			{
				CurrentWeapon.NbClip = 0f;
			}
			MSPControl.GUIObject.WeaponGUI = CurrentWeapon.WeaponBulletGUI.GetValue(Mathf.CeilToInt(CurrentWeapon.NbClip)) as Texture;
			break;
		}
	}

	private void SlideGUIandArms()
	{
		if (!(InputX >= -1.5f) && !(AxeArms.localPosition.x <= -0.02f))
		{
			AxeXPos = -0.02f;
			GUIPosX = 0f - GUIPosXMax;
		}
		else if (!(InputX <= 1.5f) && !(AxeArms.localPosition.x >= 0.02f))
		{
			AxeXPos = 0.02f;
			GUIPosX = GUIPosXMax;
		}
		else if (InputX == 0f && (AxeArms.localPosition.x > 0.019f || !(AxeArms.localPosition.x >= -0.019f)))
		{
			GUIPosX = (AxeXPos = 0f);
		}
		if (!(InputY >= -1f) && !(AxeArms.localPosition.y <= -0.009f))
		{
			AxeYCoef = 0.009f;
			GUIPosY = GUIPosYMax;
		}
		else if (!(InputY <= 1f) && !(AxeArms.localPosition.y >= 0.009f))
		{
			AxeYCoef = -0.009f;
			GUIPosY = 0f - GUIPosYMax;
		}
		else if (InputY == 0f && (AxeArms.localPosition.y > 0.008f || !(AxeArms.localPosition.y >= -0.008f)))
		{
			GUIPosY = (AxeYCoef = 0f);
		}
		if (!MSPControl.AimPos)
		{
			if (!(PlayerCam.GetComponent<Camera>().fieldOfView >= 42f))
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
			if (!(PlayerCam.GetComponent<Camera>().fieldOfView <= 34f))
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

	public void OnTriggerEnter(Collider Obj)
	{
		if (Obj.tag == "HealthUp")
		{
			int num = Health + 10;
			if (!((float)num <= MaxHealth))
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

	public void Main()
	{
	}
}
