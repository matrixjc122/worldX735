using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour  {

	/// <summary>
	/// Override to copy properties of the derived type.
	/// </summary>
	/// <param name="other">Other.</param>
	virtual public void InitBy (Base other){}
	
	
	/// <summary>
	/// Gets or sets the type of the figure.
	/// </summary>
	/// <value>The type of the figure.</value>
	public virtual string Type{ set; get;}
	
	/// <summary>
	/// Gets or sets the figure position.
	/// </summary>
	/// <value>The figure position.</value>
	public virtual Vector2 Position{ set; get;}
	
	/// <summary>
	/// Gets or sets the figure willpower.
	/// </summary>
	/// <value>The figure willpower.</value>
	public virtual int Health{set;get;}

}
