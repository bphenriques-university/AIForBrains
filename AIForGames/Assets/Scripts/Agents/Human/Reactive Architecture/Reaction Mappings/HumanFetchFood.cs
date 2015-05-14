using System;
using UnityEngine;

public class HumanFetchFood : ReactiveBehaviour
{

	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
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
		humanState.Actuators.ChangeDestination (foodPosition);
		humanState.Actuators.Walk ();
	}
}


