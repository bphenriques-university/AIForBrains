using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EatFoodIntention : Intention
{
    private Food foodToBeEaten;

    public EatFoodIntention(Food foodToBeEaten, float desiredIntentValue)
        : base(desiredIntentValue)
    {
        this.foodToBeEaten = foodToBeEaten;
    }

    public override bool Succeeded(BeliefsManager beliefs)
    {
        return foodToBeEaten.Eaten();
    }

    public override bool IsImpossible(BeliefsManager beliefs)
    {
        return foodToBeEaten.Eaten() || 
            (foodToBeEaten.Catched() && !beliefs.GetInventoryBelief().Foods().Contains(foodToBeEaten));
    }

    public override bool Evaluate(BeliefsManager beliefs, IList<Intention> previousIntentions)
    {
        if (beliefs.GetInventoryBelief().Foods().Contains(foodToBeEaten)) {
            intentValue = 50;
        } else {
            if (beliefs.GetSightBelief().SawFood())
            {
                Vector3 currentPosition = beliefs.GetNavigationBelief().CurrentPosition().position;
                Vector3 foodPosition = foodToBeEaten.transform.position;
                intentValue = 50 / ((currentPosition - foodPosition).magnitude);
            }
            else
            {
                return false;
            }
        }
        
        
        return true;
    }

    public override IList<PlanComponent> GivePlanComponents(HumanState humanState, BeliefsManager beliefs)
    {
        IList<PlanComponent> plan = new List<PlanComponent> ();
        if (beliefs.GetInventoryBelief().Foods().Contains(foodToBeEaten))
        {
            plan.Add(new EatFoodPlanComponent(humanState, foodToBeEaten));
        }
        else
        {
            if (beliefs.GetSightBelief().SawFood())
            {
                plan.Add(new WalkToPlanComponent(humanState, foodToBeEaten.transform.position));
                plan.Add(new CatchFoodPlanComponent(humanState, foodToBeEaten));
                plan.Add(new EatFoodPlanComponent(humanState, foodToBeEaten));
            }
        }

        return plan;
    }
}
