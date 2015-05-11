using UnityEngine;
using System.Collections;

public class GoToExitPC : PlanComponent
{

	public override void ExecuteAction ()
	{
		Debug.Log ("RUNNING TO EXIT");
		actuator.Run ();
		//empty for now
	}	
}

