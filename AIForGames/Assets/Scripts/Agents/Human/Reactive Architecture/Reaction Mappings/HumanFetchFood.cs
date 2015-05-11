using System;
using UnityEngine;

public class HumanFetchFood : ReactiveBehaviour
{

	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}

	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.IsSeeingFood ();
	}

	protected override void Execute ()
	{
		GameObject gameObject = humanState.foodSeen;

		if (humanState.foodSeen == null) {
			humanState.sawFood = false;
			return;
		}

		Vector3 foodPosition = gameObject.transform.position;
		humanState.actuator.ChangeDestination (foodPosition);
		humanState.actuator.Walk ();
	}
}


