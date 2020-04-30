using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MasterScript: MonoBehaviour
{
	public static MasterScript instance;


	private class SaveObject
	{
		public int test;
	}

	private void Start()
	{
		if (instance != this && instance != null) 
		{
			Destroy(gameObject);
		} else
		{
			instance = this;
			SaveUtil.Init();
			DontDestroyOnLoad(this.gameObject);
			//Only needs to be instantialized once
		}
		//Save after loading because this may be the player going back to the original scene
		
		//Load();
		//Save();
	}

	public void Save()
	{
		//Collect Data
		//Convert SaveObject to JSON
		//Save JSON to text file


		//Props in world
		SaveObject SavedData = new SaveObject
		{
			test = 1,
		};

		string json = JsonUtility.ToJson(SavedData);
		SaveUtil.Save(json);

		//Save to text file for debugging
		SaveUtil.TextSave(json);
		Debug.Log("SAVED");
	}

	public void Load()
	{
		//Load Text File
		//Convert from JSON to SaveObject
		//From SaveObject Apply to world
		string saveString = SaveUtil.Load();
		if (saveString == null)
		{
			Debug.Log("NO SAVE DATA");
		}
		else
		{
			Debug.Log("SAVE DATA LOADED");
		}

		SaveObject SavedData = JsonUtility.FromJson<SaveObject>(saveString);


		//Load things from SaveObject to world

		//Current Order
		//Load in props and put them in thier positions
		//Load gold value
		//Load last log in to see if theres a streak
		//Load last known pet stats


		//Load and instantiate props
		int LoadedTest = SavedData.test;
	}
}