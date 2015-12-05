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
	

		Base[,] pals = worldXSingelton.Layer2Objects;
		Base[,] floors = worldXSingelton.Layer3Floor;
		Base[,] nutrients = worldXSingelton.Layer4Nutrients;
		for (int x = 0; x < pals.GetLength(0); x++) 
		{
			for (int y = 0; y < pals.GetLength(1); y++) 
			{
				Vector3 displacment = new Vector3(x,0,y);
				Vector3 offset = new Vector3(-pals.GetLength(0)/2.0f,0,-pals.GetLength(1)/2.0f);


				if( x == pals.GetLength(0)/2 && y == pals.GetLength(1)/2)
				{
					pals[x,y] = worldXSingelton.CloneZombiPrefab("A", displacment + offset, transform.rotation).GetComponent<Base>();
					pals[x,y].Type = "A";
				}
				
				floors[x,y] = worldXSingelton.CloneZombiPrefab("Boden", displacment + offset, transform.rotation).GetComponent<Base>();
				floors[x,y].Type = "Boden";
				
				
				GameObject obj = new GameObject();
				obj.AddComponent<Base>().Type = "Nut";	
				nutrients[x,y] = obj.AddComponent<Nutrients>().Base();
			
				
				pals[x,y].Position = new Vector2(x,y);
				pals[x,y].gameObject.SetActive(true);
				
				floors[x,y].Position = new Vector2(x,y);
				floors[x,y].gameObject.SetActive(true);
				
				
			}
		}

	}

}