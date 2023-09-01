using System;
using System.Security.Cryptography;
using System.Text;
using JsonFx.Json;
using UnityEngine;

public class PlayerPrefsPro2
{
	private static byte[] secret;

	public static void Init(string secretKey)
	{
		MD5 mD = new MD5CryptoServiceProvider();
		secret = mD.ComputeHash(Encoding.UTF8.GetBytes(secretKey));
	}

	public static void SetClass(string key, object value)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = mD.ComputeHash(Encoding.UTF8.GetBytes(key));
		string @string = Encoding.UTF8.GetString(bytes);
		string s = JsonWriter.Serialize(value);
		byte[] bytes2 = Encoding.UTF8.GetBytes(s);
		TripleDES tripleDES = new TripleDESCryptoServiceProvider();
		tripleDES.Key = secret;
		tripleDES.Mode = CipherMode.ECB;
		ICryptoTransform cryptoTransform = tripleDES.CreateEncryptor();
		byte[] inArray = cryptoTransform.TransformFinalBlock(bytes2, 0, bytes2.Length);
		string value2 = Convert.ToBase64String(inArray);
		PlayerPrefs.SetString(@string, value2);
	}

	public static T GetClass<T>(string key)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = mD.ComputeHash(Encoding.UTF8.GetBytes(key));
		string @string = Encoding.UTF8.GetString(bytes);
		string string2 = PlayerPrefs.GetString(@string);
		byte[] array = Convert.FromBase64String(string2);
		TripleDES tripleDES = new TripleDESCryptoServiceProvider();
		tripleDES.Key = secret;
		tripleDES.Mode = CipherMode.ECB;
		ICryptoTransform cryptoTransform = tripleDES.CreateDecryptor();
		byte[] bytes2 = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		string string3 = Encoding.UTF8.GetString(bytes2);
		return JsonReader.Deserialize<T>(string3);
	}

	public static bool HasKey(string key)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = mD.ComputeHash(Encoding.UTF8.GetBytes(key));
		string @string = Encoding.UTF8.GetString(bytes);
		return PlayerPrefs.HasKey(@string);
	}

	public static void DeleteKey(string key)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = mD.ComputeHash(Encoding.UTF8.GetBytes(key));
		string @string = Encoding.UTF8.GetString(bytes);
		PlayerPrefs.DeleteKey(key);
	}

	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}
}
