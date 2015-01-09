using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class worldXMain : MonoBehaviour {

	public List<string> CoralTypeBehaviour = new List<string>();
	public Vector2 WorldSize = new Vector2(5,5);
	
	// Use this for initialization
	void Start () {

		// Global Settings
		worldXSingelton.Instance.InitializeGameObjects (WorldSize);

		// Game Settings
		this.ParseCoralTypeBehaviour ();
		this.ParseWorldSize ();
		this.InitializeWorld ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// read out coral information from In-Unity::worldXMain
	// LIST( < <CORAL_PREFAB_NAME> ; <CORAL_BEHAVIOUR>, <CORAL_BEHAVIOUR>, ... > ...)
	// eg.: Coral_Sand;CoralCommon,CoralNeighborhood
	void ParseCoralTypeBehaviour()
	{
		foreach (string coraltype in CoralTypeBehaviour) 
		{
			string typeName; // is the type name of the prefab
			string[] typeBehaviours; // are the names of the behaviour the prefab should have
			
			string[] coral_def = coraltype.Split(';');
			typeName = coral_def[0];
			typeBehaviours = coral_def[1].Split(',');
			worldXSingelton.Instance.AddCoralDefinition(typeName,typeBehaviours);
			worldXSingelton.Instance.AddCoralGameObject(typeName);
		}
	}

	// read out coral information from In-Unity::worldXMain
	void ParseWorldSize()
	{
		worldXSingelton.Instance.m_WorldSize = WorldSize;
	}

	void InitializeWorld()
	{
		GameObject[,] objects = worldXSingelton.Instance.m_GameObjects;
		for (int x = 0; x < objects.GetLength(0); x++) 
		{
			for (int y = 0; y < objects.GetLength(1); y++) 
			{
				Vector3 displacment = new Vector3(x,0,y);
				Vector3 offset = new Vector3(-objects.GetLength(0)/2.0f,0,-objects.GetLength(1)/2.0f);

				objects[x,y] = GameObject.Instantiate(worldXSingelton.Instance.m_CoralPrefabDict["Terrain_Boden"],displacment + offset, transform.rotation) as GameObject;

				objects[x,y].GetComponent<CoralNeighborhood>().m_ArrayPosition = new Vector2(x,y);

				if( x == objects.GetLength(0)/2 && y == objects.GetLength(1)/2)
					objects[x,y] = GameObject.Instantiate(worldXSingelton.Instance.m_CoralPrefabDict["TrichterC"],displacment + offset, transform.rotation) as GameObject;

				// distribute mountains
				int rando = Random.Range(0,25);
				if( rando <= 1  )
					objects[x,y] = GameObject.Instantiate(worldXSingelton.Instance.m_CoralPrefabDict["Terrain_Berg"],displacment + offset, transform.rotation) as GameObject;

				// distribute mountains
				if( rando >= 1 && rando <= 2 )
					objects[x,y] = GameObject.Instantiate(worldXSingelton.Instance.m_CoralPrefabDict["Terrain_Loch"],displacment + offset, transform.rotation) as GameObject;
					
				// distribute A
				if( rando >= 2 && rando <= 5 )
					objects[x,y] = GameObject.Instantiate(worldXSingelton.Instance.m_CoralPrefabDict["TrichterA"],displacment + offset, transform.rotation) as GameObject;

				// distribute B
				if( rando >= 5 && rando <= 7 )
					objects[x,y] = GameObject.Instantiate(worldXSingelton.Instance.m_CoralPrefabDict["TrichterB"],displacment + offset, transform.rotation) as GameObject;

				// distribute C
				if( rando >= 7 && rando <= 8 )
					objects[x,y] = GameObject.Instantiate(worldXSingelton.Instance.m_CoralPrefabDict["TrichterC"],displacment + offset, transform.rotation) as GameObject;

				objects[x,y].SetActive(true);
			}
		}
	}

}