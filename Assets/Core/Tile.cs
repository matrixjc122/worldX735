using UnityEngine;
using System.Collections;
using RuleAdministration.Interfaces;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class Tile : MonoBehaviour{
	
	public Vector2 _Position{set;get;}
	public Pal _Pal{set;get;}
	public Floor _Floor{set;get;}
	public Nutrients _Nutrients{set;get;}
	
	public BehaviourType AccosiateType<BehaviourType>(string type)
	{
		BehaviourType behaviour = this.gameObject.GetComponent<BehaviourType>();
		
		Destroy((behaviour as Base)._Appearence);
		
		GameObject prefab = MakePrefab(type);
		(behaviour as Base)._Appearence = prefab;
		(behaviour as Base)._Type = type;
		
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
		
		_Pal = this.gameObject.AddComponent<Pal>();
		_Nutrients = this.gameObject.AddComponent<Nutrients>();
		_Floor = this.gameObject.AddComponent<Floor>();	
		BoxCollider collider = this.gameObject.AddComponent<BoxCollider>();
		collider.size = new Vector3(0.5f,0.5f,0.5f);
		
		
		
		this._Position = arrayPosition;
		this.gameObject.transform.position =  worldPosition;
	}
	
	public virtual void OnMouseDown() {
		
		Debug.LogError("Tile MouseDown");
		
		ActionAdministrator.Instance.ApplyAction<SAUpgrade>(this);
		
	} 
	
	public virtual void OnMouseEnter() {
		
		Debug.LogError("Tile MouseEnter");
		MOAPreview action = new MOAPreview();
		action._Enable = true;
		ActionAdministrator.Instance.ApplyAction(action,this);
		
	} 
	
	public virtual void OnMouseExit() {
		
		Debug.LogError("Tile MouseExit");
		MOAPreview action = new MOAPreview();
		action._Enable = false;
		ActionAdministrator.Instance.ApplyAction(action,this);
		
		//		ActionAdministrator.Instance.ApplyAction<SAUpgrade>(this);
		
	} 
}
