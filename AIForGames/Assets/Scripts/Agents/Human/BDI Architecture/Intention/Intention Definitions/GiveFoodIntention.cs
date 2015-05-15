using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiveFoodIntention : Intention
{
	public GiveFoodIntention(Human recipient, float desiredIntentionLevel) : base(desiredIntentionLevel){
		//TODO
	}

	public override bool Evaluate (BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
		IList<Food> foods = beliefs.GetInventoryBelief ().Foods ();
		Food toGive = foods[0];
		throw new System.NotImplementedException ();
	}

	public override System.Collections.Generic.IList<PlanComponent> GivePlanComponents (Human humanState, BeliefsManager beliefs)
	{
		throw new System.NotImplementedException ();
	}

	public override bool Succeeded (BeliefsManager beliefs)
	{
		throw new System.NotImplementedException ();
	}

	public override bool IsImpossible (BeliefsManager beliefs)
	{
		throw new System.NotImplementedException ();
	}
	



}

