using UnityEngine;
using System.Collections;

public class CoralCommon : CoralBase {
	
	public virtual void OnMouseDown() {

		string current_coral_type = worldXSingelton.Instance.m_CoralType;
		GameObject prefab = worldXSingelton.Instance.InstantiatePrefab (current_coral_type, gameObject.transform.position, gameObject.transform.rotation);

		foreach (string bv in worldXSingelton.Instance.m_CoralPropertyDict[current_coral_type]) 
			(prefab.GetComponent(bv) as CoralBase) .CopyOf( gameObject.GetComponent(bv) as CoralBase);

		prefab.SetActive (true);

		/*
		foreach (GameObject obj in worldXSingelton.Instance.m_GameObjects)
			if(obj != null)
				obj.GetComponent<CoralRotation>().RandomizeTransformations();
		*/

		//Debug.Log( prefab.GetComponent<CoralNeighborhood>().m_ArrayPosition + " " + prefab.tag );
		Destroy (gameObject);
	}

	#region CoralInterface implementation

	public override CoralBase CopyOf (CoralBase other)
	{
		return this;
	}

	#endregion
}