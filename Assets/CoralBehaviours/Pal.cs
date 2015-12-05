using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using RuleAdministration.Rules;

public class Pal : MonoBehaviour, BehavioralUtils {


	public Base Base ()
	{
		return gameObject.GetComponent<Base>();
	}

	public Pal()
	{
		base.GetComponent<Base>().Type = "None";
		base.GetComponent<Base>().Health = 100;	
	}

	/// <summary>
	/// Inits this instance by other.
	/// </summary>
	/// <param name="other">Other.</param>
	public void InitBy(Base other){
		base.GetComponent<Base>().Position = other.Position;
		base.GetComponent<Base>().Type = other.Type;
		base.GetComponent<Base>().Health = other.Health;
		base.GetComponent<Base>().InitBy(other);
	}	
	
	public void Update()
	{
		
	}
	
	public void ConsumeNutrients()
	{
		TileAccessor tile = new TileAccessor(this.Base().Position);
		this.NutrientsStorage = this.NutrientsStorage - this.NutritesConsumeRate 
			+ (int)(this.RootCapacity * tile.Floor.m_FloorPeneltryRate 
			* tile.Nutrients._CurrentNutrients/tile.Nutrients._MaxNutrientsCapacity
			* tile.Nutrients._CurrentWater/tile.Nutrients._MaxWaterCapacity);
		
	}
	
	public void Start()
	{
		InvokeRepeating("ConsumeNutrients",2f, 2f);
	}
	
	public void OnGUI() {
		
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		Rect rec = new Rect(targetPos.x, Screen.height - targetPos.y, 40, 20);
		
		GUI.Label(rec, (int)(this.Base().Health) + "");
		
	}
	
	public virtual void StartChildCoroutine(IEnumerator coroutineMethod)
	{
		StartCoroutine(coroutineMethod);
	}
	
	public virtual int NutrientsStorage{set;get;}
	public virtual int RootCapacity{set;get;}
	public virtual int NutritesConsumeRate{set;get;}

	
	/// <summary>
	/// Gets or sets the figure weight.
	/// </summary>
	/// <value>The figure weight.</value>
	public virtual float PalCurrentEnergy{set; get;}
	
	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	public virtual void OnMouseDown() {

//		TileOperator TOP = new TileOperator(gameObject.GetComponent<Pal>());
		TileAccessor tile = new TileAccessor(this.Base().Position);

		if(this.Base().Type == worldXSingelton.UISelectedType)
			ActionAdministrator.Instance.ApplyAction <SARandomTransform>(tile);
		else
		{
			ActionAdministrator.Instance.ApplyAction <SAExpand>(tile);
			ActionAdministrator.Instance.ApplyAction <CAEvolutionise>(new LocalRandomSelector(tile, 2),tile);
		}	
	}
	
}	 