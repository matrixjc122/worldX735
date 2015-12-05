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
	public class SADowngrade : IAction
	{
			
		public override string Name ()
		{
			return "Downgrade";
		}
			
		public override void Update ()
		{
			string new_type = "Boden";
			// Get previouse 
			switch (Tile.Pal.Base().Type) {
			case "C":
				new_type = "B";
				break;
			case "B":
				new_type = "A";
				break;
			case "A":
				new_type = "Boden";
				break;
			}
			SAExpand expandAction = new SAExpand();
			expandAction.SetTypeName (new_type);
			ActionAdministrator.Instance.ApplyAction (expandAction, Tile);
		
		}
		
	}
}

