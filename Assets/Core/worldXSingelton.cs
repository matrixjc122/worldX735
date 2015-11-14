

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public  class worldXSingelton
{
	private static worldXSingelton instance_private;
	public static Common[,] WorldObjects{ set;get;}

	public static Vector2 WorldSize{ set; get;}

	private static Dictionary<string, GameObject > ZombiDict{ set; get;}
	public static  Dictionary<string, GameObject >.KeyCollection ZombiKnownTypes{ set;get;}

	public static string UISelectedType{ set; get;}
	public static bool UIOnly{ set; get;}
	public static bool UIAction{ set; get;}
	

	// *---------------- STATIC
	public static void LoadZombiPrefab(string typeName)
	{
		
	
		GameObject zombi = GameObject.Instantiate (Resources.Load (typeName)) as GameObject;
		zombi.GetComponent<Common>().FigureType = typeName;
		zombi.GetComponent<Common>().FigureWillpower = 1.0f;
		zombi.name = "zombi-" + typeName;
		zombi.SetActive(false); // mark it as zombi
		ZombiDict.Add (typeName, zombi);
		ZombiKnownTypes = ZombiDict.Keys;
		switch(typeName)
		{
		case "A":
			zombi.GetComponent<Common>().FigureWeight = 0.40f;
			break;
		case "B":
			zombi.GetComponent<Common>().FigureWeight = 0.10f;
			break;
		case "C":
			zombi.GetComponent<Common>().FigureWeight = 0.01f;
			break;
			
		}
	}

	public static void StaticInitialisation(Vector2 worldSize)
	{
		instance_private = new worldXSingelton();
		WorldSize = worldSize;
		WorldObjects = new Common[(int)worldXSingelton.WorldSize.x, (int)worldXSingelton.WorldSize.y];
		ZombiDict = new Dictionary<string, GameObject>();
		UISelectedType = "A";
	}
	
	public static worldXSingelton Instance
	{
		get 
		{
			if (instance_private == null)
			{
				StaticInitialisation( new Vector2(5,5));
			}
			return instance_private;
		}
	}
	

	//	*---------------- REFACTORED

	public static Common CloneZombiPrefab(string key)
	{
		return CloneZombiPrefab (key, new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0)).GetComponent<Common>();
	}
	
	public static Common CloneZombiPrefab(string key, Vector3 positon, Quaternion rotation)
	{
		GameObject go = GameObject.Instantiate (ZombiDict [key], positon, rotation) as GameObject;
		go.GetComponent<Common>().InitBy (ZombiDict [key].GetComponent<Common>());
		go.name = key;
		return go.GetComponent<Common>();
	}


	public static Dictionary<string,int> CreateEmptyTypeDictionary()
	{
		Dictionary<string, int> output = new Dictionary<string, int > ();
		
		foreach(string key in worldXSingelton.ZombiKnownTypes)
			output.Add(key,0);
		
		return output;
	}
}
