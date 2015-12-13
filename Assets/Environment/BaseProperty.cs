using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseProperty : MonoBehaviour  
{
	
	public virtual void Start()
	{
//		this._Health = 100;
	}
	
	/// <summary>
	/// Gets or sets the type of the figure.
	/// </summary>
	/// <value>The type of the figure.</value>
	public string _Type{ set; get;}
	
	/// <summary>
	/// Gets or sets the figure willpower.
	/// </summary>
	/// <value>The figure willpower.</value>
	public int _Health{set;get;}
	
	/// <summary>
	/// Bidirectional access to enclosing Tile
	/// </summary>
	/// <value>The _ tile.</value>
	public GameObject _Appearence{set;get;}
	
	
	public Tile _Tile{set;get;}

	

	/// <summary>
	/// Prototype method involving corutines
	/// </summary>
	/// <param name="coroutineMethod">Coroutine method.</param>
	//	public virtual void StartChildCoroutine(IEnumerator coroutineMethod)
	//	{
	//		StartCoroutine(coroutineMethod);
	//	}

}
