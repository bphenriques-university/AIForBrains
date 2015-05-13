using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SearchForExitIntention : Intention
{

    public SearchForExitIntention(float desiredIntentLevel) : base(desiredIntentLevel) {}

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        intentValue = 0f;
        return true;
    }

    public override IList<PlanComponent> GivePlanComponents(HumanState humanState, BeliefsManager beliefs)
    {
        IList<PlanComponent> plan = new List<PlanComponent> ();
        return plan;

    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        throw new System.NotImplementedException();
    }
}
