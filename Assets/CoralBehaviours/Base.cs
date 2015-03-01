using UnityEngine;
using System.Collections;

public abstract class Base : MonoBehaviour  {

	/// <summary>
	/// Override to copy properties of the derived type.
	/// </summary>
	/// <param name="other">Other.</param>
	virtual public void InitBy (Base other) {}

}
