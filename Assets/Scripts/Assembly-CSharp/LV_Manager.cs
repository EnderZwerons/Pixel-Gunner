using UnityEngine;

public class LV_Manager : MonoBehaviour
{
	public static LV_Manager instance;

	private void Awake()
	{
		instance = this;
	}

	public int lv_Cal(double exp)
	{
		float num = Mathf.Sqrt(((float)exp + 100f) * 0.01f);
		int num2 = (int)num;
		if (num2 > 30)
		{
			num2 = 30;
		}
		return num2;
	}

	public double now_max_exp_cal(int lv)
	{
		return 100 + 200 * lv;
	}

	public double now_exp_cal(double exp, int lv)
	{
		return exp - (double)(100 * (lv * lv - 1));
	}
}
