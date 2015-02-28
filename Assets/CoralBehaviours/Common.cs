using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class Common : Base {

	public override void InitBy(Base other){
		this.FigurePosition = ((Common)other).FigurePosition;
		this.FigureType = ((Common)other).FigureType;
		this.FigureWillpower = ((Common)other).FigureWillpower;;
	}	
	
	// should be defined in CoralCommon
	public virtual string FigureType{ set; get;}
	public virtual Vector2 FigurePosition{ set; get;}
	public virtual float FigureWillpower{set;get;}


	public Common()
	{
		
	}

	public virtual void OnMouseDown() {

		
		ActionAdministrator.Instance.ApplyAction <RespawnAction>(gameObject);

		Debug.Log (ActionAdministrator.Instance._ErrorMessage.ToString ());
	}
}	 