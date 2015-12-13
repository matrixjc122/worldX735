using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;
using UnityEngine;

public class Paradise : MonoBehaviour
{

	private static GameObject m_InstanceHolder = null;

	public static Paradise Intance {
		get {
			if (m_InstanceHolder == null) {
				
				m_InstanceHolder = GameObject.Find ("ParadiseMain");
				
			}
			return m_InstanceHolder.GetComponent<Paradise> ();
		}
	}

	public Tile[,] _TileObjects{ set; get; }

	public Vector2 _WorldSize{ set; get; }

	public string UISelectedType{ set; get; }
	
	GameObject prefab_boden;
	GameObject prefab_palA;
	GameObject prefab_palB;
	GameObject prefab_palC;
	
	public void Start ()
	{
		// Forcing singleton initialization calling the static member function Instance{get} 
		Paradise.Intance._WorldSize = new Vector2 (20, 20);
		
		// Initialize Tiles array (TODO: replace 2D with 1D array)
		this._TileObjects = new Tile[(int)_WorldSize.x, (int)_WorldSize.y];

		// Initialize GUI variables (should be moved)
//		UISelectedType = "pal_A";

		
		
		
		// Position of (x,y) in Tile's array. 
		for (int x = 0; x < Paradise.Intance._WorldSize.x; x++) {
			for (int y = 0; y < Paradise.Intance._WorldSize.y; y++) {
				// Determine Tile's position for (x,y) in world coordinate (x',y')
				// Tiles are fixed in its spacial dimensions e.g. spacial extension of Tile in world unites 1x1x1  
				Vector3 displacment = new Vector3 (x, 0, y); 
				// Centralizing borad game aligned at world space origin
				Vector3 offset = new Vector3 (-_TileObjects.GetLength (0) / 2.0f, 0, -_TileObjects.GetLength (1) / 2.0f);
				Vector3 worldPosition = displacment + offset;
				Vector2 arrayPosition = new Vector2(x,y);
				
				
				// Create an instanz of class Tile.
				GameObject _tileObject = new GameObject("TileObject");
				Tile t = _tileObject.AddComponent<Tile>();
				t.LazyInitialisation(worldPosition, arrayPosition);
				
				// Assign tile to 2d array
				this._TileObjects [(int)x, (int)y] = t; 
				if(_TileObjects.GetLength (0) / 2.0f == x && _TileObjects.GetLength (1) / 2.0f == y)
				{
					t.AccosiateType<Pal>("pal_A");	
				}
				t.AccosiateType<Floor>( "tile_boden");
				
				
				_tileObject.SetActive (true); // Becomes alive
				
			}
		}

	}

}