﻿//------------------------------------------------------------------------------
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
	public class KillAction : IAction
	{
		
		public KillAction ()
		{
			
		}
			
		public bool IsApplicable (params  GameObject[] list)
		{
			return true;
		}
		
		public string Name ()
		{
			return "KillAction";
		}
		
		public void Update (params GameObject[] list)
		{
			
		}
		
		public void BeforeUpdate (params GameObject[] list)
		{
		
		}
		
	}
}

