using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetAwayFromZombieIntention : Intention
{
	GameObject zombie;
	Vector3 desiredDestinationPos;


	public GetAwayFromZombieIntention(GameObject zombie, float desiredIntentionValue)
		: base(desiredIntentionValue)
	{
		this.zombie = zombie;
		
	}
	
	public override bool Evaluate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
	
		SightBelief sightBelief = beliefs.GetSightBelief ();

		int nZombiesSeen = sightBelief.ZombieSeen ().Count;

	
		if (sightBelief.SawZombie ()) {
			Vector3 currentPosition = beliefs.GetNavigationBelief().CurrentPosition ().position;
			Vector3 zombiePosition = zombie.gameObject.transform.position;

			float distanceToZombie = (currentPosition - zombiePosition).magnitude;
			float runIntentionLevel = 50 /Mathf.Ceil(1 / (nZombiesSeen * 10 + 1 / (distanceToZombie /10)));
			//alternative by Nuno Xu : 50 / ((currentPosition - zombiePosition).magnitude)
			intentValue = runIntentionLevel;
			
			return true;
		}
		return false;
	}
	
	public override System.Collections.Generic.IList<PlanComponent> GivePlanComponents(Human humanState, BeliefsManager beliefs)
	{
		IList<PlanComponent> plan = new List<PlanComponent> ();
		if (beliefs.GetSightBelief().SawZombie())
		{
			desiredDestinationPos = beliefs.GetNavigationBelief().CurrentPosition().position - zombie.transform.position;
			desiredDestinationPos.Normalize();
			desiredDestinationPos = desiredDestinationPos * KeepHealthyDesire.safeDistanceToZombie;
			plan.Add(new RunToPlanComponent(humanState, desiredDestinationPos));
		}
		
		return plan;
	}
	
	public override bool Succeeded(BeliefsManager beliefs)
	{
		return Vector3.Distance(beliefs.GetNavigationBelief ().CurrentPosition ().position, zombie.transform.position) > KeepHealthyDesire.safeDistanceToZombie;
	}
	
	public override bool IsImpossible(BeliefsManager beliefs)
	{
		return beliefs.GetVitalsBelief ().IsGrabbed ();
	}
}