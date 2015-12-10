using UnityEngine;
using System.Collections;
using RuleAdministration.Interfaces;
using RuleAdministration.Administrators;

public class Tile {
	
	public Vector2 _Position{set;get;}
	
	public Tile(float x, float y)
	{
		_Position = new Vector2(x,y);
	}
	
		
	public Pal _Pal{set;get;}
	public Floor _Floor{set;get;}
	public Nutrients _Nutrients{set;get;}
	public GameObject gameObject{set; get;}
	
}
