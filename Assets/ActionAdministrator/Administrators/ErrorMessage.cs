using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ErrorMessage : IErrorMessage {

	protected List<string> _Messages = new List<string> ();
	protected bool _State = false;

	#region IErrorMessage implementation

	void IErrorMessage.Report (string msg)
	{
		_Messages.Add (msg);
						
	}

	bool IErrorMessage.State {
		get {
			return _State;
		}
		set {
			_State = value;
		}
	}

	List<string> IErrorMessage.Messages {
		get {
			return _Messages;
		}
		set {
			_Messages = value;
		}
	}
	

	void IErrorMessage.ClearState ()
	{
		_Messages.Clear ();
		_State = false;
	}
	

	override public string ToString()
	{
		string outMsg = "Error Message\n";
		foreach (string msg in _Messages) 
		{
			outMsg += "\t" + msg + "\n";
		}
		return outMsg;
	}

	#endregion



}
