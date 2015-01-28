using UnityEngine;
using System.Collections;

public class CoralColor : CoralBase {
	
	void Start () {

				
		string current_coral_type = worldXSingelton.Instance.m_CoralType;
					
								
						

						
		if(current_coral_type == "TrichterC3_A0"){

		}

	}
		

	#region CoralInterface implementation

	public override CoralBase CopyOf (CoralBase other)
	{
		return this;
	}

	#endregion
}