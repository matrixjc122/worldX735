using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class Pal : Base, IAppearenceChangable {

	// Properties
	public virtual int NutrientsStorage{set;get;}
	public virtual int RootCapacity{set;get;}
	public virtual int NutritesConsumeRate{set;get;}
	public virtual float PalCurrentEnergy{set; get;}

	// Interface realization
	public virtual Dictionary<string, Mesh> _MeshDict{set;get;} 
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
	
	public void ConsumeNutrients()
	{
		Tile tile = new Tile(this._Tile._Position.x,this._Tile._Position.y);
		this.NutrientsStorage = this.NutrientsStorage - this.NutritesConsumeRate 
			+ (int)(this.RootCapacity * tile._Floor._FloorPeneltryRate 
			* tile._Nutrients._CurrentNutrients/tile._Nutrients._MaxNutrientsCapacity
			* tile._Nutrients._CurrentWater/tile._Nutrients._MaxWaterCapacity);
		
	}
	
	override public void Start()
	{
		this._MeshDict = new Dictionary<string, Mesh>();
		this._Type = "None";
		this._Health = 100;	
	}
	
	
	public void OnGUI() {
		
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		Rect rec = new Rect(targetPos.x, Screen.height - targetPos.y, 40, 20);
		
		GUI.Label(rec, (int)(this._Health) + "");
		
	}
	
	
	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	public virtual void OnMouseDown() {

		Debug.LogError("Pal MouseDown");

		ActionAdministrator.Instance.ApplyAction<SAUpgrade>(this._Tile);
		
	}
	
}	 