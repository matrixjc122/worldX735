using UnityEngine;
using System.Collections;

public class UIMain : MonoBehaviour {

	// Use this for initialization
	void OnGUI()
	{
		// Make a group on the center of the screen
		GUILayout.BeginArea (new Rect(0,Screen.height*0.5f-50,100,200));

		IEnumerable keyCollection = worldXSingelton.Instance.m_CoralPropertyDict.Keys;

		foreach (string coral_name in keyCollection) 
		{
			if(GUILayout.Button (coral_name))
			{
				Debug.Log(coral_name + " selected!");
				worldXSingelton.Instance.m_CoralType = coral_name;

			}
		}

		// End the group we started above. This is very important to remember!
		GUILayout.EndArea ();
	}
}
