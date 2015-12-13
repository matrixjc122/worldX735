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
		
		static private GameObject prefab;
		public bool _Enable;
		
		public override string Name ()
		{
			return "MOAPreview";
		}
		
		
		public override bool IsApplicable()
		{
		
			if(_Enable == false) return true;
			
			if(_Tile._Pal._Type.Equals("None"))
			{
				// switch floor type
				switch(_Tile._Floor._Type)
				{
				case "tile_boden" : base._SelectedType = "pal_A"; break;
				case "pal_A" : base._SelectedType = "pal_B"; break;
				case "pal_B" : base._SelectedType = "pal_C"; break;
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
			if(_Enable)
			{
				prefab = this._Tile.MakePrefab(base._SelectedType);
				prefab.SetActive(true);
				if(this._Tile._Pal._Appearence)
					this._Tile._Pal._Appearence.SetActive(false);
			}else
			{
				prefab.SetActive(false);
				GameObject.Destroy(prefab);
				if(this._Tile._Pal._Appearence)
					this._Tile._Pal._Appearence.SetActive(true);
			}
			
		}
		
	}
}

