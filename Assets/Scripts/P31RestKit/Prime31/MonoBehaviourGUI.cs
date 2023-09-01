using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prime31
{
	public class MonoBehaviourGUI : MonoBehaviour
	{
		protected float _width;

		protected float _buttonHeight;

		protected Dictionary<string, bool> _toggleButtons = new Dictionary<string, bool>();

		protected Dictionary<string, bool> _toggleTriggers = new Dictionary<string, bool>();

		protected StringBuilder _logBuilder = new StringBuilder();

		private bool _logRegistered;

		private Vector2 _logScrollPosition;

		private bool _isShowingLogConsole;

		private float _doubleClickDelay = 0.15f;

		private float _previousClickTime;

		private bool _isIphoneX;

		private Texture2D _normalBackground;

		private Texture2D _bottomButtonBackground;

		private Texture2D _activeBackground;

		private Texture2D _toggleButtonBackground;

		private bool _didRetinaIpadCheck;

		private bool _isRetinaIpad;

		private Texture2D normalBackground
		{
			get
			{
				if (!_normalBackground)
				{
					_normalBackground = new Texture2D(1, 1);
					_normalBackground.SetPixel(0, 0, Color.gray);
					_normalBackground.Apply();
				}
				return _normalBackground;
			}
		}

		private Texture2D bottomButtonBackground
		{
			get
			{
				if (!_bottomButtonBackground)
				{
					_bottomButtonBackground = new Texture2D(1, 1);
					_bottomButtonBackground.SetPixel(0, 0, Color.Lerp(Color.gray, Color.black, 0.5f));
					_bottomButtonBackground.Apply();
				}
				return _bottomButtonBackground;
			}
		}

		private Texture2D activeBackground
		{
			get
			{
				if (!_activeBackground)
				{
					_activeBackground = new Texture2D(1, 1);
					_activeBackground.SetPixel(0, 0, Color.yellow);
					_activeBackground.Apply();
				}
				return _activeBackground;
			}
		}

		private Texture2D toggleButtonBackground
		{
			get
			{
				if (!_toggleButtonBackground)
				{
					_toggleButtonBackground = new Texture2D(1, 1);
					_toggleButtonBackground.SetPixel(0, 0, Color.black);
					_toggleButtonBackground.Apply();
				}
				return _toggleButtonBackground;
			}
		}

		private bool isRetinaOrLargeScreen()
		{
			return Screen.width >= 960 || Screen.height >= 960;
		}

		private bool isRetinaIpad()
		{
			if (!_didRetinaIpadCheck)
			{
				if (Screen.height >= 2048 || Screen.width >= 2048)
				{
					_isRetinaIpad = true;
				}
				_didRetinaIpadCheck = true;
			}
			return _isRetinaIpad;
		}

		private int buttonHeight()
		{
			if (isRetinaOrLargeScreen())
			{
				if (isRetinaIpad())
				{
					return 140;
				}
				return 70;
			}
			return 30;
		}

		private int buttonFontSize()
		{
			if (isRetinaOrLargeScreen())
			{
				if (isRetinaIpad())
				{
					return 40;
				}
				return 25;
			}
			return 15;
		}

		private void checkForIphoneX()
		{
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				bool flag = Screen.currentResolution.width == 1125 || Screen.currentResolution.height == 1125;
				bool flag2 = Screen.currentResolution.width == 2436 || Screen.currentResolution.height == 2436;
				_isIphoneX = flag && flag2;
			}
		}

		private int getNotchOffset()
		{
			if (!_isIphoneX)
			{
				return 0;
			}
			if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.FaceUp)
			{
				return 80;
			}
			return 0;
		}

		private void paintWindow(int id)
		{
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.skin.label.fontSize = buttonFontSize();
			_logScrollPosition = GUILayout.BeginScrollView(_logScrollPosition);
			if (GUILayout.Button("Clear Console"))
			{
				_logBuilder.Remove(0, _logBuilder.Length);
			}
			GUILayout.Label(_logBuilder.ToString());
			GUILayout.EndScrollView();
		}

		private void handleLog(string logString, string stackTrace, LogType type)
		{
			_logBuilder.AppendFormat("{0}\n", logString);
		}

		private void OnDestroy()
		{
			removeLogCallback();
		}

		private void Update()
		{
			if (!_logRegistered)
			{
				checkForIphoneX();
				addLogCallback();
				_logRegistered = true;
			}
			bool flag = false;
			if (Input.GetMouseButtonDown(0))
			{
				float num = Time.time - _previousClickTime;
				if (num < _doubleClickDelay)
				{
					flag = true;
				}
				else
				{
					_previousClickTime = Time.time;
				}
			}
			if (flag)
			{
				_isShowingLogConsole = !_isShowingLogConsole;
			}
		}

		private void OnGUI()
		{
			prepGuiSkin();
			if (_isShowingLogConsole)
			{
				string text = "prime[31] Log Console - double tap to dismiss";
				GUILayout.Window(1, new Rect(0f, getNotchOffset(), Screen.width, Screen.height), paintWindow, text);
				return;
			}
			GUILayout.BeginArea(new Rect(10f, getNotchOffset() + 10, _width, Screen.height));
			GUILayout.BeginVertical();
			onLeftColumnGUI();
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect((float)Screen.width - _width - 10f, getNotchOffset() + 10, _width, Screen.height));
			GUILayout.BeginVertical();
			onRightColumnGUI();
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}

		private void addLogCallback()
		{
			Application.RegisterLogCallback(handleLog);
		}

		private void removeLogCallback()
		{
			Application.RegisterLogCallback(null);
		}

		protected void prepGuiSkin()
		{
			_width = Screen.width / 2 - 15;
			_buttonHeight = buttonHeight();
			GUI.skin.button.fontSize = buttonFontSize();
			GUI.skin.button.margin = new RectOffset(0, 0, 10, 0);
			GUI.skin.button.stretchWidth = true;
			GUI.skin.button.fixedHeight = _buttonHeight;
			GUI.skin.button.wordWrap = false;
			GUI.skin.button.hover.background = normalBackground;
			GUI.skin.button.normal.background = normalBackground;
			GUI.skin.button.active.background = activeBackground;
			GUI.skin.button.active.textColor = Color.black;
			GUI.skin.label.normal.textColor = Color.black;
			GUI.skin.label.fontSize = buttonFontSize();
		}

		protected void beginColumn()
		{
			prepGuiSkin();
			if (_isShowingLogConsole)
			{
				GUILayout.BeginArea(new Rect(0f, getNotchOffset(), 0f, 0f));
			}
			else
			{
				GUILayout.BeginArea(new Rect(10f, getNotchOffset() + 10, _width, Screen.height));
			}
			GUILayout.BeginVertical();
		}

		protected void endColumn()
		{
			endColumn(false);
		}

		protected void endColumn(bool hasSecondColumn)
		{
			GUILayout.EndVertical();
			GUILayout.EndArea();
			if (_isShowingLogConsole)
			{
				GUILayout.Window(1, new Rect(0f, getNotchOffset(), Screen.width, Screen.height), paintWindow, "prime[31] Log Console - double tap to dismiss");
			}
			if (hasSecondColumn)
			{
				beginRightColumn();
			}
		}

		private void beginRightColumn()
		{
			if (_isShowingLogConsole)
			{
				GUILayout.BeginArea(new Rect(0f, getNotchOffset(), 0f, 0f));
			}
			else
			{
				GUILayout.BeginArea(new Rect((float)Screen.width - _width - 10f, getNotchOffset() + 10, _width, Screen.height));
			}
			GUILayout.BeginVertical();
		}

		protected bool button(string text)
		{
			return GUILayout.Button(text);
		}

		protected bool bottomRightButton(string text, float width = 150f)
		{
			GUI.skin.button.hover.background = bottomButtonBackground;
			GUI.skin.button.normal.background = bottomButtonBackground;
			width = (float)Screen.width / 2f - 35f - 20f;
			return GUI.Button(new Rect((float)Screen.width - width - 10f, (float)Screen.height - _buttonHeight - 10f, width, _buttonHeight), text);
		}

		protected bool bottomLeftButton(string text, float width = 150f)
		{
			GUI.skin.button.hover.background = bottomButtonBackground;
			GUI.skin.button.normal.background = bottomButtonBackground;
			width = (float)Screen.width / 2f - 35f - 20f;
			return GUI.Button(new Rect(10f, (float)Screen.height - _buttonHeight - 10f, width, _buttonHeight), text);
		}

		protected bool bottomCenterButton(string text, float width = 150f)
		{
			GUI.skin.button.hover.background = bottomButtonBackground;
			GUI.skin.button.normal.background = bottomButtonBackground;
			float left = (float)(Screen.width / 2) - width / 2f;
			return GUI.Button(new Rect(left, (float)Screen.height - _buttonHeight - 10f, width, _buttonHeight), text);
		}

		protected bool toggleButton(string defaultText, string selectedText)
		{
			if (!_toggleButtons.ContainsKey(defaultText))
			{
				_toggleButtons[defaultText] = true;
			}
			string text = (_toggleButtons[defaultText] ? defaultText : selectedText);
			GUI.skin.button.normal.background = toggleButtonBackground;
			if (!_toggleButtons[defaultText])
			{
				GUI.contentColor = Color.yellow;
			}
			else
			{
				GUI.skin.button.fontStyle = FontStyle.Bold;
				GUI.contentColor = Color.red;
			}
			if (GUILayout.Button(text))
			{
				_toggleButtons[defaultText] = text != defaultText;
			}
			GUI.skin.button.normal.background = normalBackground;
			GUI.skin.button.fontStyle = FontStyle.Normal;
			GUI.contentColor = Color.white;
			return _toggleButtons[defaultText];
		}

		protected bool toggleButtonState(string defaultText)
		{
			if (!_toggleButtons.ContainsKey(defaultText))
			{
				_toggleButtons[defaultText] = true;
			}
			return _toggleButtons[defaultText];
		}

		protected void setTrigger(string trigger, bool state = true)
		{
			_toggleTriggers[trigger] = state;
		}

		protected bool checkTrigger(string trigger)
		{
			if (_toggleTriggers.ContainsKey(trigger))
			{
				return _toggleTriggers[trigger];
			}
			return false;
		}

		protected virtual void onLeftColumnGUI()
		{
		}

		protected virtual void onRightColumnGUI()
		{
		}

		public static void loadLevel(int level)
		{
			SceneManager.LoadScene(level);
		}

		public static void loadLevel(string level)
		{
			SceneManager.LoadScene(level);
		}

		public static void captureScreenshot(string filename)
		{
			try
			{
				typeof(Application).GetMethod("CaptureScreenshot", new Type[1] { typeof(string) }).Invoke(null, new object[1] { filename });
			}
			catch
			{
				try
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					foreach (Assembly assembly in assemblies)
					{
						Type[] types = assembly.GetTypes();
						foreach (Type type in types)
						{
							if (type.Name.StartsWith("ScreenCapture"))
							{
								type.GetMethod("CaptureScreenshot", new Type[1] { typeof(string) }).Invoke(null, new object[1] { filename });
								break;
							}
						}
					}
				}
				catch
				{
					Debug.LogError("Could not capture screenshot. Both Application CaptureScreenshot and ScreenCapture CaptureScreenshot failed to load the scene.");
				}
			}
		}

		public static IEnumerator fetchScreenshot(string filename, float delay = 3f)
		{
			yield return new WaitForSeconds(delay);
			yield return new WaitForEndOfFrame();
			Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
			screenImage.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
			screenImage.Apply();
			File.WriteAllBytes(bytes: screenImage.EncodeToPNG(), path: Path.Combine(Application.persistentDataPath, filename));
		}
	}
}
