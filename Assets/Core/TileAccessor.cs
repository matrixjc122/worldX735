using UnityEngine;
using System.Collections;
using RuleAdministration.Interfaces;
using RuleAdministration.Administrators;

public class TileAccessor {

	public Vector2 TilePosition{set; get;}
	
	
	public TileAccessor(Pal objc)
		: this(objc.Base().Position)
	{		
	}
	
	public TileAccessor(Vector2 pos)
	{
		this.TilePosition = pos;
		CatchTiles();
	}
	
	
	public void CatchTiles()
	{
		this.Pal = worldXSingelton.Layer2Objects[(int)this.TilePosition.x,(int)this.TilePosition.y].GetComponentInParent<Pal>();
		this.Floor = worldXSingelton.Layer3Floor[(int)this.TilePosition.x,(int)this.TilePosition.y].GetComponentInParent<Floor>();
		this.Nutrients = worldXSingelton.Layer4Nutrients[(int)this.TilePosition.x,(int)this.TilePosition.y].GetComponentInParent<Nutrients>();
	}
	
	
	/// <Layer 2: GameObject representing individuals>
	/// The m_TileObject keeps a pointer onto the Common 
	/// behaviour, quick access to Figure-Properties
	/// </summary>
	protected Pal m_TileObject;
	public Pal Pal
	{
		set
		{
			this.m_TileObject = value;
		}
		
		get
		{
			return m_TileObject;
		}
	}
	
	
	/// <Layer 3: Floor as it is, Floor!>
	/// The m_TileFloor keeps a pointer onto the Floor
	/// entity
	/// </summary>
		protected Floor m_TileFloor;
		public Floor Floor
		{
			set
			{
				this.m_TileFloor = value;
			}
			
			get
			{
				return m_TileFloor;
			}
		}
	
	/// <Layer 4: Nutrients representing local Energy/Food>
	/// The m_TileNutriens keeps a pointer onto the Nutriens 
	/// descriptor
	/// </summary>
	protected Nutrients m_TileNutrients;
	public Nutrients Nutrients
	{
		set
		{
			this.m_TileNutrients = value;
		}
		
		get
		{
			return m_TileNutrients;
		}
	}
	
}
