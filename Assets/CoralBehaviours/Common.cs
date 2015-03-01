using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class Common : Base {

	/// <summary>
	/// Inits this instance by other.
	/// </summary>
	/// <param name="other">Other.</param>
	public override void InitBy(Base other){
		this.FigurePosition = ((Common)other).FigurePosition;
		this.FigureType = ((Common)other).FigureType;
		this.FigureWillpower = ((Common)other).FigureWillpower;;
	}	
	
	/// <summary>
	/// Gets or sets the type of the figure.
	/// </summary>
	/// <value>The type of the figure.</value>
	public virtual string FigureType{ set; get;}

	/// <summary>
	/// Gets or sets the figure position.
	/// </summary>
	/// <value>The figure position.</value>
	public virtual Vector2 FigurePosition{ set; get;}

	/// <summary>
	/// Gets or sets the figure willpower.
	/// </summary>
	/// <value>The figure willpower.</value>
	public virtual float FigureWillpower{set;get;}
	
	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	public virtual void OnMouseDown() {

		ActionAdministrator.Instance.ApplyAction <ExpandAction>(gameObject);

	}
}	 