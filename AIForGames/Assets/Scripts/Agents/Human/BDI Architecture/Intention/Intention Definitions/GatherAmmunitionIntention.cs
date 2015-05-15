using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GatherAmmunitionIntention : Intention
{
	Ammo desiredAmmo;

	public GatherAmmunitionIntention(float desiredIntentionValue, Ammo desiredAmmo)
		: base(desiredIntentionValue)
	{
		this.desiredAmmo = desiredAmmo;

	}
	
	public override bool Evaluate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
		if (beliefs.GetSightBelief ().SawAmmo ()) {
			Vector3 currentPosition = beliefs.GetNavigationBelief ().CurrentPosition ().position;
			Vector3 ammoPosition = desiredAmmo.gameObject.transform.position;
			intentValue = 50 / ((currentPosition - ammoPosition).magnitude);
				
			return true;
		}
		return false;
	}
	
	public override System.Collections.Generic.IList<PlanComponent> GivePlanComponents(Human humanState, BeliefsManager beliefs)
	{
		IList<PlanComponent> plan = new List<PlanComponent> ();
		if (beliefs.GetSightBelief().SawAmmo() && !desiredAmmo.wasPickedUp)
		{
			plan.Add(new WalkToPlanComponent(humanState, desiredAmmo.transform.position));
			plan.Add(new CatchAmmoPlanComponent(humanState, desiredAmmo));
		}

		return plan;
	}
	
	public override bool Succeeded(BeliefsManager beliefs)
	{
		return desiredAmmo.WasPickedUp ();
	}
	
	public override bool IsImpossible(BeliefsManager beliefs)
	{
		return !beliefs.GetSightBelief ().SawAmmo ();
	}

    public override bool IsImportant()
    {
        return false;
    }
}

