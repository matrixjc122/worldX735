using UnityEngine;
using System.Collections;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;
using System.Collections.Generic;

public class FloorProperty : BaseProperty
{

	public float _FloorPeneltryRate{ get; set; }
	
	// Use this for initialization
	override public void Start ()
	{
		_FloorPeneltryRate = 0.95f;
	}


}
