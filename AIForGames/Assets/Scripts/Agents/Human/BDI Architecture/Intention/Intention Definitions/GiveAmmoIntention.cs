using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiveAmmoIntention : Intention
{

	Human desiredHuman;
	int numBullets;
	int previousValue = 0;
	public GiveAmmoIntention( Human recipient, float desiredIntentionValue): base(desiredIntentionValue){
		desiredHuman = recipient;
	}
	
	public override bool Evaluate (BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
		intentValue = beliefs.GetInventoryBelief ().AmmoLevel ();
		previousValue = beliefs.GetInventoryBelief ().AmmoLevel ();

		if(previousValue > 10)
			numBullets = 5;

		if(previousValue > 15)
		   numBullets = 8;

		return beliefs.GetInventoryBelief ().AmmoLevel () > 5;
	}
	
	public override System.Collections.Generic.IList<PlanComponent> GivePlanComponents (Human human, BeliefsManager beliefs)
	{
		IList<PlanComponent> plan = new List<PlanComponent>();

        plan.Add(new WalkToPlanComponent(human, desiredHuman.transform.position));
		plan.Add(new GiveAmmoPlanComponent(desiredHuman, numBullets));
		
		return plan;
	}
	
	public override bool Succeeded (BeliefsManager beliefs)
	{
		return previousValue > beliefs.GetInventoryBelief ().AmmoLevel ();
	}
	
	public override bool IsImpossible (BeliefsManager beliefs)
	{
		return beliefs.GetInventoryBelief ().AmmoLevel () <= 0;
	}
}

