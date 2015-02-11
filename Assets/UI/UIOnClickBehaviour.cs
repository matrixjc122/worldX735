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
		if (gameObject.name == "ButtonA")
			worldXSingelton.UISelectedType = "A";
		if (gameObject.name == "ButtonB")
			worldXSingelton.UISelectedType = "B";
		if (gameObject.name == "ButtonC")
			worldXSingelton.UISelectedType = "C";
		if (gameObject.name == "ButtonBoden")
			worldXSingelton.UISelectedType = "Boden";
	}

}
