//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using RuleAdministration.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using System.Collections;
	
namespace RuleAdministration.Rules
{
	public class SAExpand : IAction
	{
								
		public string _SelectedType = Paradise.Intance.UISelectedType;
		
		public void SetTypeName (string typename)
		{
			_SelectedType = typename;
		}
					
		/// <summary>
		/// Determines whether this instance is applicable.
		/// </summary>
		/// <returns><c>true</c> if this instance is applicable; otherwise, <c>false</c>.</returns>
		public override bool IsApplicable ()
		{	
			return CheckEnvironment (_Tile._Position, _SelectedType);
		}
			
		public override string Name ()
		{
			return "Expand";
		}
			
		public override void Update ()
		{
			
			this._Tile.AccosiateType<PalProperty>(_SelectedType);
			MOAPreview action = new MOAPreview ();
			action._Status = MOAPreview.Stats.EXIT;
			ActionAdministrator.Instance.ApplyAction (action, _Tile);

		}
		
		
			
		private bool[,] Neighborhood = new bool[3, 3]{ 
			{true,true,true},
			{true, false , true},
			{ true,true,true} };
			
		public bool CheckEnvironment (Vector2 pos, string type)
		{
//			Debug.LogError(pos + " : " + type);
			Dictionary<string, int> hits = RuleUtil.GetHitsFor (pos, Neighborhood,new Dictionary<string,int>()
			{
				{"pal_A", 0},
				{"pal_B", 0},
				{"pal_C", 0},
				{"tile_boden", 0}
			});
								
			bool status = false;
		
				
		switch (type) {
		case("tile_boden"):
				status = true;
//				Debug.Log ("Boden found");
				break;
		case("pal_A"):
				status = (hits ["pal_A"] >= 1 || hits ["pal_B"] >= 1 || hits ["pal_C"] >= 1) // Or'd Minimal requirements
						&& hits ["pal_A"] <= 4 && hits ["pal_B"] <= 4 && hits ["pal_C"] <= 4;
//				Debug.Log ("A found " + status);
				break;
		case("pal_B"):
				status = hits ["pal_A"] >= 3 && hits ["pal_A"] < int.MaxValue
						&& hits ["pal_B"] >= 0 && hits ["pal_B"] <= 0 
						&& hits ["pal_C"] >= 0 && hits ["pal_C"] < int.MaxValue;
//				Debug.Log ("B found " + status);
				break;
		case("pal_C"):
				status = hits ["pal_A"] >= 3 && hits ["pal_A"] < int.MaxValue
						&& hits ["pal_B"] >= 2 && hits ["pal_B"] < int.MaxValue
						&& hits ["pal_C"] >= 0 && hits ["pal_C"] < int.MaxValue;
//				Debug.Log ("C found " + status);	         
					break;
			}
				return status;
			}
		
		
	}
}

