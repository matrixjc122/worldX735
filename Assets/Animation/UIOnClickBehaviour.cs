using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIOnClickBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button b = gameObject.GetComponent<Button>();
		b.onClick.AddListener(() => OnClick());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		if (gameObject.name == "Button_A")
						Paradise.Intance.UISelectedType = "pal_A";
				else if (gameObject.name == "Button_B")
						Paradise.Intance.UISelectedType = "pal_B";
				else if (gameObject.name == "Button_C")
						Paradise.Intance.UISelectedType = "pal_C";
				else if (gameObject.name == "Button_Boden")
						Paradise.Intance.UISelectedType = "Boden";
				else
						Debug.Log ("Button behaviour not set");
	}

}
