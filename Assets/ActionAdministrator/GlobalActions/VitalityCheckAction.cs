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
		
		foreach (GameObject obj in list) {
			Common obj_common = obj.GetComponent<Common> ();
			if (obj_common == null) { 
				Debug.LogError ("The passed object is not placable. It doesn't contain a Common behaviour.");
				return false;
			}					
			
			//status &= CheckEnvironment (obj.GetComponent<Common> ().FigurePosition, m_TypeName);
		}
		return status;
	}

	public bool Update (params GameObject[] list)
	{
		foreach (GameObject obj in list) 
		{
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
		return true;
	}

	public string Name ()
	{
		throw new System.NotImplementedException ();
	}

	public void BeforeUpdate (params GameObject[] list)
	{

	}
	
	#endregion
}
