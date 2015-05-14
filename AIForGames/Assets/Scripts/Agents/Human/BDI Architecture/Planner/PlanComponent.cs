using UnityEngine;
using System.Collections;

public abstract class PlanComponent
{
	public Human human;

    public PlanComponent(Human human)
    {
        this.human = human;
	}

    /**
     * TryExecuteAction
     * Executes action and returns true if action finished, false otherwise.
     **/
	public abstract bool TryExecuteAction ();

}

