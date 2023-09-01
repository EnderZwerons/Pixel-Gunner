using System;
using UnityEngine;

[Serializable]
public class MSP
{
	public enum HUDPos
	{
		LeftUpper,
		RightUpper,
		LeftLower,
		RightLower,
		None
	}

	public enum SeparateScreen
	{
		_HalfHalf,
		_1third2thirds,
		_2thirds1third,
		_Full
	}

	public enum HandType
	{
		RightHanded,
		LeftHanded
	}

	public enum GUIPad
	{
		AnalogPad,
		Slide,
		Button,
		None
	}

	public enum FirePos
	{
		window1,
		window2,
		None
	}

	public enum AxeLimit
	{
		AllAxis,
		XAxis,
		YAxis
	}

	public enum TOC
	{
		TouchCtrl,
		PauseMenu
	}

	public enum OnOff
	{
		On,
		Off
	}

	public enum GyroAccel
	{
		Accelero,
		Gyro,
		None
	}

	[Serializable]
	public class GUIObj
	{
		public Texture SocleGUI;

		public Texture StickGUI;

		public Texture PauseGUI;

		public Texture WeaponGUI;

		public Texture LifeGUI;

		public Texture FourthCornerGui;

		public Texture FireGui;

		public Texture CrossHairGui;
	}

	private class Btn
	{
		public bool FingerDown;

		public Rect FingerBound;

		public int FingerId = -1;

		public Vector2 FingerCenter;

		public Rect FingerStickRect;

		public Rect FingerSocleRect;
	}

	private float deadZoneinPurcent = 20f;

	private float PadCorrector;

	private float PadSize;

	private Color Window1PadColor;

	private Color Window2PadColor;

	private Color TranspColor = new Color(0f, 0f, 0f, 0f);

	private TOC TypeOfControl;

	public Gyroscope Gyro;

	private float CrossHairS;

	private float InterfWidth;

	private float InterfHeight;

	private Rect LeftBound;

	private Rect RightBound;

	private Btn Left = new Btn();

	private Btn Right = new Btn();

	private Btn Fire = new Btn();

	private Btn AimBtn = new Btn();

	private Btn WeaponBtn = new Btn();

	private Btn PauseBtn = new Btn();

	private Rect LifeGUI = default(Rect);

	private Rect FourthCornerGUI = default(Rect);

	private Rect WeaponGUI = default(Rect);

	private Rect PauseGUI = default(Rect);

	private Vector2 FixePos;

	private Matrix4x4 matrix;

	public float PadSizeCorrector = 1f;

	public float CrossHSizeCorrector = 1f;

	public Vector2 FireBtnPosCorrector = default(Vector2);

	public bool debugMode;

	public SeparateScreen LeftRightParts = SeparateScreen._1third2thirds;

	public GUIPad LeftGUIPadStyle;

	public GUIPad RightGUIPadStyle;

	public AxeLimit LeftAxeLimit;

	public AxeLimit RightAxeLimit;

	public HUDPos PausePosition = HUDPos.RightUpper;

	public HUDPos WeaponGUIPosition;

	public HUDPos LifeGUIPosition = HUDPos.RightLower;

	public HUDPos FourthGUIPosition = HUDPos.LeftLower;

	public FirePos BtnFirePos = FirePos.window2;

	public OnOff Window1TapCount = OnOff.Off;

	public OnOff Window2TapCount = OnOff.Off;

	public GyroAccel AccelGyroCtrl = GyroAccel.None;

	public Color GUIColor = new Color(1f, 1f, 1f, 0.8f);

	public HandType HandStyle;

	public Texture[] LifeCounterGUI;

	public Texture[] CrossHairGUI;

	public GUIObj GUIObject;

	[NonSerialized]
	public bool HideCrossHair;

	[NonSerialized]
	public bool WeaponActionEnded;

	[NonSerialized]
	public float WeaponTouchDiff;

	[NonSerialized]
	public float WeaponTouchPurcentDist;

	[NonSerialized]
	public float DPI;

	[NonSerialized]
	public Vector2 HalfScreen;

	[NonSerialized]
	public Vector2 HUDPosition;

	[NonSerialized]
	public Vector2 ScreenSize;

	[NonSerialized]
	public Vector2 Window1InputPad;

	[NonSerialized]
	public Vector2 Window2InputPad;

	[NonSerialized]
	public Vector2 Window1InputSlide;

