using UnityEngine;
using System.Collections;

public class KillZombieIntention : Intention
{


	public KillZombieIntention(GameObject zombie, float desiredIntention) : base (desiredIntention){
		
		throw new System.NotImplementedException ();
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


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

