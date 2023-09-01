using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if ((Object)instance == (Object)null)
			{
				instance = Object.FindObjectOfType<T>();
				if ((Object)instance == (Object)null)
				{
					GameObject gameObject = new GameObject();
					instance = gameObject.AddComponent<T>();
					gameObject.name = "_" + typeof(T).ToString();
					Object.DontDestroyOnLoad(gameObject);
				}
			}
			return instance;
		}
	}

	private void OnApplicationQuit()
	{
		instance = (T)null;
	}
}
