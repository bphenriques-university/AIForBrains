using System;
using UnityEngine;
using System.Collections;

public abstract class ReactiveBehaviour : MonoBehaviour
{
	public bool triggered = false;




	public void UpdateSituation(){
		triggered = IsInSituation();
	}

	public void Action(){
		Execute ();
		triggered = false;
	}

	protected abstract bool IsInSituation();
	protected abstract void Execute();

}

