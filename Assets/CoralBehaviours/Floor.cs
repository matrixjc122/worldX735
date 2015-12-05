using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour, BehavioralUtils  {

	public float m_FloorPeneltryRate;
	
	public void InitBy(Base other){} 
	
	// Use this for initialization
	void Start () {
		m_FloorPeneltryRate = 0.95f;
	}
	
	// Update is called once per frame
	void Update () {
		// do something with penelty rate
	}

	public Base Base ()
	{
		return gameObject.GetComponent<Base>();
	}

}
