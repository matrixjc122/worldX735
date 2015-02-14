using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class RuleUtil {

	public static Dictionary<string,int> GetHitsFor(GameObject centerObject, bool [,] Neighborhood)
	{
		Vector2 pos_self = centerObject.GetComponent<Common> ().FigurePosition;
		Dictionary<string,int> dict = worldXSingelton.CreateEmptyTypeDictionary ();
		
		for (int x =0; x < Neighborhood.GetLength(0); x++) 
		{
			for (int y =0; y < Neighborhood.GetLength(1); y++) 
			{
				if(Neighborhood[x,y] == true)
				{
					int width = worldXSingelton.WorldObjects.GetLength(0);
					int height = worldXSingelton.WorldObjects.GetLength(1);
					int world_width = worldXSingelton.WorldObjects.GetLength(0);
					int world_height = worldXSingelton.WorldObjects.GetLength(1);
					
					//go to upper left corner of the mask array relative to current pos_self
					Vector2 pos_local = pos_self + new Vector2(-1,-1);
					
					pos_local.x += x;
					pos_local.y += y;
					
					
					if(pos_local.x < 0)
					{
						//						Debug.Log(pos_ul.x + x);
						continue;
					}
					if(pos_local.x >= width && pos_local.x >= world_width)
					{
						//						Debug.Log(pos_ul.x + x);
						continue;
					}
					if(pos_local.y < 0)
					{
						//						Debug.Log(pos_ul.y + y);
						continue;
					}
					if(pos_local.y >= height && pos_local.y >= world_height)
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
	
}

	