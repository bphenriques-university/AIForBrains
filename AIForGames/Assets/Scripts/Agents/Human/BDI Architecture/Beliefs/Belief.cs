using UnityEngine;
using System.Collections.Generic;

public abstract class Belief
{

	protected bool isInBelief = true;


    public abstract void ReviewBelief(BeliefsManager beliefs, Human humanState);

    public bool IsInBelief()
    {
        return isInBelief;
    }
}

