

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public  class worldXSingelton
{
	private static worldXSingelton instance_private;
	public static GameObject[,] WorldObjects{ set;get;}

	public static Vector2 WorldSize{ set; get;}

	private static Dictionary<string, GameObject > ZombiDict{ set; get;}
	public static  Dictionary<string, GameObject >.KeyCollection ZombiKnownTypes{ set;get;}

	public static string UISelectedType{ set; get;}
	public static bool UIOnly{ set; get;}
	

	// *---------------- STATIC
	public static void LoadZombiPrefab(string typeName)
	{


		GameObject zombi = GameObject.Instantiate (Resources.Load (typeName)) as GameObject;

		zombi.GetComponent<Common>().FigureType = typeName;
		zombi.SetActive(false); // mark it as zombi
		
		ZombiDict.Add (typeName, zombi);

		ZombiKnownTypes = ZombiDict.Keys;

	}

	public static void StaticInitialisation(Vector2 worldSize)
	{
		instance_private = new worldXSingelton();
		WorldSize = worldSize;
		WorldObjects = new GameObject[(int)worldXSingelton.WorldSize.x, (int)worldXSingelton.WorldSize.y];
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

	public static GameObject CloneZombiPrefab(string key)
	{
		return CloneZombiPrefab (key, new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
	}
	
	public static GameObject CloneZombiPrefab(string key, Vector3 positon, Quaternion rotation)
	{
		GameObject go = GameObject.Instantiate (ZombiDict [key], positon, rotation) as GameObject;
		go.GetComponent<Common> ().InitBy (ZombiDict [key].GetComponent<Common>());
		return go;
	}



}
