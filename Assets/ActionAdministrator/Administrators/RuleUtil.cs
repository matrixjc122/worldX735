using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class RuleUtil
{

	public static Dictionary<string,int> GetHitsFor (Vector2 center_pos, bool[,] Neighborhood, Dictionary<string,int> dict)
	{
		//Vector2 pos_self = centerObject.GetComponent<Common> ().FigurePosition;
		
		
		for (int x =0; x < Neighborhood.GetLength(0); x++) {
			for (int y =0; y < Neighborhood.GetLength(1); y++) {
				if (Neighborhood [x, y] == true) {
					int width = Paradise.Intance._TileObjects.GetLength (0);
					int height = Paradise.Intance._TileObjects.GetLength (1);
					int world_width = Paradise.Intance._TileObjects.GetLength (0);
					int world_height = Paradise.Intance._TileObjects.GetLength (1);
					
					//go to upper left corner of the mask array relative to current pos_self
					Vector2 pos = center_pos + new Vector2 (-1, -1);
					
					pos.x += x;
					pos.y += y;
					
					
					if (pos.x < 0) {
						//						Debug.Log(pos_ul.x + x);
						continue;
					}
					if (pos.x >= width && pos.x >= world_width) {
						//						Debug.Log(pos_ul.x + x);
						continue;
					}
					if (pos.y < 0) {
						//						Debug.Log(pos_ul.y + y);
						continue;
					}
					if (pos.y >= height && pos.y >= world_height) {
						//						Debug.Log(pos_ul.y + y);
						continue;
					}
					
					Tile t = Paradise.Intance._TileObjects[(int)pos.x, (int)pos.y];
					
					string neighborObjectName = t._Pal._Type;
					if (dict.ContainsKey (neighborObjectName))
						dict [neighborObjectName]++;
					
//					Debug.Log(t._Floor._Type);
					neighborObjectName = t._Floor._Type;
					if (dict.ContainsKey (neighborObjectName))
						dict [neighborObjectName]++;
					
				}
			}			
		}
		foreach(string key in dict.Keys)
			Debug.Log(key + " " + dict[key]);
		
		return dict;
	}


	
}

