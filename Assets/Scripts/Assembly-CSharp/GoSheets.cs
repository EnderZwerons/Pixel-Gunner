using System;
using System.Collections;
using UnityEngine;

public class GoSheets : MonoBehaviour
{
	private string cachedURL;

	private string cachedSheet;

	public bool ERROR_BOOL;

	public void GetCell(string url, int column, int row, Action<string, int, int, string> method)
	{
		StartCoroutine(GetSheet(url, column, row, method));
	}

	public void ClearCache()
	{
		cachedURL = string.Empty;
		cachedSheet = string.Empty;
	}

	public IEnumerator GetSheet(string url, int column, int row, Action<string, int, int, string> method)
	{
		int i = 0;
		int last = 0;
		int actual = 0;
		if (cachedURL != url)
		{
			Debug.Log("Downloading Sheet with URL: " + url);
			WWW sheet = new WWW(url);
			yield return sheet;
			if (sheet.text == string.Empty)
			{
				ERROR_BOOL = true;
			}
			else
			{
				ERROR_BOOL = false;
				cachedURL = url;
				cachedSheet = sheet.text;
			}
		}
		else
		{
			yield return null;
		}
		if (!ERROR_BOOL)
		{
			string dsheet = cachedSheet;
			string[] rows = dsheet.Split("\n"[0]);
			row--;
			for (; i < column; i++)
			{
				actual = last + 1;
				last = rows[row].IndexOf("\t", actual + 1);
				if (last == -1)
				{
					last = rows[row].Length;
				}
			}
			if (column == 1)
			{
				method(url, column, row + 1, rows[row].Substring(actual - 1, last + 1 - actual));
			}
			else
			{
				method(url, column, row + 1, rows[row].Substring(actual, last - actual));
			}
		}
		else
		{
			Debug.Log("NO INTERNET");
		}
	}
}
