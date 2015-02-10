using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class RuleUtil {

	public static bool[,] structureArrayPointer = new bool[3,3]
	{
		{true,true,true},
		{true,false,true},
		{true,true,true}
	};


	public static Dictionary<string,int> CreateEmptyTypeDictionary()
	{
		Dictionary<string, int> output = new Dictionary<string, int > ();

		foreach(string key in worldXSingelton.ZombiKnownTypes)
			output.Add(key,0);

		return output;
	}

	public static Dictionary<string,int> GetHitsFor(GameObject centerObject)
	{
		Vector2 pos_self = centerObject.GetComponent<Common> ().FigurePosition;
		Dictionary<string,int> dict = CreateEmptyTypeDictionary ();

		for (int x =0; x < structureArrayPointer.GetLength(0); x++) 
		{
			for (int y =0; y < structureArrayPointer.GetLength(1); y++) 
			{
				if(structureArrayPointer[x,y] == true)
				{
					int width = worldXSingelton.WorldObjects.GetLength(0);
					int height = worldXSingelton.WorldObjects.GetLength(1);

					//go to upper left corner of the mask array relative to current pos_self
					Vector2 pos_local = pos_self + new Vector2(-1,-1);

					pos_local.x += x;
					pos_local.y += y;


					if(pos_local.x < 0)
					{
						//						Debug.Log(pos_ul.x + x);
						continue;
					}
					if(pos_local.x >= width)
					{
						//						Debug.Log(pos_ul.x + x);
						continue;
					}
					if(pos_local.y < 0)
					{
						//						Debug.Log(pos_ul.y + y);
						continue;
					}
					if(pos_local.y >= height)
					{
						//						Debug.Log(pos_ul.y + y);
						continue;
					}


					string neighborObjectName = worldXSingelton.WorldObjects[(int)pos_local.x,(int)pos_local.y].GetComponent<Common>().FigureType;
					if(dict.ContainsKey(neighborObjectName))
						dict[neighborObjectName]++;
				}
			}			
		}
		

  
		return dict;
 }

	public static bool IsPlaceable(GameObject obj)
	{
		Common obj_common = obj.GetComponent<Common> ();
		if(obj_common == null)
		{ 
			Debug.LogError("The passed object is not placable. It doesn't contain a Common behaviour.");
			return false;
		}


		Dictionary<string, int> hits = GetHitsFor (obj);
		string type = obj_common.FigureType;
		bool isPlaceable = false;
		switch (type) {
		case("Boden"):
				isPlaceable = true;
				break;
		case("A"):
			isPlaceable = (hits ["A"] >= 1 || hits ["B"] >= 1 || hits ["C"] >= 1) // Or'd Minimal requirements
				&& hits ["A"] <= 4 && hits ["B"] <= 4 && hits ["C"] <= 4;
				break;
		case("B"):

				isPlaceable = hits ["A"] >= 3 && hits ["A"] < int.MaxValue
						&& hits ["B"] >= 0 && hits ["B"] <= 0 
						&& hits ["C"] >= 0 && hits ["C"] < int.MaxValue;

				break;
		case("C"):

				isPlaceable = hits ["A"] >= 3 && hits ["A"] < int.MaxValue
						&& hits ["B"] >= 2 && hits ["B"] < int.MaxValue
						&& hits ["C"] >= 0 && hits ["C"] < int.MaxValue;

				break;
		}
		return isPlaceable;
		}
	
	
}
