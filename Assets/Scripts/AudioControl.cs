using UnityEngine;
using System.Collections;

public class AudioControl : MonoBehaviour {

	private AudioSource[] _audioSource;

	// Use this for initialization
	void Start () {
		_audioSource = this.GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound(string type){

		switch(type){
		
		case "KoralleA":
			_audioSource[0].Play ();
			break;
		
		case "KoralleB":
			_audioSource[1].Play ();
			break;
		
		case "KoralleC":
			_audioSource[2].Play ();
			break;

		case "KoralleD":
			_audioSource[3].Play ();
			break;
		}
		
	}

}
