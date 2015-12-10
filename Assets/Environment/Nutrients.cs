using UnityEngine;
using System.Collections;

public class Nutrients : Base 
{
	public int _CurrentNutrients{set; get;}
	public int _MaxNutrientsCapacity{set; get;}
	
	public int _CurrentWater{set; get;}
	public int _MaxWaterCapacity{set; get;}

	public void InitBy(Base other)
	{
		this._CurrentNutrients = other.GetComponent<Nutrients>()._CurrentNutrients;
		this._CurrentWater = other.GetComponent<Nutrients>()._CurrentWater;
	}

	// Use this for initialization
	public override void Start () {
		_MaxNutrientsCapacity = _CurrentNutrients = 100;
		_MaxWaterCapacity = _CurrentWater = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Base GetBase ()
	{
		return gameObject.GetComponent<Base>();
	}

}
