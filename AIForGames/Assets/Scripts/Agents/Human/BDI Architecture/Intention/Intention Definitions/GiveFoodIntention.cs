using UnityEngine;
using System.Collections;

public class GiveFoodIntention : Intention
{
	public GiveFoodIntention(Human recipient, Food food, float desiredIntentionLevel) : base(desiredIntentionLevel){
		//TODO
	}

	public override bool Evaluate (BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
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