	[NonSerialized]
	public Vector2 Window2InputSlide;

	[NonSerialized]
	public bool WindowFireBtnPressed;

	[NonSerialized]
	public bool Window1Pressed;

	[NonSerialized]
	public bool Window2Pressed;

	[NonSerialized]
	public int Window1TapNbr;

	[NonSerialized]
	public int Window2TapNbr;

	[NonSerialized]
	public Quaternion GyroCoord;

	[NonSerialized]
	public Vector2 Acceleration;

	public bool PauseStatus;

	public bool AimPos;

	private Quaternion quatMult;

	public float GyroUpdateInterval = 1f;

	public void InitControl()
	{
		ScreenSize = new Vector2(Screen.width, Screen.height);
		HalfScreen = ScreenSize / 2f;
		DPI = Screen.dpi / 100f;
		if (DPI == 0f)
		{
			DPI = 1.6f;
		}
		PadSize = DPI * 56.25f;
		CrossHairS = DPI * 23.75f;
		Window1PadColor = TranspColor;
		Window2PadColor = TranspColor;
		switch (LeftRightParts)
		{
		case SeparateScreen._1third2thirds:
			LeftBound = new Rect(0f, 0f, ScreenSize.x / 3f, ScreenSize.y);
			RightBound = new Rect(ScreenSize.x / 3f, 0f, ScreenSize.x / 3f * 2f, ScreenSize.y);
			break;
		case SeparateScreen._2thirds1third:
			LeftBound = new Rect(0f, 0f, ScreenSize.x / 3f * 2f, ScreenSize.y);
			RightBound = new Rect(ScreenSize.x / 3f * 2f, 0f, ScreenSize.x / 3f, ScreenSize.y);
			break;
		case SeparateScreen._HalfHalf:
			LeftBound = new Rect(0f, 0f, ScreenSize.x / 2f, ScreenSize.y);
			RightBound = new Rect(ScreenSize.x / 2f, 0f, ScreenSize.x / 2f, ScreenSize.y);
			break;
		case SeparateScreen._Full:
			LeftBound = new Rect(0f, 0f, ScreenSize.x, ScreenSize.y);
			RightBound = new Rect(0f, 0f, 0f, 0f);
			break;
		}
		switch (HandStyle)
		{
		case HandType.RightHanded:
			Left.FingerBound = LeftBound;
			Right.FingerBound = RightBound;
			break;
		case HandType.LeftHanded:
			Left.FingerBound = RightBound;
			Right.FingerBound = LeftBound;
			break;
		}
		if (AccelGyroCtrl == GyroAccel.Gyro && SystemInfo.supportsGyroscope)
		{
			Gyro = Input.gyro;
			Gyro.enabled = true;
			Gyro.updateInterval = GyroUpdateInterval;
			quatMult = AltQuatMult();
		}
		InterfWidth = ScreenSize.x * 28.69f / 100f;
		InterfHeight = 0.39142856f * InterfWidth;
		WeaponGUI = SwitchBound((int)WeaponGUIPosition, "GUI");
		PauseGUI = SwitchBound((int)PausePosition, "GUI");
		FourthCornerGUI = SwitchBound((int)FourthGUIPosition, "GUI");
		LifeGUI = SwitchBound((int)LifeGUIPosition, "GUI");
		PauseBtn.FingerBound = SwitchBound((int)PausePosition, "Btn");
		WeaponBtn.FingerBound = SwitchBound((int)WeaponGUIPosition, "Btn");
		AimBtn.FingerBound = SwitchBound((int)FourthGUIPosition, "Btn");
		PadSizeCorrector = 1f;
		PadCorrector = PadSize * PadSizeCorrector;
		switch (BtnFirePos)
		{
		case FirePos.window2:
			FixePos = new Vector2(RightBound.x + RightBound.width / 3f * 2f, RightBound.height / 4f * 2f);
			break;
		case FirePos.window1:
			FixePos = new Vector2(LeftBound.x + LeftBound.width / 3f * 2f, LeftBound.height / 4f * 2f);
			break;
		}
	}

	public void Command()
	{
		switch (TypeOfControl)
		{
		case TOC.TouchCtrl:
			InGameTouchCtrl();
			break;
		}
	}

