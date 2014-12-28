using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CoralNeighborhood : CoralBase {

	public Vector2 m_ArrayPosition {
		get;
		set;
	}
	
	public List<GameObject> m_N8Neighbors {
				get;
				set;
	}
	
	#region CoralInterface implementation
	public override CoralBase CopyOf (CoralBase other)
	{
		m_ArrayPosition = ((CoralNeighborhood)other).m_ArrayPosition;
		m_N8Neighbors = ((CoralNeighborhood)other).m_N8Neighbors;
		return this;
	}
	#endregion
}
