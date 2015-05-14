using UnityEngine;
using System.Collections.Generic;

public class GatherFoodIntention : Intention
{
    private Food foodToBeGathered;

    public GatherFoodIntention(float desiredIntentionValue)
        : base(desiredIntentionValue)
    {}

    public GatherFoodIntention(float desiredIntentionValue, Food food)
        : base(desiredIntentionValue)
    {
        this.foodToBeGathered = food;
    }

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        if (foodToBeGathered)
        {
            Vector3 currentPosition = beliefs.GetNavigationBelief().CurrentPosition().position;
            Vector3 foodPosition = foodToBeGathered.transform.position;
            intentValue = 40 / Mathf.Ceil((currentPosition - foodPosition).magnitude);
            return !foodToBeGathered.Catched();
        }
        else
        {
            intentValue = 0;
            return false;
        }
    }

    public override IList<PlanComponent> GivePlanComponents(Human humanState, BeliefsManager beliefs)
    {

        IList<PlanComponent> plan = new List<PlanComponent>();
        plan.Add(new WalkToPlanComponent(humanState, foodToBeGathered.transform.position));
        plan.Add(new CatchFoodPlanComponent(humanState, foodToBeGathered));
        return plan;
    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
        return foodToBeGathered.Catched() && beliefs.GetInventoryBelief().Foods().Contains(foodToBeGathered);
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        return !foodToBeGathered || foodToBeGathered.Eaten() || (foodToBeGathered.Catched() && !beliefs.GetInventoryBelief().Foods().Contains(foodToBeGathered));
    }
}
