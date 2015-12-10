using UnityEngine;
using System.Collections;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;
using System.Collections.Generic;

public class Floor : Base, IAppearenceChangable
{

	public float _FloorPeneltryRate{ get; set; }
	
	// Use this for initialization
	override public void Start ()
	{
		_FloorPeneltryRate = 0.95f;
		_MeshDict = new Dictionary<string, Mesh>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// do something with penelty rate
	}
	

//	public virtual void OnMouseDown ()
//	{
//		
//		Vector2 pos = this._Tile._Position;
//		Debug.LogError ("OnMouseDown Floor: " + pos);
//		
//		ActionAdministrator.Instance.ApplyAction<SAUpgrade> (this._Tile);
//			
//	}

	public virtual Dictionary<string, Mesh> _MeshDict{ set; get; }

	public void ChangeType(string targetType)
	{
	
	
		if(targetType.Equals(this._Type)) return;
		// save appearence definition definition
		this._Type = targetType;
		// Remove existing filters
		MeshFilter.DestroyImmediate(base.gameObject.GetComponent<MeshFilter>());
		
		// replace with target meshes
		// first check appearence existence 
		if(_MeshDict.ContainsKey(targetType))
		{
			base.gameObject.AddComponent<MeshFilter>().mesh = _MeshDict[targetType];
			
		}else if(true)
		{
			/*LAYZY PREFAB MESH LOADING HERE*/
			// check existence of target
			// add to _Meshes
			// or discard job
		}
		
	}

}
