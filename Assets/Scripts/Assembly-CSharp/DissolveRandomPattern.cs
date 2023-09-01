using UnityEngine;

public class DissolveRandomPattern : MonoBehaviour
{
	private void Awake()
	{
		base.transform.GetComponent<Renderer>().material.SetTextureOffset("_DissolveTex", new Vector2(Random.Range(1f, 10f), Random.Range(1f, 10f)));
	}
}
