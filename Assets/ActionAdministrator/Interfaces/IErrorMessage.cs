using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IErrorMessage{

	
	void Report(string msg);

	bool State{ get; set;}
	List<string> Messages{ get; set;}
	void ClearState();

}
