using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetAwayFromZombieIntention : Intention
{
	GameObject zombie;
	Vector3 desiredDestinationPos;


	public GetAwayFromZombieIntention(float desiredIntentionValue, GameObject zombie)
		: base(desiredIntentionValue)
	{
		this.zombie = zombie;
		
	}
	
	public override bool Evaluate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
		if (beliefs.GetSightBelief ().SawZombie ()) {
			Vector3 currentPosition = beliefs.GetNavigationBelief().CurrentPosition ().position;
			Vector3 zombiePosition = zombie.gameObject.transform.position;
			intentValue = 50 / ((currentPosition - zombiePosition).magnitude);
			
			return true;
		}
		return false;
	}
	
	public override System.Collections.Generic.IList<PlanComponent> GivePlanComponents(HumanState humanState, BeliefsManager beliefs)
	{
		IList<PlanComponent> plan = new List<PlanComponent> ();
		if (beliefs.GetSightBelief().SawZombie())
		{
			desiredDestinationPos = beliefs.GetNavigationBelief().CurrentPosition().position - zombie.transform.position;
			plan.Add(new GoToPlanComponent(humanState, desiredDestinationPos));
		}
		
		return plan;
	}
	
	public override bool Succeeded(BeliefsManager beliefs)
	{
		return Vector3.Distance(beliefs.GetNavigationBelief ().CurrentPosition (), zombie.transform.position) > GetAwayFromZombieDesire.safeDistanceToZombie;
	}
	
	public override bool IsImpossible(BeliefsManager beliefs)
	{
		return beliefs.GetHealthLevelBelief ().IsGrabbed ();
	}
}