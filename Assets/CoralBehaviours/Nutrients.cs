using UnityEngine;
using System.Collections;

public class Nutrients : MonoBehaviour, BehavioralUtils {



	public int _CurrentNutrients{set; get;}
	public int _MaxNutrientsCapacity{set; get;}
	
	public int _CurrentWater{set; get;}
	public int _MaxWaterCapacity{set; get;}

	// Use this for initialization
	void Start () {
		_MaxNutrientsCapacity = _CurrentNutrients = 100;
		_MaxWaterCapacity = _CurrentWater = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Base Base ()
	{
		return gameObject.GetComponent<Base>();
	}

}
