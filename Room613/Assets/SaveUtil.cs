using System.IO;
using UnityEngine;

public static class SaveUtil
{
	private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
	private static readonly string PLAYER_SAVE_DATA = "PLAYER_SAVE_DATA";

	public static void Init()
	{
		if (!Directory.Exists(SAVE_FOLDER)){
			Directory.CreateDirectory(SAVE_FOLDER);
		}
	}

	public static void TextSave(string SaveString)
	{
		File.WriteAllText(SAVE_FOLDER + "/save.txt", SaveString);
	}

	public static string TextLoad()
	{
		if (File.Exists(SAVE_FOLDER + "/save.txt"))
		{
			return File.ReadAllText(SAVE_FOLDER + "/save.txt");
		} else
		{
			return null;
		}
	}

	public static void Save(string SaveString)
	{
		PlayerPrefs.SetString(PLAYER_SAVE_DATA, SaveString);
	}

	public static string Load()
	{
		if (PlayerPrefs.GetString(PLAYER_SAVE_DATA,"null") != "null")
		{
			return PlayerPrefs.GetString(PLAYER_SAVE_DATA);
		}
		else
		{
			return null;
		}
	}
}
