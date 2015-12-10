using System;
using RuleAdministration.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using System.Collections;
	
namespace RuleAdministration.Rules
{
	public class SAUpgrade : IAction
	{
		
		public override string Name ()
		{
			return "Upgrade";
		}
			
		public override void Update ()
		{
			string new_type = "pal_C";
			
			// Get next gen. object type
			switch(_Tile._Pal._Type)
			{
			case "Boden" : new_type = "pal_A"; break;
			case "pal_A" : new_type = "pal_B"; break;
			case "pal_B" : new_type = "pal_C"; break;
			}
			
			
			// Reuse ExpandAction for placing object
			SAExpand expandAction = new SAExpand();
			expandAction.SetTypeName(new_type);
			ActionAdministrator.Instance.ApplyAction(expandAction,_Tile);
						
		}
		
	}
}

