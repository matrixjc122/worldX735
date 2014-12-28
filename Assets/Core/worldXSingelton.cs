using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Coral
{
	public string name;
	public List<string> behaviours;
}

public class worldXSingelton
{
	private static worldXSingelton instance;
	public GameObject[,] m_GameObjects = null;
	public int[,] m_BehavioralMatrix = {{5,-1,-1},{4,0,-1},{-1,-1,-1}};
	public Vector2 m_WorldSize{ set; get;}
	public string m_CoralType{ set; get;}
	// Dict<string , Dict<string, string> > in zukunft
	public Dictionary<string, List<string> > m_CoralPropertyDict = new Dictionary<string, List<string> > (); 
	public Dictionary<string, GameObject > m_CoralPrefabDict = new Dictionary<string, GameObject >();

	
	private worldXSingelton() 
	{
	}
	
	public static worldXSingelton Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new worldXSingelton();
			}
			return instance;
		}
	}
	
	public void InitializeGameObjects (Vector2 size)
	{

		if (m_GameObjects == null) 
			m_GameObjects = new GameObject[(int)size.x, (int)size.y];
	}

	public void AddCoralDefinition(string typeName, params string[] behaviourName)
	{
		m_CoralPropertyDict.Add(typeName, new List<string>(behaviourName));
	}

	public void AddCoralGameObject(string typeName)
	{
		m_CoralPrefabDict.Add (typeName, GameObject.Instantiate (Resources.Load (typeName)) as GameObject);
		m_CoralPrefabDict [typeName].name = typeName;
		foreach( string behaviour in m_CoralPropertyDict[typeName])
		{
			m_CoralPrefabDict[typeName].AddComponent(behaviour);
		}
		m_CoralPrefabDict[typeName].SetActive(false);
	}

	public GameObject InstantiatePrefab(string key)
	{

		return InstantiatePrefab (key, new Vector3 (0, 0, 0), new Quaternion (0, 0, 0, 0));
	}

	public GameObject InstantiatePrefab(string key, Vector3 positon, Quaternion rotation)
	{
		GameObject go = GameObject.Instantiate (m_CoralPrefabDict [key], positon, rotation) as GameObject;
		//go.tag = key;
		return go;
	}

//	public void 


}
