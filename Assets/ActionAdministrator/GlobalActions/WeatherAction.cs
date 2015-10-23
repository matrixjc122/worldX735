//using UnityEngine;
//using System.Collections;
//using RuleAdministration.Interfaces;
//using RuleAdministration.Administrators;
//
//public class WeatherAction : IRepeatableAction {
//
//	interface IWeatherType
//	{
//		bool ApplyWeatherChanges (GameObject obj);
//	};
//
//	public class RainyWeather : IWeatherType
//	{
//
//		public bool ApplyWeatherChanges (GameObject obj)
//		{
//			Vector2 erode_pos = Random.insideUnitCircle * 10.0f + obj.GetComponent<Common> ().FigurePosition;
//
//			//Debug.Log (pos);
//			return true;
//		}
//	};
//
//	#region IAction implementation
//
//	public void BeforeUpdate (params GameObject[] list)
//	{
//
//	}
//
//	public bool IsApplicable (params GameObject[] list)
//	{
//
//		return true;
//	}
//
//	public bool Update (params GameObject[] list)
//	{
//		if (TriggerCounter <= 0)
//			return false;
//
//		int x = Random.Range (0, worldXSingelton.WorldObjects.GetLength (0));
//		int y = Random.Range (0, worldXSingelton.WorldObjects.GetLength (1));
//
//
//		// decrease the trigger_count
//		TriggerCounter--;
//		return true;
//	}
//
//	public GameObject SampleAffected()
//	{
//		return null;
//	}
//
//	public string Name ()
//	{
//		return "WeatherAction";
//	}
//
//	public void RegisterSelf ()
//	{
//		ActionAdministrator.Instance.TriggerEventActionList.Add (this);
//	}
//
//
//	public void UnregisterSelf ()
//	{
//		ActionAdministrator.Instance.TriggerEventActionList.Remove (this);
//	}
//
//
//	public int TriggerType{ get; set;}
//
//	public int TriggerCounter {get;set;}
//	
//
//
//	#endregion
//}
