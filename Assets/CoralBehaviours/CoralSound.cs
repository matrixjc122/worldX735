using UnityEngine;
using System.Collections;

public class CoralSound : CoralBase {
	
	public virtual void OnMouseDown() {

		string current_coral_type = worldXSingelton.Instance.m_CoralType;

		if(current_coral_type == "TrichterC3_A0"){
		GameObject.Find("audioDummy").GetComponent<AudioControl>().PlaySound("KoralleA");
		}

		if(current_coral_type == "TrichterC3_A1"){
		GameObject.Find("audioDummy").GetComponent<AudioControl>().PlaySound("KoralleB");
		}

		if(current_coral_type == "TrichterC3_A2"){
		GameObject.Find("audioDummy").GetComponent<AudioControl>().PlaySound("KoralleC");
		}

		if(current_coral_type == "TrichterC3_A3"){
			GameObject.Find("audioDummy").GetComponent<AudioControl>().PlaySound("KoralleD");
		}
	}

	#region CoralInterface implementation

	public override CoralBase CopyOf (CoralBase other)
	{
		return this;
	}

	#endregion
}