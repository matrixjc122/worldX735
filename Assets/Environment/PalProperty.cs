using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class PalProperty : BaseProperty {

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
	
	
	
	
	
	
}	 