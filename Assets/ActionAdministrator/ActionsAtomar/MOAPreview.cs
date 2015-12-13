using System;
using RuleAdministration.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using System.Collections;

namespace RuleAdministration.Rules
{
	public class MOAPreview : SAExpand
	{
		
		public enum Stats{EXIT,ENTER};
		static private GameObject prefab;
		public Stats _Status;
		
		public override string Name ()
		{
			return "MOAPreview";
		}
		
		
		public override bool IsApplicable()
		{
			Debug.Log("Status " + _Status);
			if(_Status == Stats.EXIT) return true;
			Debug.Log("Tile: " +(bool)( _Tile != null));
			Debug.Log("Pal: " + (bool)(_Tile._Pal != null));
			
			
			if(_Tile._Pal._Type.Equals("None"))
			{
				// switch floor type
				switch(_Tile._Floor._Type)
				{
				case "tile_boden" : base._SelectedType = "pal_A"; break;
					// more appearence types
				}
			}else
			{
				// switch pal tile
				switch(_Tile._Pal._Type)
				{
					
				case "pal_A" : base._SelectedType = "pal_B"; break;
				case "pal_B" : base._SelectedType = "pal_C"; break;
				}
			}
			
			return base.IsApplicable();
		}
		
		
		public override void Update ()
		{
			Debug.Log(_Status);
			if(_Status == Stats.ENTER)
			{
				prefab = this._Tile.MakePrefab(base._SelectedType);
				prefab.SetActive(true);
				Color col = prefab.GetComponent<MeshRenderer>().material.color;
				col.a = 0.5f;
				if(this._Tile._Pal._Appearence)
					this._Tile._Pal._Appearence.SetActive(false);
			}
			if(_Status == Stats.EXIT && prefab != null) 
			{
				prefab.SetActive(false);
				GameObject.DestroyImmediate(prefab);
				if(this._Tile._Pal._Appearence)
					this._Tile._Pal._Appearence.SetActive(true);
			}
			
		}
		
	}
}

