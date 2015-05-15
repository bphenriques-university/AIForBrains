using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiveFoodIntention : Intention
{
	Human desiredHuman;
	Food foodIWantToGive;
	int previousFoodCount;

	public GiveFoodIntention(Human recipient, float desiredIntentionLevel) : base(desiredIntentionLevel){
		desiredHuman = recipient;
	}

	public override bool Evaluate (BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
		IList<Food> foods = beliefs.GetInventoryBelief ().Foods ();
		Food toGive = foods[0];

		intentValue = 50 - Mathf.Floor((float)beliefs.GetVitalsBelief ().GetMaxHealthLevel () - beliefs.GetVitalsBelief ().GetHealthLevel ()*0.5f);

		previousFoodCount = beliefs.GetInventoryBelief ().Foods ().Count;

		return previousFoodCount > 0;
	}

	public override System.Collections.Generic.IList<PlanComponent> GivePlanComponents (Human humanState, BeliefsManager beliefs)
	{
		IList<PlanComponent> plan = new List<PlanComponent>();

		plan.Add(new GiveFoodPlanComponent(desiredHuman, foodIWantToGive));

		return plan;

	}

	public override bool Succeeded (BeliefsManager beliefs)
	{
		return previousFoodCount > beliefs.GetInventoryBelief ().Foods ().Count;
	}

	public override bool IsImpossible (BeliefsManager beliefs)
	{
		return beliefs.GetInventoryBelief ().Foods ().Count == 0;
	}
}

