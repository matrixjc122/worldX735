using UnityEngine;
using System.Collections;
using RuleAdministration.Interfaces;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class VitalityCheckAction : IAction {

	#region IAction implementation

	public bool IsApplicable (params GameObject[] list)
	{
		bool status = true;
		return status;
	}

	public bool Update (params GameObject[] list)
	{
		
		foreach (GameObject obj in list) 
		{
		
			float val = Random.Range(0.0f,1.0f);
			if(val <= 0.1f)
			{
				ExpandAction kill = new ExpandAction();
				kill.SetTypeName("Boden");
				ActionAdministrator.Instance.ApplyAction(kill,obj);
			}else if(val > 0.75f ) {
				switch(obj.GetComponent<Common>().FigureType)
				{
				case "A": 
				{
					ExpandAction upgrade = new ExpandAction();
					upgrade.SetTypeName("B");
					ActionAdministrator.Instance.ApplyAction(upgrade,obj);
				}
					break;
				case "B":
				{
					ExpandAction upgrade = new ExpandAction();
					upgrade.SetTypeName("C");
					ActionAdministrator.Instance.ApplyAction(upgrade,obj);
				}
					break;
				}
			}
		}
		return true;
	}

	public string Name ()
	{
		return "VitalityAction";
	}

	public void BeforeUpdate (params GameObject[] list)
	{

	}
	
	#endregion
}
