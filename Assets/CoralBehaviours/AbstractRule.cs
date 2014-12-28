using UnityEngine;
using System.Collections;

public abstract class AbstractRule : MonoBehaviour {

	abstract public bool isApplicable();

	abstract public bool isPlaceable();

}