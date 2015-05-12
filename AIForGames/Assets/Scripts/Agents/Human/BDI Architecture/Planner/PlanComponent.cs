using UnityEngine;
using System.Collections;

public abstract class PlanComponent
{
	public HumanState humanState;

    public PlanComponent(HumanState humanstate)
    {
        this.humanState = humanstate;
	}

    /**
     * TryExecuteAction
     * Executes action and returns true if action finished, false otherwise.
     **/
	public abstract bool TryExecuteAction ();

}

