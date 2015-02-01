using UnityEngine;
using System.Collections;

public class ExtraEigenschaften : MonoBehaviour {


	public Renderer[] _renderers;
	public Color[] _colors;


void Start() {

	//fill array with renderers of children objects
	_renderers = gameObject.GetComponentsInChildren<Renderer> ();

	//generate random colors
	float r = Random.value;
	float g = Random.value;
	float b = Random.value;
	
	//assign color to objects
	for ( int x = 0; x < _renderers.Length; x++ ) {

		if( _renderers[x].gameObject.name != "Terrain_Boden"){
			_renderers[x].material.SetColor ("_Color", new Color(r,g,b));
		}
	}


}
}



