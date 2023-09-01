using UnityEngine;

public class LightMap : MonoBehaviour
{
	private void Start()
	{
	}

	private void MapLoad()
	{
		Object.Instantiate(Resources.Load("Map/M001", typeof(GameObject)) as GameObject);
	}

	private void InitLightmaps()
	{
		LightmapData[] array = new LightmapData[1]
		{
			new LightmapData()
		};
		array[0].lightmapColor = Resources.Load("LightMap/2", typeof(Texture2D)) as Texture2D;
		Debug.Log("Lightmap Load");
		LightmapSettings.lightmaps = array;
	}
}
