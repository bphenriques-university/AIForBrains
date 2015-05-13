using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SearchForExitIntention : Intention
{

    public SearchForExitIntention(float desiredIntentLevel) : base(desiredIntentLevel) {}

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        intentValue = 0f;
        return !beliefs.GetSightBelief().SawExit();
    }

    public override IList<PlanComponent> GivePlanComponents(HumanState humanState, BeliefsManager beliefs)
    {
        IList<PlanComponent> plan = new List<PlanComponent> ();
        plan.Add(new RandomWalkPlanComponent(humanState));
        return plan;

    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
        return beliefs.GetSightBelief().SawExit();
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        return beliefs.GetSightBelief().SawExit();
    }
}
