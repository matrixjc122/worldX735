using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class worldXMain : MonoBehaviour {

	public string[] rules; 

	
	// Use this for initialization
	void Start () {

		// Game setup

		worldXSingelton.StaticInitialisation (new Vector2 (20, 20) );

		worldXSingelton.LoadZombiPrefab ("Boden");
		worldXSingelton.LoadZombiPrefab ("A");
		worldXSingelton.LoadZombiPrefab ("B");
		worldXSingelton.LoadZombiPrefab ("C");
		

		this.InitializeWorld ();

	}
	
	void InitializeWorld()
	{
	

		Common[,] objects = worldXSingelton.WorldObjects;
		for (int x = 0; x < objects.GetLength(0); x++) 
		{
			for (int y = 0; y < objects.GetLength(1); y++) 
			{
				Vector3 displacment = new Vector3(x,0,y);
				Vector3 offset = new Vector3(-objects.GetLength(0)/2.0f,0,-objects.GetLength(1)/2.0f);


				if( x == objects.GetLength(0)/2 && y == objects.GetLength(1)/2)
				{
					objects[x,y] = worldXSingelton.CloneZombiPrefab("A", displacment + offset, transform.rotation);
					objects[x,y].GetComponent<Common>().FigureType = "A";
				}else{
					objects[x,y] = worldXSingelton.CloneZombiPrefab("Boden", displacment + offset, transform.rotation);
					objects[x,y].GetComponent<Common>().FigureType = "Boden";
				}


				objects[x,y].GetComponent<Common>().FigurePosition = new Vector2(x,y);
				objects[x,y].gameObject.SetActive(true);
			}
		}

	}

}