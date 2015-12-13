using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class Pal : Base {

	// Properties
	public virtual int NutrientsStorage{set;get;}
	public virtual int RootCapacity{set;get;}
	public virtual int NutritesConsumeRate{set;get;}
	public virtual float PalCurrentEnergy{set; get;}

	
	public void ConsumeNutrients()
	{
//		Tile tile = new Tile(this._Appearence._Position.x,this._Appearence._Position.y);
//		this.NutrientsStorage = this.NutrientsStorage - this.NutritesConsumeRate 
//			+ (int)(this.RootCapacity * tile._Floor._FloorPeneltryRate 
//			* tile._Nutrients._CurrentNutrients/tile._Nutrients._MaxNutrientsCapacity
//			* tile._Nutrients._CurrentWater/tile._Nutrients._MaxWaterCapacity);
		
	}
	
	override public void Start()
	{
		this._Type = "None";
		this._Health = 100;	
	}
	
	
	public void OnGUI() {
		
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		Rect rec = new Rect(targetPos.x, Screen.height - targetPos.y, 40, 20);
		
		GUI.Label(rec, (int)(this._Health) + "");
		
	}
	
	
	
}	 