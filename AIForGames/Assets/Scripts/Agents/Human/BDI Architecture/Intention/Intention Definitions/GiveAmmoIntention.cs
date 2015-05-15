using UnityEngine;
using System.Collections;

public class GiveAmmoIntention : Intention
{

	public GiveAmmoIntention(Human me, Human recipient, int bullets, float desiredIntentionValue): base(desiredIntentionValue){
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

