using UnityEngine;
using System.Collections.Generic;

public class LookForFoodIntention : Intention
{
    public LookForFoodIntention(float desiredIntentionValue)
        : base(desiredIntentionValue)
    {}

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        intentValue = 0f;
        return !beliefs.GetSightBelief().SawFood();
    }

    public override IList<PlanComponent> GivePlanComponents(Human humanState, BeliefsManager beliefs)
    {
        IList<PlanComponent> plan = new List<PlanComponent>();
        plan.Add(new RandomWalkPlanComponent(humanState));
        return plan;
    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
        return beliefs.GetSightBelief().SawFood();
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        //It should never be impossible to look for more food.
        return false;
    }
}
