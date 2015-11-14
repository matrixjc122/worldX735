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
		
			
		public SAExpand ()
		{
			
		}
		
		public Common CurrentObject{get;set;}

		public void SetObject (Common obj)
		{
			CurrentObject = obj;
			
		}
								
		private string m_TypeName = worldXSingelton.UISelectedType;
		
		public void SetTypeName (string typename)
		{
			m_TypeName = typename;
		}
					
		/// <summary>
		/// Determines whether this instance is applicable.
		/// </summary>
		/// <returns><c>true</c> if this instance is applicable; otherwise, <c>false</c>.</returns>
		public bool IsApplicable ()
		{	
			return CheckEnvironment (CurrentObject.FigurePosition, m_TypeName);
		}
			
		public string Name ()
		{
			return "Expand";
		}
			
		public void Update ()
		{
			
			Common spawnObject = worldXSingelton.CloneZombiPrefab (m_TypeName, CurrentObject.transform.position, Quaternion.identity);
			spawnObject.GetComponent<Common> ().FigurePosition = CurrentObject.GetComponent<Common> ().FigurePosition;
			spawnObject.GetComponent<Common> ().FigureType = m_TypeName;
								
			Vector2 FigurePosition = spawnObject.GetComponent<Common> ().FigurePosition;
			worldXSingelton.WorldObjects [(int)FigurePosition.x, (int)FigurePosition.y] = spawnObject;
			spawnObject.gameObject.SetActive (true);
			spawnObject.name = m_TypeName;
			
			ActionAdministrator.Instance.ApplyAction <SARandomTransform> (spawnObject);
			GameObject.Destroy (CurrentObject.gameObject);
			
			CurrentObject = spawnObject as Common;
			
		}

		public void BeforeUpdate ()
		{
		}
			
			
		private bool[,] Neighborhood = new bool[3, 3]{ 
			{true,true,true},
			{true, false , true},
			{ true,true,true} };
			
		public bool CheckEnvironment (Vector2 center_pos, string type)
		{
					
			Dictionary<string, int> hits = RuleUtil.GetHitsFor (center_pos, Neighborhood);
								
			bool status = false;
		
				
		switch (type) {
		case("Boden"):
				status = true;
				break;
		case("A"):
				status = (hits ["A"] >= 1 || hits ["B"] >= 1 || hits ["C"] >= 1) // Or'd Minimal requirements
						&& hits ["A"] <= 4 && hits ["B"] <= 4 && hits ["C"] <= 4;
				break;
		case("B"):
				status = hits ["A"] >= 3 && hits ["A"] < int.MaxValue
						&& hits ["B"] >= 0 && hits ["B"] <= 0 
						&& hits ["C"] >= 0 && hits ["C"] < int.MaxValue;
				break;
		case("C"):
				status = hits ["A"] >= 3 && hits ["A"] < int.MaxValue
						&& hits ["B"] >= 2 && hits ["B"] < int.MaxValue
						&& hits ["C"] >= 0 && hits ["C"] < int.MaxValue;
								         
					break;
			}
				return status;
			}
		
		
	}
}

