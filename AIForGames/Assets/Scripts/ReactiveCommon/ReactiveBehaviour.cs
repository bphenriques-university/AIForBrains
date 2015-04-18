using System;
using UnityEngine;
using System.Collections;

public abstract class ReactiveBehaviour : MonoBehaviour
{
	bool triggered = false;

	public void UpdateSituation(){
		triggered = IsInSituation();
	}

	public void Action(){
		Execute ();
		triggered = false;
	}

	public bool WasTriggered(){
		return triggered;
	}

	protected abstract bool IsInSituation();
	protected abstract void Execute();

}

