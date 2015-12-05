

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public  class worldXSingelton
{
	private static worldXSingelton instance_private;
	public static Base[,] Layer2Objects{ set;get;}
	public static Base[,] Layer4Nutrients{ set;get;}
	public static Base[,] Layer3Floor{ set;get;}

	public static Vector2 WorldSize{ set; get;}

	private static Dictionary<string, GameObject > ZombiDict{ set; get;}
	public static  Dictionary<string, GameObject >.KeyCollection ZombiKnownTypes{ set;get;}

	public static string UISelectedType{ set; get;}
	public static bool UIOnly{ set; get;}
	public static bool UIAction{ set; get;}
	
	public static Base Generic(GameObject obj)
	{
		if(obj.GetComponent<Base>() != null)
			return obj.GetComponent<Base>();
			
			
		if(obj.GetComponent<Pal>() != null)
			return obj.GetComponent<Pal>().Base();
			
			
		if(obj.GetComponent<Nutrients>() != null) 
			return obj.GetComponent<Nutrients>().Base();
		
				
		if(obj.GetComponent<Floor>() != null)
			return obj.GetComponent<Floor>().Base();
			
		return null;
	}

	// *---------------- STATIC
	public static void LoadZombiPrefab(string typeName)
	{
		GameObject zombi = GameObject.Instantiate (Resources.Load (typeName)) as GameObject;
		zombi.name = "zombi-" + typeName;
		zombi.SetActive(false); // mark it as zombi
		ZombiDict.Add (typeName, zombi);
		ZombiKnownTypes = ZombiDict.Keys;
	}

	public static void StaticInitialisation(Vector2 worldSize)
	{
		instance_private = new worldXSingelton();
		WorldSize = worldSize;
		Layer2Objects = new Base[(int)worldXSingelton.WorldSize.x, (int)worldXSingelton.WorldSize.y];
		Layer3Floor = new Base[(int)worldXSingelton.WorldSize.x, (int)worldXSingelton.WorldSize.y];
		Layer4Nutrients = new Base[(int)worldXSingelton.WorldSize.x, (int)worldXSingelton.WorldSize.y];
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

	public static Pal CloneZombiPrefab(string key)
	{
		return CloneZombiPrefab (key, new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0)).GetComponent<Pal>();
	}
	
	public static GameObject CloneZombiPrefab(string key, Vector3 positon, Quaternion rotation)
	{
		GameObject go = GameObject.Instantiate (ZombiDict [key], positon, rotation) as GameObject;
		go.GetComponent<Base>().InitBy (ZombiDict [key].GetComponent<Base>());
		go.name = key;
		return go;
	}


	public static Dictionary<string,int> CreateEmptyTypeDictionary()
	{
		Dictionary<string, int> output = new Dictionary<string, int > ();
		
		foreach(string key in worldXSingelton.ZombiKnownTypes)
			output.Add(key,0);
		
		return output;
	}
	
}
