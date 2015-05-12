using UnityEngine;
using System.Collections;

public class GoToExitPC : PlanComponent
{

    public GoToExitPC(HumanState humanState)
        : base(humanState)
    { }

	public override bool TryExecuteAction ()
	{
		Debug.Log ("RUNNING TO EXIT");
		humanState.actuator.Run ();
        return true;//empty for now
	}	
}

