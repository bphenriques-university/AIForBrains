using UnityEngine;
using System.Collections;

public class RunAwayPC : PlanComponent
{
	public override void ExecuteAction ()
	{
		Debug.Log ("RUNNING");
		actuator.Run ();
		//empty for now
	}	
}

