using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Common : Base {

	public override void InitBy(Base other){
		this.FigurePosition = ((Common)other).FigurePosition;
		this.FigureType = ((Common)other).FigureType;
	}	
	
	// should be defined in CoralCommon
	public virtual string FigureType{ set; get;}
	public virtual Vector2 FigurePosition{ set; get;}


	public virtual void OnMouseDown() {

		// Create CoralCopy (applies position, name, behavioral properties
		GameObject prefabGameObject = worldXSingelton.CloneZombiPrefab (worldXSingelton.UISelectedType, gameObject.transform.position, Quaternion.identity);
		prefabGameObject.GetComponent<Common> ().FigurePosition = this.FigurePosition;
		prefabGameObject.GetComponent<Common> ().FigureType = worldXSingelton.UISelectedType;

		if (RuleUtil.IsPlaceable(prefabGameObject)) 
		{
			worldXSingelton.WorldObjects[(int)FigurePosition.x, (int)FigurePosition.y] = prefabGameObject;
			prefabGameObject.SetActive (true);	
			Destroy (gameObject);
		} else {
			Destroy (prefabGameObject);
		}

	}
}	 