using UnityEngine;
using System.Collections.Generic;

public abstract class Belief
{

	private bool isInBelief = false;


    public abstract void ReviewBelief(BeliefsManager beliefs, HumanState humanState);

    public bool IsInBelief()
    {
        return isInBelief;
    }
}

