using UnityEngine;
using System.Collections;

public class KillZombieIntention : Intention
{
	GameObject zombie;

	public KillZombieIntention(GameObject zombie, float desiredIntention) : base (desiredIntention){
		
		this.zombie = zombie;

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
		EnemyHealth eHealth = zombie.GetComponent<EnemyHealth>();
		int nbullets = beliefs.GetInventoryBelief ().AmmoLevel ();

		if (nbullets <= 0 || eHealth.hasDied()) {
			return true;
		}

		return false;
	}


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

