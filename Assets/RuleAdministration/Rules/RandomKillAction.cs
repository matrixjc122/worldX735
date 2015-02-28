using UnityEngine;
using System.Collections;
using RuleAdministration.Interfaces;
using RuleAdministration.Rules;

public class RandomKillAction : IAction {
	#region IAction implementation


	public RespawnAction a = null;

	public bool IsApplicable (GameObject obj)
	{
		Common obj_common = obj.GetComponent<Common> ();
		if (obj_common == null) { 
			Debug.LogError ("The passed object is not placable. It doesn't contain a Common behaviour.");
			return false;
		}
		
		return true;
		
//		bool status = Random.Range(0.0f,1.0f) > 0.5;
//		if(status){
////				a = new RespawnAction();
////				a.SetTypeName("Boden");
////				status = a.IsApplicable(obj);
//		}

		//return status;
	}

	public bool ProcessAction (GameObject obj)
	{
		Common obj_common = obj.GetComponent<Common> ();
		if(Random.Range(0.0f,1.0f) >= 0.33)// HIT
		{	
			obj_common.FigureWillpower -= Random.Range(0.8f,0.9f); // DECREASE WILLPOWER
		}
		
		if(obj_common.FigureWillpower <= 0.0f)
		{
			
		}
		return true;
	}

	public string Name ()
	{
		return "RandomKillAction";
	}

	#endregion	
}
