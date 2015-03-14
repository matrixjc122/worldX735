using UnityEngine;
using System.Collections;
using RuleAdministration.Interfaces;

public interface IRepeatableAction : IAction {

	/// <summary>
	/// Gets or sets the number of triggers.
	/// </summary>
	/// <value>The number of triggers.</value>
	int TriggerCounter{ set;get;}

	/// <summary>
	/// Register this instance in ActionAdministrator triggerlist.
	/// </summary>
	void RegisterSelf();

	/// <summary>
	/// Unregisters this instance in ActionAdministrator triggerList, e.g. set TriggerCounter to zero to cancel action triggering.
	/// </summary>
	void UnregisterSelf();

	/// <summary>
	/// Gets or sets the type of the trigger.
	/// </summary>
	/// <value>The type of the trigger.</value>
	int TriggerType{ get; set;}

}
