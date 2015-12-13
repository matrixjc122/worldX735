using System;
using RuleAdministration.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using System.Collections;
	
namespace RuleAdministration.Rules
{
	public class SAUpgrade : SAExpand
	{
		
		public override string Name ()
		{
			return "Upgrade";
		}
		
		public override void AfterUpdate ()
		{
			//			ActionAdministrator.Instance.ApplyAction <SARandomTransform>(_Tile);
			_Tile._Pal._Health -= 1;
		}
		
		public override bool IsApplicable ()
		{
			return base.IsApplicable();
		}
		
		public override void BeforeUpdate()
		{
			if(_Tile._Pal._Type.Equals("None"))
			{
				switch(_Tile._Floor._Type)
				{
				case "tile_boden" : base._SelectedType = "pal_A"; break;
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
			
			base.BeforeUpdate();
		}
			
		
	}
}

