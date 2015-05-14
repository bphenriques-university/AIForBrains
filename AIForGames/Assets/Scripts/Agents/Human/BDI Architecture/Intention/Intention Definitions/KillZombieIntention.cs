using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillZombieIntention : Intention
{
	GameObject zombie;

	public KillZombieIntention(GameObject zombie, float desiredIntention) : base (desiredIntention){
		
		this.zombie = zombie;

	}

	public override bool Evaluate (BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
	{
		SightBelief humanSight = beliefs.GetSightBelief ();


		if (humanSight.GetZombieSeen ().Contains (zombie) == false) {
			return false;
		}


		InventoryBelief inventory = beliefs.GetInventoryBelief ();
		int nBullets = inventory.AmmoLevel ();

		float killZombieIntentionLevel = 50/Mathf.Ceil(1/(nBullets * 2));

		intentValue = killZombieIntentionLevel;

		return true;

	}
	public override System.Collections.Generic.IList<PlanComponent> GivePlanComponents (Human human, BeliefsManager beliefs)
	{
		IList<PlanComponent> plan = new List<PlanComponent> ();

		SightBelief humanSight = beliefs.GetSightBelief ();
		NavigationBelief navBelief = beliefs.GetNavigationBelief ();

		//Only if human is not aiming at him.
		if (humanSight.IsAimingAt(navBelief.CurrentPosition(), zombie) == false) {
			plan.Add (new AimPlanComponent (human, zombie));
		}
		plan.Add(new ZombieShootPlanComponent(human, zombie));

		return plan;

	}
	public override bool Succeeded (BeliefsManager beliefs)
	{
		EnemyHealth eHealth = zombie.GetComponent<EnemyHealth>();
		return eHealth.hasDied ();
	}
	public override bool IsImpossible (BeliefsManager beliefs)
	{
		EnemyHealth eHealth = zombie.GetComponent<EnemyHealth>();
		int nbullets = beliefs.GetInventoryBelief ().AmmoLevel ();

		if (nbullets <= 0 || eHealth.hasDied()) {
			return true;
		}

		return false;
	}

	
}

