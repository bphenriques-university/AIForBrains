using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoToExitIntention : Intention
{

    public GoToExitIntention (float desiredIntention) : base (desiredIntention) {}

	public void Awake(){
	}

	public override bool Succeeded (){
		
		//Always returns false because when the human reaches the exit, the human is destroyed
		return false;
	}

	public override bool IsImpossible(){

        //TODO
        return false;
		
	}

    public override bool Evaluate(BeliefsManager beliefs, System.Collections.Generic.IList<Intention> previousIntentions)
    {
        throw new System.NotImplementedException();
    }

    public override IList<PlanComponent> GivePlanComponents(HumanState humanState, BeliefsManager beliefs)
    {
        throw new System.NotImplementedException();
    }
}

