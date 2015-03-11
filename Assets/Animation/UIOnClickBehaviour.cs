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
						worldXSingelton.UISelectedType = "A";
				else if (gameObject.name == "Button_B")
						worldXSingelton.UISelectedType = "B";
				else if (gameObject.name == "Button_C")
						worldXSingelton.UISelectedType = "C";
				else if (gameObject.name == "Button_Boden")
						worldXSingelton.UISelectedType = "Boden";
				else
						Debug.Log ("Button behaviour not set");
	}

}
