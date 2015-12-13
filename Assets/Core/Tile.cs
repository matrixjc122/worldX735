using UnityEngine;
using System.Collections;
using RuleAdministration.Interfaces;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class Tile : MonoBehaviour{
	
	public Vector2 _Position{set;get;}
	public PalProperty _Pal{set;get;}
	public FloorProperty _Floor{set;get;}
	public NutrientsPart _Nutrients{set;get;}
	
	public BehaviourType AccosiateType<BehaviourType>(string type)
	{
		BehaviourType behaviour = this.gameObject.GetComponent<BehaviourType>();
		
		Destroy((behaviour as BaseProperty)._Appearence);
		
		GameObject prefab = MakePrefab(type);
		(behaviour as BaseProperty)._Appearence = prefab;
		(behaviour as BaseProperty)._Type = type;
		
//		Debug.Log("New Association " + type);
		
		prefab.SetActive(true);
		return behaviour;
	}
	
	public GameObject MakePrefab(string type)
	{
		GameObject prefab = GameObject.Instantiate(Resources.Load (type) as GameObject);
		prefab.transform.position = gameObject.transform.position;
		prefab.transform.parent = gameObject.transform;
		return prefab;
	}
	
	public void Start()
	{
		
		
	}
	
	public void LazyInitialisation(Vector3 worldPosition, Vector2 arrayPosition) 
	{
		
		_Pal = this.gameObject.AddComponent<PalProperty>();
		_Nutrients = this.gameObject.AddComponent<NutrientsPart>();
		_Floor = this.gameObject.AddComponent<FloorProperty>();	
		BoxCollider collider = this.gameObject.AddComponent<BoxCollider>();
		collider.size = new Vector3(1.0f,0.01f,1.0f);
		
		
		
		this._Position = arrayPosition;
		this.gameObject.transform.position =  worldPosition;
	}
	
	public void OnGUI() {
		
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		Rect rec = new Rect(targetPos.x, Screen.height - targetPos.y, 40, 20);
		
		GUI.Label(rec, (int)(this._Pal._Health) + "");
		
	}
	
	public virtual void OnMouseDown() {
		
		Debug.LogError("Tile MouseDown");
		
		ActionAdministrator.Instance.ApplyAction<SAUpgrade>(this);
		
	} 
	
	public virtual void OnMouseEnter() {
		
		Debug.LogError("Tile MouseEnter");
		MOAPreview action = new MOAPreview();
		action._Status = MOAPreview.Stats.ENTER;
		ActionAdministrator.Instance.ApplyAction(action,this);

		SAScale scale_action = new SAScale();
		scale_action._ScaleFactor = 1.2f;
		ActionAdministrator.Instance.ApplyAction (scale_action, this);
		
	} 
	
	public virtual void OnMouseExit() {
		
//		Debug.LogError("Tile MouseExit");
		MOAPreview action = new MOAPreview();
		action._Status = MOAPreview.Stats.EXIT;
		ActionAdministrator.Instance.ApplyAction(action,this);

		SAScale scale_action = new SAScale();
		scale_action._ScaleFactor = 1.0f;
		ActionAdministrator.Instance.ApplyAction (scale_action, this);

		//		ActionAdministrator.Instance.ApplyAction<SAUpgrade>(this);
		
	} 
}
