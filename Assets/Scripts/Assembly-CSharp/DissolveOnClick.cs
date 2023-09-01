using UnityEngine;

public class DissolveOnClick : MonoBehaviour
{
	public Shader dissolveShader;

	public Texture2D dissolvePattern;

	public Color dissolveEmissionColor;

	public float dissolveSpeed = 0.1f;

	private float sliceAmount;

	private bool dissolve;

	private bool mouseOver;

	public GameObject renob;

	private void Update()
	{
		if (dissolve)
		{
			sliceAmount -= Time.deltaTime * dissolveSpeed;
			renob.transform.GetComponent<Renderer>().material.SetFloat("_DissolvePower", 0.65f + Mathf.Sin(0.9f) * sliceAmount);
			if (renob.transform.GetComponent<Renderer>().material.GetFloat("_DissolvePower") < 0.001f)
			{
				dissolve = false;
			}
		}
	}

	private void Die_Shader()
	{
		renob.transform.GetComponent<Renderer>().material.shader = dissolveShader;
		renob.transform.GetComponent<Renderer>().material.SetColor("_DissolveEmissionColor", dissolveEmissionColor);
		renob.transform.GetComponent<Renderer>().material.SetFloat("_DissolveEmissionThickness", -0.05f);
		renob.transform.GetComponent<Renderer>().material.SetTexture("_DissolveTex", dissolvePattern);
		renob.transform.GetComponent<Renderer>().material.SetTextureOffset("_DissolveTex", new Vector2(Random.Range(1f, 10f), Random.Range(1f, 10f)));
		dissolve = true;
	}

	private void OnMouseEnter()
	{
		mouseOver = true;
	}

	private void OnMouseExit()
	{
		mouseOver = false;
	}
}