	private void InGameTouchCtrl()
	{
		switch (AccelGyroCtrl)
		{
		case GyroAccel.Gyro:
			GyroCoord = Gyro.attitude * quatMult;
			break;
		case GyroAccel.Accelero:
			Acceleration = new Vector2(Input.acceleration.x, Input.acceleration.y);
			break;
		}
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if (touch.phase == TouchPhase.Began)
			{
				if (!PauseBtn.FingerDown)
				{
					PauseBtn.FingerDown = PauseBtn.FingerBound.Contains(touch.position);
					if (PauseBtn.FingerDown)
					{
						PauseBtn.FingerId = touch.fingerId;
						PauseStatus = !PauseStatus;
						continue;
					}
				}
				if (!WeaponBtn.FingerDown)
				{
					WeaponBtn.FingerDown = WeaponBtn.FingerBound.Contains(touch.position);
					if (WeaponBtn.FingerDown)
					{
						WeaponBtn.FingerId = touch.fingerId;
						WeaponBtn.FingerCenter = new Vector2(touch.position.x, 0f);
						continue;
					}
				}
				if (!AimBtn.FingerDown)
				{
					AimBtn.FingerDown = AimBtn.FingerBound.Contains(touch.position);
					if (AimBtn.FingerDown)
					{
						AimBtn.FingerId = touch.fingerId;
						AimPos = !AimPos;
						continue;
					}
				}
				switch (LeftGUIPadStyle)
				{
				case GUIPad.AnalogPad:
					if (!Left.FingerDown)
					{
						Left.FingerDown = Left.FingerBound.Contains(touch.position);
						if (Left.FingerDown)
						{
							Left.FingerId = touch.fingerId;
							Left.FingerCenter = touch.position;
							Left.FingerSocleRect = (Left.FingerStickRect = new Rect(Left.FingerCenter.x - PadCorrector / 2f, ScreenSize.y - Left.FingerCenter.y - PadCorrector / 2f, PadCorrector, PadCorrector));
							Window1PadColor = GUIColor;
							continue;
						}
					}
					break;
				case GUIPad.Slide:
					if (Left.FingerDown)
					{
						break;
					}
					Left.FingerDown = Left.FingerBound.Contains(touch.position);
					if (Left.FingerDown)
					{
						Left.FingerId = touch.fingerId;
						if (BtnFirePos == FirePos.window1 && Fire.FingerBound.Contains(touch.position) && PlayerPrefs.GetInt("autofire") == 0)
						{
							WindowFireBtnPressed = true;
						}
						if (Window1TapCount == OnOff.On)
						{
							Window1TapNbr = touch.tapCount;
						}
						continue;
					}
					break;
				case GUIPad.Button:
					if (Left.FingerDown)
					{
						break;
					}
					Left.FingerDown = Left.FingerBound.Contains(touch.position);
					if (Left.FingerDown)
					{
						Left.FingerId = touch.fingerId;
						Window1Pressed = true;
						if (Window1TapCount == OnOff.On)
						{
							Window1TapNbr = touch.tapCount;
						}
						continue;
					}
					break;
				}
				switch (RightGUIPadStyle)
				{
				case GUIPad.AnalogPad:
					if (!Right.FingerDown)
					{
						Right.FingerDown = Right.FingerBound.Contains(touch.position);
						if (Right.FingerDown)
						{
							Right.FingerId = touch.fingerId;
							Right.FingerCenter = touch.position;
							Right.FingerSocleRect = (Right.FingerStickRect = new Rect(Right.FingerCenter.x - PadCorrector / 2f, ScreenSize.y - Right.FingerCenter.y - PadCorrector / 2f, PadCorrector, PadCorrector));
							Window2PadColor = GUIColor;
						}
					}
					break;
				case GUIPad.Slide:
					if (Right.FingerDown)
					{
						break;
					}
					Right.FingerDown = Right.FingerBound.Contains(touch.position);
					if (Right.FingerDown)
					{
						Right.FingerId = touch.fingerId;
						FirePos btnFirePos = BtnFirePos;
						if (btnFirePos == FirePos.window2 && Fire.FingerBound.Contains(touch.position) && PlayerPrefs.GetInt("autofire") == 0)
						{
							WindowFireBtnPressed = true;
						}
						if (Window2TapCount == OnOff.On)
						{
							Window2TapNbr = touch.tapCount;
						}
					}
					break;
				case GUIPad.Button:
					if (Right.FingerDown)
					{
						break;
					}
					Right.FingerDown = Right.FingerBound.Contains(touch.position);
					if (Right.FingerDown)
					{
						Right.FingerId = touch.fingerId;
						Window2Pressed = true;
						if (Window2TapCount == OnOff.On)
						{
							Window2TapNbr = touch.tapCount;
						}
					}
					break;
				}
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				if (WeaponBtn.FingerDown && WeaponBtn.FingerId == touch.fingerId)
				{
					WeaponTouchDiff = touch.position.x - WeaponBtn.FingerCenter.x;
					WeaponTouchPurcentDist = Mathf.Abs(WeaponTouchDiff * 100f / WeaponBtn.FingerBound.width);
				}
				switch (LeftGUIPadStyle)
				{
				case GUIPad.AnalogPad:
					if (Left.FingerDown && Left.FingerId == touch.fingerId)
					{
						float num = PadCorrector / 1.5f;
						Vector2 vector = default(Vector2);
						switch (LeftAxeLimit)
						{
						case AxeLimit.AllAxis:
							vector = touch.position - Left.FingerCenter;
							break;
						case AxeLimit.XAxis:
							vector = new Vector2(touch.position.x, Left.FingerCenter.y) - Left.FingerCenter;
							break;
						case AxeLimit.YAxis:
							vector = new Vector2(Left.FingerCenter.x, touch.position.y) - Left.FingerCenter;
							break;
						}
						float num2 = vector.magnitude * 100f / num;
						if (num2 >= 100f)
						{
							num2 = 100f;
						}
						if (num2 > deadZoneinPurcent)
						{
							Window1InputPad = vector.normalized * num2 / 100f;
						}
						else
						{
							Window1InputPad = Vector2.zero;
						}
						Vector2 vector2 = Vector2.ClampMagnitude(vector, num);
						Left.FingerStickRect = new Rect(Left.FingerCenter.x + vector2.x - PadCorrector / 2f, ScreenSize.y - (Left.FingerCenter.y + vector2.y) - PadCorrector / 2f, PadCorrector, PadCorrector);
					}
					break;
				case GUIPad.Slide:
					if (Left.FingerDown && Left.FingerId == touch.fingerId)
					{
						switch (LeftAxeLimit)
						{
						case AxeLimit.AllAxis:
							Window1InputSlide = touch.deltaPosition * Time.smoothDeltaTime;
							break;
						case AxeLimit.XAxis:
							Window1InputSlide = new Vector2(touch.deltaPosition.x, 0f) * Time.smoothDeltaTime;
							break;
						case AxeLimit.YAxis:
							Window1InputSlide = new Vector2(0f, touch.deltaPosition.y) * Time.smoothDeltaTime;
							break;
						}
					}
					break;
				}
				switch (RightGUIPadStyle)
				{
				case GUIPad.AnalogPad:
					if (Right.FingerDown && Right.FingerId == touch.fingerId)
					{
						float num3 = PadCorrector / 1.5f;
						Vector2 vector3 = default(Vector2);
						switch (RightAxeLimit)
						{
						case AxeLimit.AllAxis:
							vector3 = touch.position - Right.FingerCenter;
							break;
						case AxeLimit.XAxis:
							vector3 = new Vector2(touch.position.x, Right.FingerCenter.y) - Right.FingerCenter;
							break;
						case AxeLimit.YAxis:
							vector3 = new Vector2(Right.FingerCenter.x, touch.position.y) - Right.FingerCenter;
							break;
						}
						float num4 = vector3.magnitude * 100f / num3;
						if (num4 >= 100f)
						{
							num4 = 100f;
						}
						if (num4 > deadZoneinPurcent)
						{
							Window2InputPad = vector3.normalized * num4 / 100f;
						}
						else
						{
							Window2InputPad = Vector2.zero;
						}
						Vector2 vector4 = Vector2.ClampMagnitude(vector3, num3);
						Right.FingerStickRect = new Rect(Right.FingerCenter.x + vector4.x - PadCorrector / 2f, ScreenSize.y - (Right.FingerCenter.y + vector4.y) - PadCorrector / 2f, PadCorrector, PadCorrector);
					}
					break;
				case GUIPad.Slide:
					if (Right.FingerDown && Right.FingerId == touch.fingerId)
					{
						switch (RightAxeLimit)
						{
						case AxeLimit.AllAxis:
							Window2InputSlide = touch.deltaPosition * Time.smoothDeltaTime;
							break;
						case AxeLimit.XAxis:
							Window2InputSlide = new Vector2(touch.deltaPosition.x, 0f) * Time.smoothDeltaTime;
							break;
						case AxeLimit.YAxis:
							Window2InputSlide = new Vector2(0f, touch.deltaPosition.y) * Time.smoothDeltaTime;
							break;
						}
					}
					break;
				}
			}
			else if (touch.phase == TouchPhase.Stationary)
			{
				GUIPad leftGUIPadStyle = LeftGUIPadStyle;
				if (leftGUIPadStyle == GUIPad.Slide && Left.FingerDown && Left.FingerId == touch.fingerId)
				{
					Window1InputSlide = Vector2.zero;
				}
				leftGUIPadStyle = RightGUIPadStyle;
				if (leftGUIPadStyle == GUIPad.Slide && Right.FingerDown && Right.FingerId == touch.fingerId)
				{
					Window2InputSlide = Vector2.zero;
				}
			}
			else
			{
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				{
					continue;
				}
				if (WeaponBtn.FingerDown && WeaponBtn.FingerId == touch.fingerId)
				{
					WeaponActionEnded = true;
					WeaponBtn.FingerDown = false;
					WeaponBtn.FingerCenter = Vector2.zero;
					WeaponBtn.FingerId = -1;
				}
				if (AimBtn.FingerDown && AimBtn.FingerId == touch.fingerId)
				{
					AimBtn.FingerDown = false;
					AimBtn.FingerId = -1;
				}
				switch (LeftGUIPadStyle)
				{
				case GUIPad.AnalogPad:
					if (Left.FingerDown && Left.FingerId == touch.fingerId)
					{
						Window1InputPad = Vector2.zero;
						Left.FingerDown = false;
						Left.FingerId = -1;
						Window1PadColor = TranspColor;
					}
					break;
				case GUIPad.Slide:
					if (Left.FingerDown && Left.FingerId == touch.fingerId)
					{
						Window1InputSlide = Vector2.zero;
						Left.FingerDown = false;
						Left.FingerId = -1;
						if (BtnFirePos == FirePos.window1)
						{
							WindowFireBtnPressed = false;
						}
						if (Window1TapCount == OnOff.On)
						{
							Window1TapNbr = 0;
						}
					}
					break;
				case GUIPad.Button:
					if (Left.FingerDown && Left.FingerId == touch.fingerId)
					{
						Window1Pressed = false;
						Left.FingerDown = false;
						Left.FingerId = -1;
						if (Window1TapCount == OnOff.On)
						{
							Window1TapNbr = 0;
						}
					}
					break;
				}
				switch (RightGUIPadStyle)
				{
				case GUIPad.AnalogPad:
					if (Right.FingerDown && Right.FingerId == touch.fingerId)
					{
						Window2InputPad = Vector2.zero;
						Right.FingerDown = false;
						Right.FingerId = -1;
						Window2PadColor = TranspColor;
					}
					break;
				case GUIPad.Slide:
					if (Right.FingerDown && Right.FingerId == touch.fingerId)
					{
						Window2InputSlide = Vector2.zero;
						Right.FingerDown = false;
						Right.FingerId = -1;
						FirePos btnFirePos = BtnFirePos;
						if (btnFirePos == FirePos.window2)
						{
							WindowFireBtnPressed = false;
						}
						if (Window2TapCount == OnOff.On)
						{
							Window2TapNbr = 0;
						}
					}
					break;
				case GUIPad.Button:
					if (Right.FingerDown && Right.FingerId == touch.fingerId)
					{
						Window2Pressed = false;
						Right.FingerDown = false;
						Right.FingerId = -1;
						if (Window2TapCount == OnOff.On)
						{
							Window2TapNbr = 0;
						}
					}
					break;
				}
			}
		}
	}

	public void OnGUIComponents()
	{
		if (debugMode)
		{
			DebugInfo();
		}
		if (LeftGUIPadStyle == GUIPad.AnalogPad)
		{
			GUI.color = Window1PadColor;
			GUI.DrawTexture(Left.FingerSocleRect, GUIObject.SocleGUI);
			GUI.DrawTexture(Left.FingerStickRect, GUIObject.StickGUI);
		}
		else if (Window1PadColor != TranspColor)
		{
			GUI.color = TranspColor;
		}
		if (RightGUIPadStyle == GUIPad.AnalogPad)
		{
			GUI.color = Window2PadColor;
			GUI.DrawTexture(Right.FingerSocleRect, GUIObject.SocleGUI);
			GUI.DrawTexture(Right.FingerStickRect, GUIObject.StickGUI);
		}
		else if (Window2PadColor != TranspColor)
		{
			GUI.color = TranspColor;
		}
		GUI.color = GUIColor;
		if (PlayerPrefs.GetInt("autofire") == 0)
		{
			Fire.FingerBound = new Rect(FixePos.x - PadSize * PadSizeCorrector / 2f + FireBtnPosCorrector.x, FixePos.y - PadSize * PadSizeCorrector / 2f - FireBtnPosCorrector.y, PadSize * PadSizeCorrector, PadSize * PadSizeCorrector);
			GUI.DrawTexture(new Rect(Fire.FingerBound.x, ScreenSize.y - Fire.FingerBound.y - PadSize * PadSizeCorrector, Fire.FingerBound.width, Fire.FingerBound.height), GUIObject.FireGui);
		}
		matrix = Matrix4x4.TRS(new Vector3(HUDPosition.x, HUDPosition.y, 0f), Quaternion.identity, Vector3.one);
		GUI.matrix = matrix;
	}

	public Rect SwitchBound(int Side, string GUIBtn)
	{
		Rect result = default(Rect);
		float top;
		float top2;
		if (GUIBtn == "GUI")
		{
			top = 0f;
			top2 = ScreenSize.y - InterfHeight;
		}
		else
		{
			top = ScreenSize.y - InterfHeight;
			top2 = 0f;
		}
		switch (Side)
		{
		case 0:
			result = new Rect(0f, top, InterfWidth, InterfHeight);
			break;
		case 1:
			result = new Rect(ScreenSize.x - InterfWidth, top, InterfWidth, InterfHeight);
			break;
		case 2:
			result = new Rect(0f, top2, InterfWidth, InterfHeight);
			break;
		case 3:
			result = new Rect(ScreenSize.x - InterfWidth, top2, InterfWidth, InterfHeight);
			break;
		}
		return result;
	}

	private Quaternion AltQuatMult()
	{
		Quaternion result = Quaternion.identity;
		if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
		{
			result = new Quaternion(0f, 0f, 0.7071f, -0.7071f);
		}
		else if (Screen.orientation == ScreenOrientation.Portrait)
		{
			result = new Quaternion(0f, 0f, -0.7071f, -0.7071f);
		}
		else if (Screen.orientation == ScreenOrientation.LandscapeRight)
		{
			result = new Quaternion(0f, 0f, 0f, 1f);
		}
		else if (Screen.orientation == ScreenOrientation.LandscapeLeft)
		{
			result = new Quaternion(0f, 0f, 1f, 0f);
		}
		return result;
	}

	private void DebugInfo()
	{
		GUI.Box(new Rect(0f, 130f, 320f, 350f), string.Empty);
		GUI.Label(new Rect(0f, 130f, 300f, 30f), "GyroCorrector : " + quatMult.ToString());
		GUI.Label(new Rect(0f, 160f, 300f, 30f), "Fire : " + PauseStatus);
		GUI.Label(new Rect(0f, 190f, 300f, 30f), "PadLeft : " + Window1InputPad.ToString());
		GUI.Label(new Rect(0f, 220f, 300f, 30f), "PadRight : " + Window2InputPad.ToString());
		GUI.Label(new Rect(0f, 250f, 300f, 30f), "SlideLeft : " + Window1InputSlide.ToString());
		GUI.Label(new Rect(0f, 280f, 300f, 30f), "SlideRight : " + Window2InputSlide.ToString());
		GUI.Label(new Rect(0f, 310f, 300f, 30f), "Window1Pressed : " + Window1Pressed);
		GUI.Label(new Rect(0f, 340f, 300f, 30f), "Window2Pressed : " + Window2Pressed);
		GUI.Label(new Rect(0f, 370f, 300f, 30f), "Window1TapNbr : " + Window1TapNbr);
		GUI.Label(new Rect(0f, 400f, 300f, 30f), "Window2TapNbr : " + Window2TapNbr);
		GUI.Label(new Rect(0f, 430f, 300f, 30f), "Accelerometer : " + Acceleration.ToString());
		GUI.Label(new Rect(0f, 460f, 300f, 30f), "Gyro Rotation: " + GyroCoord.ToString());
	}
}
