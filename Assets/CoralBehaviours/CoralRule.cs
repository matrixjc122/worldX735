using UnityEngine;
using System.Collections;

public class CoralRule : AbstractRule {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region IRule implementation

	public override bool isApplicable ()
	{
		return false;
	}

	public override bool isPlaceable ()
	{
		return false;
	}

	#endregion
}
