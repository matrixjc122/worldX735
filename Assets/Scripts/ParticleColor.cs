using UnityEngine;
using System.Collections;

public class ParticleColor : MonoBehaviour {


	// Use this for initialization
	void Start () {
		renderer.material.SetColor ("_TintColor", Color.red);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
